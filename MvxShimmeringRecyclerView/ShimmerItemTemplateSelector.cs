using System;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvxShimmering
{
    public class ShimmerItemTemplateSelector : MvxTemplateSelector<object>
    {
        private int realItemTemplateId;
        private int shimmerTemplateId;

        public ShimmerItemTemplateSelector(int realItemTemplateId, int shimmerTemplateId)
        {
            this.realItemTemplateId = realItemTemplateId;
            this.shimmerTemplateId = shimmerTemplateId;
        }

        public override int GetItemLayoutId(int fromViewType)
        {
            return fromViewType == Constants.ShimmerPlaceholderViewType ?
                                            this.shimmerTemplateId :
                                            this.realItemTemplateId;
        }

        protected override int SelectItemViewType(object forItemObject)
        {
            return forItemObject is ShimmerFakePlaceHolder ?
                Constants.ShimmerPlaceholderViewType :
                1;
        }
    }
}
