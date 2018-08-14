using System;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvxShimmering
{
    public class ShimmerItemTemplateSelector : MvxTemplateSelector<object>
    {
        private int realItemTemplateId;
        private int shimmerTemplateId;
        private IMvxTemplateSelector templateSelector;
        private bool hasTemplateSelector;

        public ShimmerItemTemplateSelector(int realItemTemplateId, int shimmerTemplateId)
            : this(shimmerTemplateId)
        {
            this.realItemTemplateId = realItemTemplateId;
        }

        public ShimmerItemTemplateSelector(IMvxTemplateSelector templateSelector, int shimmerTemplateId)
            : this(shimmerTemplateId)
        {
            this.templateSelector = templateSelector;
            this.hasTemplateSelector = true;
        }

        private ShimmerItemTemplateSelector(int shimmerTemplateId)
        {
            this.shimmerTemplateId = shimmerTemplateId;
        }

        public override int GetItemLayoutId(int fromViewType)
        {
            if (this.hasTemplateSelector)
            {
                return fromViewType == Constants.ShimmerPlaceholderViewType ?
                                    this.shimmerTemplateId :
                                    this.templateSelector.GetItemLayoutId(fromViewType);
            }
            else
            {
                return fromViewType == Constants.ShimmerPlaceholderViewType ?
                                           this.shimmerTemplateId :
                                           this.realItemTemplateId;
            }
        }

        protected override int SelectItemViewType(object forItemObject)
        {
            if (this.hasTemplateSelector)
            {
                return forItemObject is ShimmerFakePlaceHolder ?
                    Constants.ShimmerPlaceholderViewType :
                    this.templateSelector.GetItemViewType(forItemObject);
            }
            else
            {
                return forItemObject is ShimmerFakePlaceHolder ?
                          Constants.ShimmerPlaceholderViewType :
                          1;
            }
        }
    }
}
