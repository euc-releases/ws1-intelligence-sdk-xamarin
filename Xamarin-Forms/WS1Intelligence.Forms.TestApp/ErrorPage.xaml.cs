using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WS1Intelligence.Forms.App.Model;
using Xamarin.Forms;

namespace WS1Intelligence.Forms.TestApp
{
    public partial class ErrorPage : ContentPage
    {
        public ObservableCollection<MainMenuItem> Items { get; set; }

        public ErrorPage()
        {
            InitializeComponent();
            //BackgroundColor = Color.Aqua;
            //Title = "Error";

            Items = new ObservableCollection<MainMenuItem>
            {
                new MainMenuItem("Handled Exception", "Log Handle Exception", "error"),
                new MainMenuItem("UnHandled Exception", "Log UnHandled Exception", "error"),
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
                    case 0: // handled exception
                        {
                            handledException();
                            break;

                        }
                    case 1: //un haNDLED EXCEPTION
                        {
                            unHandledException();
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
       
        private void handledException()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            int numerator = 42;
            int denominator = 0;

            try
            {
                numerator /= denominator;
            }
            catch (Exception ex)
            {
                wso.ws1IntelligenceLogHandledException(ex);
            }
        }
        private void unHandledException()
        {
            int numerator = 42;
            int denominator = 0;
            numerator /= denominator;
        }
    }
 }
