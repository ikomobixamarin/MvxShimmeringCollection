using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace MvxShimmering
{
    public abstract class MvxShimmeringTableViewSource : MvxTableViewSource
    {
        private int numberOfShimmeringCells;

        public string ShimmeringCellId
        {
            get;
            private set;
        }

        public override IEnumerable ItemsSource
        {
            get => base.ItemsSource;
            set
            {
                var itemsToBind = value;

                if (itemsToBind == null)
                {
                    itemsToBind = new List<ShimmerFakeCell>(Enumerable.Repeat(new ShimmerFakeCell(), this.numberOfShimmeringCells));
                }

                base.ItemsSource = itemsToBind;
            }
        }

        public MvxShimmeringTableViewSource(IntPtr handle)
            : base(handle)
        {
        }

        public MvxShimmeringTableViewSource(UITableView tableView)
            : base(tableView)
        {
        }

        public void SetShimmeringPlaceholder(UINib nib, NSString cellKey, int numberOfShimmeringCells = 10)
        {
            this.numberOfShimmeringCells = numberOfShimmeringCells;
            this.TableView.RegisterNibForCellReuse(nib, cellKey);
            this.ShimmeringCellId = cellKey;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            if (item is ShimmerFakeCell)
            {
                return this.TableView.DequeueReusableCell(this.ShimmeringCellId);
            }

            return this.GetOrCreateNonShimmeringCellFor(tableView, indexPath, item);
        }

        protected abstract UITableViewCell GetOrCreateNonShimmeringCellFor(UITableView tableView, NSIndexPath indexPath, object item);

    }
}
