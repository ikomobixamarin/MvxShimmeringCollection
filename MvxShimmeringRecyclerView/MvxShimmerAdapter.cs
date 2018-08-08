using System;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Supercharge;

namespace MvxShimmeringRecyclerView
{
    public class MvxShimmerAdapter : MvxRecyclerAdapter
    {
        public MvxShimmerAdapter()
        {
        }

        protected override View InflateViewForHolder(ViewGroup parent, int viewType, IMvxAndroidBindingContext bindingContext)
        {
            var view = base.InflateViewForHolder(parent, viewType, bindingContext);

            if (viewType == 0)
            {
                var shimmerContainer = view.FindViewById<ShimmerLayout>(Resource.Id.shimmer_root);
                shimmerContainer.SetShimmerAnimationDuration(1000);
                shimmerContainer.StartShimmerAnimation();
            }


            return view;
        }
    }
}
