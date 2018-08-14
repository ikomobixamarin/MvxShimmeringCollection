using System;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Supercharge;
using MvxShimmering;
using Java.Lang;
using Android.Support.V7.Widget;
using System.Diagnostics;

namespace MvxShimmering
{
    public class MvxShimmerAdapter : MvxRecyclerAdapter
    {
        public MvxShimmerAdapter()
        {
        }

        protected override View InflateViewForHolder(ViewGroup parent, int viewType, IMvxAndroidBindingContext bindingContext)
        {
            var view = base.InflateViewForHolder(parent, viewType, bindingContext);

            if (viewType == Constants.ShimmerPlaceholderViewType)
            {
                var shimmerContainer = view as ShimmerLayout;

                if (shimmerContainer == null)
                {
                    throw new InvalidRootViewException();
                }

                if (shimmerContainer != null)
                {
                    // TODO: make duration customizable
                    shimmerContainer.SetShimmerAnimationDuration(Constants.ShimmerAnimationDuration);
                    shimmerContainer.StartShimmerAnimation();
                }
            }

            return view;
        }

    }
}
