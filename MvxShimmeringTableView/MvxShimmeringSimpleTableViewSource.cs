﻿using System;
using System.Collections;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace MvxShimmering
{
    public class MvxShimmeringSimpleTableViewSource : MvxSimpleTableViewSource
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

        public MvxShimmeringSimpleTableViewSource(IntPtr handle)
            : base(handle)
        {
        }

        public MvxShimmeringSimpleTableViewSource(UITableView tableView, string cellIdentifier)
            : base(tableView, cellIdentifier)
        {
        }

        public MvxShimmeringSimpleTableViewSource(UITableView tableView, Type cellType, string cellIdentifier = null)
            : base(tableView, cellType, cellIdentifier)
        {
        }

        public MvxShimmeringSimpleTableViewSource(UITableView tableView, string nibName, string cellIdentifier = null, NSBundle bundle = null)
            : base(tableView, nibName, cellIdentifier, bundle)
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

            return base.GetOrCreateCellFor(tableView, indexPath, item);
        }
    }
}
