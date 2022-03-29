using System;

using UIKit;

using WS1IntelligenceIOS;

namespace WS1IntelligenceTestApp.iOS
{
    public partial class UserFlowsViewController : UIViewController
    {
        public UserFlowsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void user_flow_start_login_touchUpInside(Foundation.NSObject sender)
        {
            WS1Intelligence.BeginUserFlow("Xamarin Login");
        }

        partial void user_flow_end_login_touchUpInside(Foundation.NSObject sender)
        {
            WS1Intelligence.EndUserFlow("Xamarin Login");
        }

        partial void user_flow_fail_login_touchUpInside(Foundation.NSObject sender)
        {
            WS1Intelligence.FailUserFlow("Xamarin Login");
        }

        partial void user_flow_cancel_login_touchUpInside(Foundation.NSObject sender)
        {
            WS1Intelligence.CancelUserFlow("Xamarin Login");
        }
    }
}

