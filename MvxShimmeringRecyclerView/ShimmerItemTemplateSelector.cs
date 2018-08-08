using System;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvxShimmeringRecyclerView
{
    public class ShimmerItemTemplateSelector : MvxTemplateSelector<object>
    {
        private int realItemTemplateId;

        public ShimmerItemTemplateSelector(int realItemTemplateId)
        {
            this.realItemTemplateId = realItemTemplateId;
        }

        public override int GetItemLayoutId(int fromViewType)
        {
            return fromViewType == 0 ? Resource.Layout.item_shimmer : this.realItemTemplateId;
        }

        protected override int SelectItemViewType(object forItemObject)
        {
            return forItemObject is ShimmerFakePlaceHolder ?
                0 :
                1;
        }
    }
}
