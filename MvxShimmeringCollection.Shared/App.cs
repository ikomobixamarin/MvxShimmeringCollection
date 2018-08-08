using System;
using MvvmCross.ViewModels;
namespace MvxShimmeringCollection.Shared
{
    public class App : MvxApplication
    {
        public App()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            this.RegisterAppStart<MainViewModel>();
        }
    }
}
