using System;
using CoreGraphics;
using UIKit;
using CoreAnimation;
using Foundation;
using System.ComponentModel;

namespace MvxShimmering
{
    [Register("ShimmeringView", IsWrapper = false), DesignTimeVisible(true)]
    public class ShimmeringView : UIView
    {
        public class ShimmeringViewAppearance : UIViewAppearance
        {
            protected internal ShimmeringViewAppearance(IntPtr handle)
                : base(handle)
            {

            }
        }

        public ShimmeringView(IntPtr handle)
           : base(handle)
        {

        }

        public bool IsShimmering
        {
            get
            {
                return this.Layer.Mask != null;
            }
        }

        public CGColor LightColor
        {
            get;
            set;
        }

        public CGColor DarkColor
        {
            get;
            set;
        }

        public void Stop()
        {
            this.Layer.Mask = null;
            this.Layer.SetNeedsDisplay();
        }

        public void Start(int count = 3)
        {
            CATransaction.Begin();
            CATransaction.CompletionBlock = this.Stop;

            this.Layer.Mask = ShimmerAnimationHelper.BuildShimmeringGradient(
                                  this.Bounds,
                                  count);

            CATransaction.Commit();
        }
    }
}
