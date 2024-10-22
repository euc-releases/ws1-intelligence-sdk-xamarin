# Workspace ONE Intelligence Xamarin Forms Software Development Kit (WS1Intelligence SDK)

This plugin enables access to Workspace ONE Intelligence SDK features for Xamarin Forms applications for iOS and Android.

## Installation

The SDK should be installed using **Nuget**.

- **WS1Intelligence.Forms**: This is the package to be used in your Xamarin Forms app. It will provide interfaces for the initialization, setup and usage of the Workspace ONE Intelligence module from your Xamarin Forms app.

Add this nuget package to your Xamarin.Forms project and to your iOS and Android project of the the Xamarin.Forms app as well.

Add the appropriate packages to your solution for each app project. Then continue to the [setup](#setup) step for [Android](#android) and [iOS](#ios).

## Setup

Before using the Workspace ONE SDK, just like many other Xamarin Forms packages it's dependencies need to be initialized first. In addition to adding the Forms package, each target platform needs to add the SDKs package for that specific platform as well. If you target only one of the two supported platforms, skip all steps for the one you don't support. 
For Android platform along with Workspace SDK Forms package, add the below packages if not already present
1. Xamarin.AndroidX.Preference
2. Xamarin.Google.Android.Material

## iOS
### Procedure

The Workspace ONE Intelligence Xamarin SDK must be initialized by the host application prior to use. To do so, you must call an initialization function with your valid iOS and Android app ID.

In the `AppDelegate.cs`'s `FinishedLaunching` (just where most other packages get initialized as well) add the following code 

To add the looging level
    `WS1Intelligence.Forms.iOS.WS1Intelligence.SetLoggingLevel((int)WS1IntelligenceIOS.WS1Intelligence.WS1IntelligenceLoggingLevel.Verbose);`
Initialize the Intelligence SDK
    `WS1Intelligence.Forms.iOS.WS1Intelligence.Init("YOUR_IOS_APP_ID_HERE");`.

For example like this:

    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            WS1Intelligence.Forms.iOS.WS1Intelligence.SetLoggingLevel((int)WS1IntelligenceIOS.WS1Intelligence.WS1IntelligenceLoggingLevel.Verbose);
            WS1Intelligence.Forms.iOS.WS1Intelligence.Init("YOUR_IOS_APP_ID_HERE");
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }

You should see subsequent messages in your application logs that confirms successful initialization.

## Android
### Procedure

The Workspace ONE Intelligence Xamarin SDK must be initialized by the host application prior to use. To do so, you must call an initialization function with your valid iOS and Android app ID.

In the `MainActivity.cs`'s `OnCreate` (just where most other packages get initialized as well) add the following code
To add the looging level
    `Android.WS1Intelligence.SetLoggingLevel(Android.WS1Intelligence.LogLevel.Verbose);`
and Region lookup in Configuration object
    `Android.WS1Intelligence.region = Android.WS1Intelligence.RegionLookup.Staging;`
Initialize the Crittercism SDk
    `Android.WS1Intelligence.Init(this,"YOUR_IOS_APP_ID_HERE",config);`.
And to Log Crashes/Unhandled Exception add
    ` WS1Intelligence.Forms.Android.WS1Intelligence.Instance.ws1IntelligenceLogUnhandledException(newExc);`

For example like this:

    [Activity(Label = "WS1Intelligence.Forms.App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
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

You should see subsequent messages in your application logs that confirms successful initialization.



### Functions

The Workspace ONE Intelligence Xamarin Forms SDK exposes the native interface of both the Android and iOS SDKs to Xamarin Forms applications.


#### Handle Exception : Logs a handled exception. Parameter is an exception. Use this method when a C# exception is caught in code.


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

#### UnHandle Exception :

Logs an unhandled exception. Parameter is an exception. This method is used for exceptions that were not caught in application code. SDK does this automatically for you no code required to add.

    private void unHandledException()
    {
        int numerator = 42;
        int denominator = 0;
        numerator /= denominator;
    }

#### Log Network Request

Logs details of a network request transaction.

    private void logNetworkRequest()
    {
        Com.Crittercism.App.Crittercism.LogNetworkRequest("GET", new Java.Net.URL("https://www.google.ca"), 1, 342, 77, 202, null);
    }

#### Log User Flows:
  
Starts a user flow with the provided name. Parameter is a string.

    private void beginUserFlow()
    {
        var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
        wso.ws1IntelligenceBeginUserFlow("Forms user flow");
    }

Ends successfully a user flow with the provided name. Parameter is a string.

    private void endUserFlow()
     {
         var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
         wso.ws1IntelligenceEndUserFlow("Forms user flow");
     }

Fails a user flow with the provided name. Parameter is a string.

    private void failUserFlow()
    {
        var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
        wso.ws1IntelligenceFailUserFlow("Forms user flow");
    }

Cancels a user flow with the provided name. Parameter is a string.

    private void cancelUserFlow()
        {
            var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
            wso.ws1IntelligenceCancelUserFlow("Forms user flow");
        }

#### Log Bread Crumb events:

Logs a breadcrumb. Parameter is a string.

    private void leaveBreadcrumb()
    {
        var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
        wso.ws1IntelligenceLeaveBreadcrumb("Xamarin Forms Bread crumb");
    }

#### Did Crash on Last laod :

Checks if the previous session ended in a crashed state. Crash information is returned via a callback provided by the caller.

	private bool didCrashonLastload()
    {
        var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
        return wso.ws1IntelligenceDidCrashOnLastLoad();
    }

#### Get or Enable or disable opt out :


Get the current opt-out status. Status is returned via a callback provided by the caller.

	private bool getOptOut()
    {
         var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
         return wso.ws1IntelligenceGetOptOutStatus();
    }

Enable or disable opt out, which prevents any data from being logged.

	private void setOptOut(bool optOut)
    {
         var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
         wso.ws1IntelligenceSetOptOutStatus(!optOut);
    }

#### Log Location:

Logs current device location.

    private void UpdateLocation()
    {
        var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
        wso.ws1IntelligenceUpdateLocation(37.7749, -122.431297); 
    }

#### Set Current User:

Sets a username which is affiliated with all following events. Parameter is a string.

	private void setUserName()
    {
        var wso = DependencyService.Get<IWSIntelligence>().SharedInstance;
        wso.ws1IntelligenceSetUsername("xamarinforms");
    }

