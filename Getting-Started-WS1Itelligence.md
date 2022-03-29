# VMware Workspace ONE Intelligence Xamarin Software Development Kit (WS1Intelligence SDK)

This plugin enables access to Workspace ONE Intelligence Xamarin SDK features for Xamarin Native applications for iOS and Android.

# License

By integrating or downloading the software development kit (SDK) you accept the [VMware License](https://vdc-download.vmware.com/vmwb-repository/dcr-public/77d50615-6a61-4704-be18-30e8d9bac6ac/75789b6e-1ae4-4716-ab46-c6ce48b155fe/VMware%20Workspace%20ONE%20Intelligence%20SDK%20Software%20Development%20Kit%20License%20Agreement.pdf)

## iOS Overview

In order to inject Workspace ONE Intelligence Xamarin SDK functionality into your  Xamarin Intelligence App, integrate the two systems.

### Requirements

* iOS 12.0+
* Visual Studio 2019 (16.10 and above) for Windows / Visual Studio 2019 for Mac (8.10 and above)
* The Workspace ONE Xamarin SDK (WS1Intelligence) package from the Nuget Store.
* A Xamarin iOS app to integrate with the Workspace ONE Intelligence SDK
** If you do not have a suitable application, you can create a new application in Visual Studio and integrate the SDK into that.


### Installation
------------

In your application Packages(Right Click)->Manage Nuget Package...->Seacrh WS1Intelligence->Select Latest Version->Add Package

### iOS Implementation

### Initialization
--------------

The Workspace ONE Intelligence Xamarin SDK must be initialized by the host application prior to use. To do so, you must call an initialization function with your valid iOS and Android app ID.

In the `AppDelegate.cs`'s `FinishedLaunching` (just where most other packages get initialized as well) add the following code `WS1Intelligence.Init("YOUR_IOS_APP_ID_HERE");`. 

For example like this:

using WS1IntelligenceIOS;

	public class AppDelegate : UIResponder, IUIApplicationDelegate
	{

		[Export("window")]
		public UIWindow Window { get; set; }

		[Export("application:didFinishLaunchingWithOptions:")]
		public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			WS1Intelligence.SetLoggingLevel(WS1Intelligence.WS1IntelligenceLoggingLevel.Verbose); // Logging
			WS1Intelligence.Init("YOUR_IOS_APP_ID_HERE");

			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method
			return true;
		}

		...
	}

You should see subsequent messages in your application logs that confirms successful initialization.

### Functions
---------

The Workspace ONE Intelligence Xamarin SDK exposes the native interface of both the Android and iOS SDKs to Xamarin applications.

#### Handle Exception :

Logs a handled exception. Parameter is an exception. Use this method when a C# exception is caught in code.

    partial void exception_handled_c_division_touchUpInside()
    {
        int numerator = 42;
        int denominator = 0;

        try
        {
            numerator /= denominator;
        }
        catch (Exception e)
        {
            WS1Intelligence.LogHandledException(e);
        }
        finally
        {

        }
    }

#### UnHandle Exception :

Logs an unhandled exception. Parameter is an exception. This method is used for exceptions that were not caught in application code. SDK does this automatically for you no code required to add.

    partial void exception_unhandled_c_division_touchUpInside()
    {
         int numerator = 42;
         int denominator = 0;

         numerator /= denominator;
    }

#### Log Network Request

Logs details of a network request transaction.

    partial void network_error_manual_touchUpInside()
    {
	    WS1Intelligence.LogNetworkRequest("GET", "https://www.google.ca", 1.22, 342, 77, 202, (IntPtr)null);
    }

#### Log User Flows:

Starts a user flow with the provided name. Parameter is a string.

    partial void user_flow_start_login_touchUpInside()
    {
        WS1Intelligence.BeginUserFlow("Xamarin Login");
    }

Ends successfully a user flow with the provided name. Parameter is a string.

    partial void user_flow_end_login_touchUpInside()
    {
        WS1Intelligence.EndUserFlow("Xamarin Login");
    }

Fails a user flow with the provided name. Parameter is a string.

    partial void user_flow_fail_login_touchUpInside()
    {
        WS1Intelligence.FailUserFlow("Xamarin Login");
    }

Cancels a user flow with the provided name. Parameter is a string.

    partial void user_flow_cancel_login_touchUpInside()
    {
        WS1Intelligence.CancelUserFlow("Xamarin Login");
    }

#### Log Bread Crumb events:

Logs a breadcrumb. Parameter is a string.

    partial void breadcrumb_xamarin_touchUpInside()
	{
		WS1Intelligence.LeaveBreadcrumb("Xamarin breadcrumb");
	}

#### Set Flag to Asynchronously Log Bread Crumb events:

