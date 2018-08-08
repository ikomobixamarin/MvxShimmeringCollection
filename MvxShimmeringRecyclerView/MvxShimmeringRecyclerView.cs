using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using MvvmCross.Droid.Support.V7.RecyclerView;
using System.Collections;
using MvxShimmeringRecyclerView;
using System.Diagnostics;
using System.Collections.Generic;

namespace Shimmering
{
    [Register("shimmering.MvxShimmeringRecyclerView")]
    public class MvxShimmeringRecyclerView : MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView
    {
        private int itemTemplateId;

        public new IEnumerable ItemsSource
        {
            get
            {
                return base.ItemsSource;
            }
            set
            {
                var itemsToBind = value;

                // If the data-source is null, display fake shimmer items
                if (itemsToBind == null)
                {
                    itemsToBind = new List<ShimmerFakePlaceHolder>
                    {
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder(),
                        new ShimmerFakePlaceHolder()
                    };

                    System.Diagnostics.Debug.WriteLine("Set MvxShimmeringAdapter");
                }

                base.ItemsSource = itemsToBind;
            }
        }


        public MvxShimmeringRecyclerView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            this.ItemTemplateSelector = new ShimmerItemTemplateSelector(this.ItemTemplateId);
        }

        public MvxShimmeringRecyclerView(Context context, IAttributeSet attrs) : this(context, attrs, 0, new MvxShimmerAdapter())
        {
        }

        public MvxShimmeringRecyclerView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            this.ItemTemplateSelector = new ShimmerItemTemplateSelector(this.ItemTemplateId);
        }

        public MvxShimmeringRecyclerView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter) : base(context, attrs, defStyle, adapter)
        {
            this.ItemTemplateSelector = new ShimmerItemTemplateSelector(this.ItemTemplateId);
            this.ItemsSource = null;
        }
    }
}
