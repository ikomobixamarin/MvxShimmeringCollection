using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using MvxShimmeringCollection.Shared;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MvxShimmeringCollection.Droid
{
    [Activity(Label = "MvxShimmeringCollection", Icon = "@mipmap/icon", Theme = "@style/AppTheme")]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

