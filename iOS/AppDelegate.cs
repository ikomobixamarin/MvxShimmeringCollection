﻿using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvxShimmeringCollection.Shared;
using UIKit;

namespace MvxShimmeringCollection.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}

