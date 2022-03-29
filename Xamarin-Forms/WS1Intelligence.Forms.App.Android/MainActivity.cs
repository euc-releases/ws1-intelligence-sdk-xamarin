using System;

using Android.App;
//using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using Android.Content.PM;
using System.Threading.Tasks;

namespace WS1Intelligence.Forms.TestApp.Droid
{
    [Activity(Label = "WS1Intelligence.Forms.TestApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Initialize WS1Intelligence 
            initializeWS1Intelligence();

            //Add Exception handling for Crittercism
            exceptionHandling();
 
            LoadApplication(new App());
        }

        private void initializeWS1Intelligence()
        {
            Android.WS1Intelligence.SetLoggingLevel(Android.WS1Intelligence.LogLevel.Verbose);
            Android.WS1Intelligence.region = Android.WS1Intelligence.RegionLookup.Staging;
            Android.WS1Intelligence.Init(this, "3b2758fac0314624b2aa236181bdc64a00555305");
        }

        private void exceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }
        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Console.WriteLine("CurrentDomainOnUnhandledException");
            var newExc = new Exception("CurrentDomainOnUnhandledException", unhandledExceptionEventArgs.ExceptionObject as Exception);
            WS1Intelligence.Forms.Android.WS1Intelligence.Instance.ws1IntelligenceLogUnhandledException(newExc);
             }

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            Console.WriteLine("TaskSchedulerOnUnobservedTaskException");
            var newExc = new Exception("TaskSchedulerOnUnobservedTaskException", unobservedTaskExceptionEventArgs.Exception);
            WS1Intelligence.Forms.Android.WS1Intelligence.Instance.ws1IntelligenceLogUnhandledException(newExc);
         }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
