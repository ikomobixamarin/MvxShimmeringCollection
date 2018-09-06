using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using MvxShimmeringCollection.Shared;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvxShimmering;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvxShimmeringCollection.Droid
{
    [Activity(Label = "MvxShimmeringCollection", Icon = "@mipmap/icon", Theme = "@style/AppTheme")]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var recyclerView = this.FindViewById<MvxShimmeringRecyclerView>(Resource.Id.recyclerview);

            recyclerView.ItemTemplateSelector = new TemplateSelector();
        }

        private class TemplateSelector : MvxTemplateSelector<string>
        {
            public override int GetItemLayoutId(int fromViewType)
            {
                return fromViewType == 1 ?
                    Resource.Layout.list_item :
                    Resource.Layout.list_item_2;
            }

            protected override int SelectItemViewType(string forItemObject)
            {
                return forItemObject.EndsWith("0") || forItemObject.EndsWith("1") || forItemObject.EndsWith("2") ?
                                    1 :
                                    2;
            }
        }
    }
}