Toggles asynchronous breadcrumb logging mode. Parameter is a boolean value. By default, breadcrumbs are flushed to disk synchronously to help ensure an accurate record prior to a potential crash. For performance reasons, an application may prefer to use asynchronous logging.

	partial void breadcrumb_async_touchUpInside()
	{
		WS1Intelligence.SetAsyncBreadcrumbMode(true);
	}

#### Did Crash on Last laod :

Checks if the previous session ended in a crashed state. Crash information is returned via a callback provided by the caller.

	partial void didCrashOnLastLoad_touchUpInside()
	{
		bool didCrashOnLastLoad = WS1Intelligence.DidCrashOnLastLoad();

		var alertController = UIAlertController.Create("Previous Session Crash Detected", didCrashOnLastLoad ? "true" : "false", UIAlertControllerStyle.Alert);

		alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

		PresentViewController(alertController, true, null);
	}

#### Get or Enable or disable opt out :


Get the current opt-out status. Status is returned via a callback provided by the caller.

	partial void optout_get_touchUpInside()
	{
		bool status = WS1Intelligence.GetOptOutStatus();

		var alertController = UIAlertController.Create("Opt-out Status", status ? "true" : "false", UIAlertControllerStyle.Alert);

		alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

		PresentViewController(alertController, true, null);
	}

Enable or disable opt out, which prevents any data from being logged.

	partial void optout_toggle_touchUpInside()
	{
		bool currentStatus = WS1Intelligence.GetOptOutStatus();

		WS1Intelligence.SetOptOutStatus(!currentStatus);

		var alertController = UIAlertController.Create("Opt-out Status:", !currentStatus  ? "true" : "false", UIAlertControllerStyle.Alert);

		alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

		PresentViewController(alertController, true, null);
	}

#### Log Location:

Logs current device location.

	partial void set_location_sf_touchUpInside()
	{
		WS1Intelligence.UpdateLocation(37.7749, -122.431297);
	}

	partial void set_location_toronto_touchUpInside()
	{
		WS1Intelligence.UpdateLocation(43.6532, -79.347015);
	}

#### Set Current User:

Sets a username which is affiliated with all following events. Parameter is a string.

	partial void set_username_xamarin_touchUpInside()
	{
		WS1Intelligence.SetUsername("xamarin");
	}

#### Get User UUID:

Get the Workspace ONE Intelligence UUID for the current device. UUID is returned via a callback provided by the caller.

	partial void uuid_get_touchUpInside()
	{
		string uuid = WS1Intelligence.GetUserUUID();

		var alertController = UIAlertController.Create("User UUID", uuid, UIAlertControllerStyle.Alert);

		alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

		PresentViewController(alertController, true, null);
	}


## Android Overview

To integrate Workspace ONE Android Intelligence SDK Xamarin components into an existing Xamarin Android app follow described steps.

### Requirements

* Visual Studio 2019 (16.910 and above) for Windows / Visual Studio 2019 for Mac (8.10 and above)
* The Workspace ONE Xamarin SDK (WS1Intelligence) package from the Nuget Store.
* Xamarin Android app to integrate with the Workspace ONE Intelligence SDK targeting Android 6.0+ / API Level 23+.
** If you do not have a suitable application, you can create a new application in Visual Studio and integrate the SDK into that.

### Installation
------------

In your application Packages(Right Click)->Manage Nuget Package...->Seacrh WS1Intelligence->Select Latest Version->Add Package

## Android Implementation

### Initialization
--------------

The Workspace ONE Intelligence Xamarin SDK must be initialized by the host application prior to use. To do so, you must call an initialization function with your valid iOS and Android app ID.

In the `MainActivity.cs`'s `OnCreate` (just where most other packages get initialized as well) add the following code
To add the looging level
    `Com.Crittercism.App.Crittercism.SetLoggingLevel(loggingLevel: Com.Crittercism.App.Crittercism.LoggingLevel);`
and Region lookup in Configuration object
    `Com.Crittercism.App.CrittercismConfig crittercismConfig = new Com.Crittercism.App.CrittercismConfig();`
    `crittercismConfig.RegionLookup = Com.Crittercism.App.Crittercism.Region.Staging;`
Initialize the Crittercism SDk
    `Com.Crittercism.App.Crittercism.Initialize("YOUR_IOS_APP_ID_HERE",config);`.
And to Log Crashes/Unhandled Exception add
    `Com.Crittercism.App.Crittercism.LogPluginCrashException(newExc.Message, WS1IntelligenceAndroid.WS1Intelligence.StackTrace(newExc), 1);`
