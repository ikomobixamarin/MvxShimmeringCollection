using System;

using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;

namespace MvxShimmeringCollection.iOS
{
    public partial class MyTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MyTableViewCell");
        public static readonly UINib Nib;

        static MyTableViewCell()
        {
            Nib = UINib.FromName("MyTableViewCell", NSBundle.MainBundle);
        }

        protected MyTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MyTableViewCell, string>();
                set.Bind(this.label)
                   .To(vm => vm);
                set.Apply();
            });
        }
    }
}
