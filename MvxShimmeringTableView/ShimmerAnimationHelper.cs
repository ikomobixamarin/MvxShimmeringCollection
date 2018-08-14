using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace MvxShimmering
{
    public static class ShimmerAnimationConfig
    {
        public static CGColor LightColor = UIColor.White.ColorWithAlpha(0.5f).CGColor;
        public static CGColor DarkColor = UIColor.Black.ColorWithAlpha(1).CGColor;

        /// <summary>
        /// Duration in seconds. Default is 1.0
        /// </summary>
        public static double Duration = 1.0;
    }

    /// <summary>
    /// Built based on https://gist.github.com/Marlon-Monroy/af108545dec7e5cbf2612610d46c65c4
    /// </summary>
    public static class ShimmerAnimationHelper
    {
        static string shimmerKey = "io.monroy.shimmer.key";

        public static CAGradientLayer BuildShimmeringGradient(
            CGRect bounds,
            int repeatCount = 3)
        {
            CAGradientLayer gradient = new CAGradientLayer();
            CABasicAnimation animation = new CABasicAnimation() { KeyPath = "locations" };

            gradient.Colors = new CGColor[]
            {
                ShimmerAnimationConfig.DarkColor,
                ShimmerAnimationConfig.LightColor,
                ShimmerAnimationConfig.DarkColor
            };
            gradient.Frame = new CGRect(-2 * bounds.Size.Width, 0, 4 * bounds.Size.Width, bounds.Size.Height);
            gradient.StartPoint = new CGPoint(0, 0.5);
            gradient.EndPoint = new CGPoint(1, 0.5);
            gradient.Locations = new Foundation.NSNumber[] { 0.4, 0.5, 0.6 };
            animation.Duration = ShimmerAnimationConfig.Duration;
            animation.RepeatCount = repeatCount;
            animation.SetTo(NSArray.FromObjects(0.0, 0.12, 0.13));
            animation.SetFrom(NSArray.FromObjects(0.6, 0.86, 1.0));
            gradient.AddAnimation(animation, shimmerKey);

            return gradient;
        }
    }
}
