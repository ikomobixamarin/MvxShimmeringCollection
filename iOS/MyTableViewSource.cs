using System;
using Foundation;
using MvxShimmering;
using UIKit;

namespace MvxShimmeringCollection.iOS
{
    public class MyTableViewSource : MvxShimmeringTableViewSource
    {
        public MyTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public MyTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateNonShimmeringCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(MyTableViewCell.Key, indexPath);
        }
    }
}
