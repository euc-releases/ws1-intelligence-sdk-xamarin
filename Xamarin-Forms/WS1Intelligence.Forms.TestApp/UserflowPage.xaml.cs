using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WS1Intelligence.Forms.App.Model;
using Xamarin.Forms;

namespace WS1Intelligence.Forms.TestApp
{
    public partial class UserflowPage : ContentPage
    {
        public ObservableCollection<MainMenuItem> Items { get; set; }

        public UserflowPage()
        {
            InitializeComponent();
            //BackgroundColor = Color.Aqua;
            //Title = "Error";

            Items = new ObservableCollection<MainMenuItem>
            {
                new MainMenuItem("Begin User Flow", "Event for Begin User Flow", "tunneling"),
                new MainMenuItem("End User Flow", "Event for End User Flow", "tunneling"),
                new MainMenuItem("Fail User Flow", "Event for Fail User Flow", "authentication"),
                new MainMenuItem("Cancel User Flow", "Event for Cancel User Flow", "instrumentation")
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
                    
                    case 0: //begin user flow
                        {
                            beginUserFlow();
                            break;
                        }
                    case 1: // end user flow
                        {
                            endUserFlow();
                            break;
                        }
                    case 2: // fail user flow
                        {
                            failUserFlow();
                            break;
                        }
                    case 3: // cancel user flow
                        {
                            cancelUserFlow();
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
       
        private void beginUserFlow()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceBeginUserFlow("Forms user flow");
        }
        private void endUserFlow()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceEndUserFlow("Forms user flow");
        }
        private void failUserFlow()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceFailUserFlow("Forms user flow");
        }
        private void cancelUserFlow()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceCancelUserFlow("Forms user flow");
        }
        
    }
}
