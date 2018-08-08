using System;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MvxShimmeringCollection.Shared
{
    public class MainViewModel : MvxViewModel
    {
        private List<string> items;

        public List<string> Items
        {
            get => this.items;
            set => this.SetProperty(ref this.items, value);
        }

        public MainViewModel()
        {
        }

        public async override Task Initialize()
        {
            base.Initialize();

            this.FakeLoad();
        }

        private async Task FakeLoad()
        {
            // Simulate long-running webservice call
            await Task.Delay(5000).ConfigureAwait(false);

            // Should be your ViewModels
            this.Items = new List<string>
            {
                "item 1",
                "item 2",
                "item 3",
                "item 4",
                "item 5",
                "item 6",
                "item 7",
                "item 8",
                "item 9",
                "item 10",
                "item 11",
                "item 12",
                "item 13"
            };
        }
    }
}
