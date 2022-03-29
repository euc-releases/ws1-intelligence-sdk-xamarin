using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WS1Intelligence.Forms.App.Model;
using Xamarin.Forms;

namespace WS1Intelligence.Forms.TestApp
{
    public partial class NetworkPage : ContentPage
    {
        public ObservableCollection<MainMenuItem> Items { get; set; }

        public NetworkPage()
        {
            InitializeComponent();
            //BackgroundColor = Color.Aqua;
            //Title = "Error";

            Items = new ObservableCollection<MainMenuItem>
            {
                new MainMenuItem("Network Event", "Network Event Log", "encryption"),
                new MainMenuItem("Network Error", "Network Error Log", "info")
            };

            ListView.ItemsSource = Items;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            if (sender is ListView listView && listView.SelectedItem is MainMenuItem item)
            {
                var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
                switch (Items.IndexOf(item))
                {
                    case 0:// network request
                        {
                            networkRequest();
                            break;

                        }
                    case 1:// network error
                        {
                            networkError();
                            break;

                        }
                    default:
                        {
                            await DisplayAlert(item.Title, $"The {item.Title.ToLower()} feature is not yet available in the example app", "OK");
                            break;
                        }
                }

            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void networkRequest()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceLogNetworkRequest("GET", "https://www.google.ca", 1, 342, 77, 202, (IntPtr)null);
        }
        private void networkError()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceLogNetworkRequest("GET", "https://www.google.ca", 1, 342, 77, 202, (IntPtr)null);
        }
    }
}
