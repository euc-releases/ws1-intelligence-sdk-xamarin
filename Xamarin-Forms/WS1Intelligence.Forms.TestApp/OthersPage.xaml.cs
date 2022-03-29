using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WS1Intelligence.Forms.App.Model;
using Xamarin.Forms;

namespace WS1Intelligence.Forms.TestApp
{
    public partial class OthersPage : ContentPage
    {
        public ObservableCollection<MainMenuItem> Items { get; set; }

        public OthersPage()
        {
            InitializeComponent();
            //BackgroundColor = Color.Aqua;
            //Title = "Error";

            Items = new ObservableCollection<MainMenuItem>
            {
                new MainMenuItem("Leave Breadcrumb", "Leave a Bread crumb", "info"),
                new MainMenuItem("Did Crash On Last Load", "Check if appcrashed on last load", "info"),
                new MainMenuItem("Get Opt Out Status", "Get the Opt Out Status", "info"),
                new MainMenuItem("Set Opt Out Status(Toggle)", "Change the OtpOut status", "info"),
                new MainMenuItem("Update Location", "Change the Location", "info"),
                new MainMenuItem("Set Username", "Set the User name", "info"),
                new MainMenuItem("Get User UUID", "Get the User UUID", "info"),
               
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
                    case 0:// Leave Breadcrumb
                        {
                            leaveBreadcrumb();
                            break;
                        }
                    case 1: //Did crash on last load
                        {
                            bool didCrash = didCrashonLastload();
                            var str = didCrash ? "Yes" : "No";
                            await DisplayAlert(item.Title, $"Previous Session Crash Detected : {str.ToUpper()}", "OK");
                            break;
                        }
                    case 2: //Get OptOut
                        {
                            bool optOut = getOptOut();
                            var str = optOut ? "Yes" : "No";
                            await DisplayAlert(item.Title, $"Opt-out Status was : {str.ToUpper()}", "OK");
                            break;
                        }
                    case 3: //Set OptOut
                        {
                            bool optOut = getOptOut();
                            var str = optOut ? "Yes" : "No";
                            setOptOut(!optOut);
                            bool optOutToggled = getOptOut();
                            var str2 = optOutToggled ? "Yes" : "No";
                            await DisplayAlert(item.Title, $"Opt-out Status : {str.ToUpper()} and optOut Staus is : {str2.ToUpper()}  ", "OK");
                            break;
                        }
                    case 4: //Update location
                        {
                            UpdateLocation();
                            break;
                        }
                    case 5: //Set User Name
                        {
                            setUserName();
                            break;
                        }
                    case 6: // Get user uuid
                        {
                            string uuid = getUserUUID();

                            await DisplayAlert(item.Title, $"User UUID  : {uuid.ToUpper()}", "OK");
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
        private void leaveBreadcrumb()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceLeaveBreadcrumb("Xamarin Forms Bread crumb");
        }
        private bool didCrashonLastload()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            return wso.ws1IntelligenceDidCrashOnLastLoad();
        }
        private bool getOptOut()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            return wso.ws1IntelligenceGetOptOutStatus();
        }
        private void setOptOut(bool optOut)
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceSetOptOutStatus(optOut);
        }
        private void UpdateLocation()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceUpdateLocation(43.6532, -79.347015); //Toronto
        }
        private void setUserName()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceSetUsername("xamarinforms");
        }
        private string getUserUUID()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            return wso.ws1IntelligenceGetUserUUID();
        }
       
    }
}
