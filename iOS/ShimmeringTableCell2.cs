using System;

using Foundation;
using UIKit;

namespace MvxShimmeringCollection.iOS
{
    public partial class ShimmeringTableCell2 : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ShimmeringTableCell2");
        public static readonly UINib Nib;

        static ShimmeringTableCell2()
        {
            Nib = UINib.FromName("ShimmeringTableCell2", NSBundle.MainBundle);
        }

        protected ShimmeringTableCell2(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
