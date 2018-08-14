using System;
using System.Collections;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using System.Collections.Generic;

namespace MvxShimmering
{
    public class MvxShimmeringSimpleTableViewSource : MvxSimpleTableViewSource
    {
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
                    // Create 10 fake items by default
                    // TODO: Make it customizable
                    itemsToBind = new List<ShimmerFakeCell>
                    {
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell(),
                        new ShimmerFakeCell()
                    };
                }

                base.ItemsSource = itemsToBind;
            }
        }

        public MvxShimmeringSimpleTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public MvxShimmeringSimpleTableViewSource(UITableView tableView, string cellIdentifier) : base(tableView, cellIdentifier)
        {
        }

        public MvxShimmeringSimpleTableViewSource(UITableView tableView, Type cellType, string cellIdentifier = null) : base(tableView, cellType, cellIdentifier)
        {
        }

        public MvxShimmeringSimpleTableViewSource(UITableView tableView, string nibName, string cellIdentifier = null, NSBundle bundle = null) : base(tableView, nibName, cellIdentifier, bundle)
        {
        }

        public void SetShimmeringPlaceholder(UINib nib, NSString cellKey)
        {
            this.TableView.RegisterNibForCellReuse(nib, cellKey);
            this.ShimmeringCellId = cellKey;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            if (item is ShimmerFakeCell)
            {
                return this.TableView.DequeueReusableCell(this.ShimmeringCellId);
            }

            return base.GetOrCreateCellFor(tableView, indexPath, item);
        }
    }
}
