using System;

using UIKit;
using MvvmCross.Platforms.Ios.Views;
using MvxShimmeringCollection.Shared;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Binding.BindingContext;
using MvxShimmering;

namespace MvxShimmeringCollection.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class ViewController : MvxViewController<MainViewModel>
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // MvxShimmeringSimpleTableViewSource inherits from MvxSimpleTableViewSource
            //var viewSource = new MvxShimmeringSimpleTableViewSource(this.tableView, MyTableViewCell.Key);
            var viewSource = new MyTableViewSource(this.tableView);

            this.tableView.RowHeight = (nfloat)150;
            this.tableView.RegisterNibForCellReuse(MyTableViewCell.Nib, MyTableViewCell.Key);
            viewSource.SetShimmeringPlaceholder(ShimmeringTableViewCell.Nib, ShimmeringTableViewCell.Key);

            // Override color codes used by the shimmering animation here
            //ShimmerAnimationConfig.DarkColor = UIColor.Black.ColorWithAlpha(1f).CGColor;
            //ShimmerAnimationConfig.LightColor = UIColor.White.ColorWithAlpha(0.1f).CGColor;

            this.tableView.Source = viewSource;

            var set = this.CreateBindingSet<ViewController, MainViewModel>();

            set.Bind(viewSource)
               .For(s => s.ItemsSource)
               .To(vm => vm.Items);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }
    }
}
