using System;

using Foundation;
using MvxShimmering;
using UIKit;

namespace MvxShimmeringCollection.iOS
{
    public partial class ShimmeringTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ShimmeringTableViewCell");
        public static readonly UINib Nib;

        static ShimmeringTableViewCell()
        {
            Nib = UINib.FromName("ShimmeringTableViewCell", NSBundle.MainBundle);
        }

        protected ShimmeringTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.Root.Start();
        }
    }
}