Complete code may look like this: 
    public class MainActivity : AppCompatActivity
    {
	    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Initialize Crittercism 
            initializeCrittercism();

            //Add Exception handling for Crittercism
            exceptionHandling();

            ...
        }

        private void initializeCrittercism()
        {

            Com.Crittercism.App.Crittercism.SetLoggingLevel(loggingLevel: Com.Crittercism.App.Crittercism.LoggingLevel.Debug);
            Com.Crittercism.App.CrittercismConfig crittercismConfig = new Com.Crittercism.App.CrittercismConfig();
            crittercismConfig.RegionLookup = Com.Crittercism.App.Crittercism.Region.Staging;
            Com.Crittercism.App.Crittercism.Initialize(this, "3b2758fac0314624b2aa236181bdc64a00555305", crittercismConfig);

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

        ...
    }

You should see subsequent messages in your application logs that confirms successful initialization.

### Functions
---------

The Workspace ONE Intelligence Xamarin SDK exposes the native interface of both the Android and iOS SDKs to Xamarin applications.

#### Handle Exception : Logs a handled exception. Parameter is an exception. Use this method when a C# exception is caught in code.

     private void logHandledException()
     {
        try
        {
            int[] array = new int[1];
            int arr = array[2];
        }
        catch (Exception handledException)
        {
            Com.Crittercism.App.Crittercism.LogPluginException(handledException.GetType().FullName, handledException.Message, WS1IntelligenceAndroid.WS1Intelligence.StackTrace(handledException), 1);
        }
     }

#### UnHandle Exception :

Logs an unhandled exception. Parameter is an exception. This method is used for exceptions that were not caught in application code. See the Initialization section for catching uncaught exception.

    private void logUnHandledException()
    {
            int[] array = new int[1];
            int arr = array[2];
    }

#### Log Network Request

Logs details of a network request transaction.

    private void logNetworkRequest()
    {
        Com.Crittercism.App.Crittercism.LogNetworkRequest("GET", new Java.Net.URL("https://www.google.ca"), 1, 342, 77, 202, null);
    }

#### Log User Flows:

Starts a user flow with the provided name. Parameter is a string.

    private void logBeginUserFlow()
    {
        Com.Crittercism.App.Crittercism.BeginUserFlow("Xamarin Native Flow");
    }

Ends successfully a user flow with the provided name. Parameter is a string.

    private void logEndUserFlow()
    {
        Com.Crittercism.App.Crittercism.EndUserFlow("Xamarin Native Flow");
    }

Fails a user flow with the provided name. Parameter is a string.

    private void logFailUserFlow()
    {
        Com.Crittercism.App.Crittercism.FailUserFlow("Xamarin Native Flow");
    }

Cancels a user flow with the provided name. Parameter is a string.

    private void logCancelUserFlow()
    {
        Com.Crittercism.App.Crittercism.CancelUserFlow("Xamarin Native Flow");
    }

#### Log Bread Crumb events:

Logs a breadcrumb. Parameter is a string.

    private void logBreadcrumb()
        {
            Com.Crittercism.App.Crittercism.LeaveBreadcrumb("Xamarin Android");
        }

#### Did Crash on Last laod :

Checks if the previous session ended in a crashed state. Crash information is returned via a callback provided by the caller.

	partial void didCrashOnLastLoad_touchUpInside()
	{
		bool didCrashOnLastLoad = WS1Intelligence.DidCrashOnLastLoad();

		var alertController = UIAlertController.Create("Previous Session Crash Detected", didCrashOnLastLoad ? "true" : "false", UIAlertControllerStyle.Alert);

		alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

		PresentViewController(alertController, true, null);
	}

#### Get or Enable or disable opt out :


Get the current opt-out status. Status is returned via a callback provided by the caller.

	partial void optout_get_touchUpInside()
	{
		bool status = WS1Intelligence.GetOptOutStatus();

		var alertController = UIAlertController.Create("Opt-out Status", status ? "true" : "false", UIAlertControllerStyle.Alert);

		alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

		PresentViewController(alertController, true, null);
	}

Enable or disable opt out, which prevents any data from being logged.

	partial void optout_toggle_touchUpInside()
	{
		bool currentStatus = WS1Intelligence.GetOptOutStatus();

		WS1Intelligence.SetOptOutStatus(!currentStatus);

		var alertController = UIAlertController.Create("Opt-out Status:", !currentStatus  ? "true" : "false", UIAlertControllerStyle.Alert);

		alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

		PresentViewController(alertController, true, null);
	}

#### Log Location:

Logs current device location.

	private void setlocationSF()
    {
        Location loc = new Location("");
        loc.Latitude = 37.7749;
        loc.Longitude = -122.431297;
        Com.Crittercism.App.Crittercism.UpdateLocation(loc);
    }

#### Set Current User:

Sets a username which is affiliated with all following events. Parameter is a string.

	private void setUser()
    {
        Com.Crittercism.App.Crittercism.SetUsername("Xamarin User");
    }


