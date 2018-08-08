using System;
using Android.App;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MvxShimmeringCollection.Droid
{
    [Activity(Label = "MvxShimmeringCollection", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/AppTheme")]
    public class Splashscreen : MvxSplashScreenAppCompatActivity
    {
        public Splashscreen()
        {
        }
    }
}
