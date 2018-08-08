using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using MvvmCross.Droid.Support.V7.RecyclerView;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

namespace MvxShimmering
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

        public int MvxShimmerTemplateId
        {
            get;
            private set;
        }

        public MvxShimmeringRecyclerView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxShimmeringRecyclerView(Context context, IAttributeSet attrs) : this(context, attrs, 0, new MvxShimmerAdapter())
        {
        }

        public MvxShimmeringRecyclerView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public MvxShimmeringRecyclerView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter) : base(context, attrs, defStyle, adapter)
        {
            Android.Content.Res.TypedArray a = context.ObtainStyledAttributes(
                attrs,
                MvxShimmering.Resource.Styleable.MvxShimmeringRecyclerView,
                defStyle,
                0);

            this.MvxShimmerTemplateId = a.GetResourceId(MvxShimmering.Resource.Styleable.MvxShimmeringRecyclerView_MvxShimmerTemplateId, -1);

            if (this.MvxShimmerTemplateId == -1)
            {
                throw new ArgumentNullException($"You must provide a value for the {nameof(MvxShimmering.Resource.Styleable.MvxShimmeringRecyclerView_MvxShimmerTemplateId)} attribute");
            }

            this.ItemTemplateSelector = new ShimmerItemTemplateSelector(this.ItemTemplateId, this.MvxShimmerTemplateId);
            this.ItemsSource = null;
        }
    }
}
