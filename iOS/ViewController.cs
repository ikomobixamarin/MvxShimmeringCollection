using System;

using UIKit;
using MvvmCross.Platforms.Ios.Views;
using MvxShimmeringCollection.Shared;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Binding.BindingContext;

namespace MvxShimmeringCollection.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxRootPresentation]
    public partial class ViewController : MvxViewController<MainViewModel>
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.tableView.RowHeight = (nfloat)150;
            this.tableView.RegisterNibForCellReuse(MyTableViewCell.Nib, MyTableViewCell.Key);

            var viewSource = new MvxSimpleTableViewSource(this.tableView, MyTableViewCell.Key);

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
