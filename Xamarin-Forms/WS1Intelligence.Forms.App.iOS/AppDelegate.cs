using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using WS1Intelligence.Forms.iOS;
namespace WS1Intelligence.Forms.TestApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            WS1Intelligence.Forms.iOS.WS1Intelligence.SetLoggingLevel((int)WS1IntelligenceIOS.WS1Intelligence.WS1IntelligenceLoggingLevel.Verbose);
            WS1Intelligence.Forms.iOS.WS1Intelligence.Init("YOUR APP ID");
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
