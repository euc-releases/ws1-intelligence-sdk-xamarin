using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using WS1IntelligenceTestAppAndroid.Fragments;

namespace WS1IntelligenceTestAppAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       
        BottomNavigationView navigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            initializeCrittercism();
            exceptionHandling();
            navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.navigation_error);
        }


        private void initializeCrittercism()
        {

            Com.Crittercism.App.Crittercism.SetLoggingLevel(loggingLevel: Com.Crittercism.App.Crittercism.LoggingLevel.Debug);
            Com.Crittercism.App.CrittercismConfig crittercismConfig = new Com.Crittercism.App.CrittercismConfig();
            crittercismConfig.RegionLookup = Com.Crittercism.App.Crittercism.Region.Staging;
            Com.Crittercism.App.Crittercism.Initialize(this, "YOUR APP ID", crittercismConfig);

        }

        private void exceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

        }

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var newExc = new Exception("TaskSchedulerOnUnobservedTaskException", unobservedTaskExceptionEventArgs.Exception);
            Com.Crittercism.App.Crittercism.LogPluginCrashException(newExc.Message, WS1IntelligenceAndroid.WS1Intelligence.StackTrace(newExc), 1);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var newExc = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);
            Com.Crittercism.App.Crittercism.LogPluginCrashException(newExc.Message, WS1IntelligenceAndroid.WS1Intelligence.StackTrace(newExc), 1);
        }


        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
            AndroidX.Fragment.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.navigation_error:
                    fragment = ErrorFragment.NewInstance();
                    break;
                case Resource.Id.navigation_userflow:
                    fragment = UserflowFragment.NewInstance();
                    break;
                case Resource.Id.navigation_network:
                    fragment = NetworkFragment.NewInstance();
                    break;
                case Resource.Id.navigation_others:
                    fragment = OthersFragment.NewInstance();
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
       
       

    }
}

