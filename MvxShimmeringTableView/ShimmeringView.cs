using System;
using CoreGraphics;
using UIKit;
using CoreAnimation;
using Foundation;
using System.ComponentModel;

namespace MvxShimmering
{
    [Register("ShimmeringView", true), DesignTimeVisible(true)]
    public class ShimmeringView : UIView
    {
        static string shimmerKey = "io.monroy.shimmer.key";
        static CGColor light = UIColor.White.ColorWithAlpha(0.1f).CGColor;
        static CGColor darkColor = UIColor.Black.ColorWithAlpha(1).CGColor;
        static bool isShimmering = false;
        static CAGradientLayer gradient = new CAGradientLayer();

        static CABasicAnimation animation = new CABasicAnimation() { KeyPath = "locations" };

        public class ShimmeringViewAppearance : UIViewAppearance
        {
            protected internal ShimmeringViewAppearance(IntPtr handle)
                : base(handle)
            {

            }
        }

        public UIColor LightColor
        {
            get => new UIColor(light);
            set
            {
                light = value.CGColor;
            }
        }

        public UIColor DarkColorColor
        {
            get => new UIColor(darkColor);
            set
            {
                darkColor = value.CGColor;
            }
        }

        public bool IsShimmering
        {
            get => isShimmering;
            set => isShimmering = value;
        }


        public void Stop()
        {
            if (!this.IsShimmering)
            {
                return;
            }

            this.Layer.Mask = null;
            this.IsShimmering = false;
            this.Layer.SetNeedsDisplay();
        }

        public void Start(int count = 3)
        {
            //if (this.IsShimmering)
            //{
            //    return;
            //}

            CATransaction.Begin();
            CATransaction.CompletionBlock = this.Stop;

            this.IsShimmering = true;
            gradient.Colors = new CGColor[] { darkColor, light, darkColor };
            gradient.Frame = new CGRect(-2 * this.Bounds.Size.Width, 0, 4 * this.Bounds.Size.Width, this.Bounds.Size.Height);

            gradient.StartPoint = new CGPoint(0, 0.5);
            gradient.EndPoint = new CGPoint(1, 0.5);
            gradient.Locations = new Foundation.NSNumber[] { 0.4, 0.5, 0.6 };
            animation.Duration = 1.0;
            animation.RepeatCount = count > 0 ? count : int.MaxValue;
            animation.SetTo(NSArray.FromObjects(0.0, 0.12, 0.13));
            animation.SetFrom(NSArray.FromObjects(0.6, 0.86, 1.0));
            gradient.AddAnimation(animation, shimmerKey);

            this.Layer.Mask = gradient;

            CATransaction.Commit();
        }
    }
}
