using System;

using UIKit;

using WS1IntelligenceIOS;

namespace WS1IntelligenceTestApp.iOS
{
    public partial class ErrorsViewController : UIViewController
    {
        public ErrorsViewController(IntPtr handle) : base(handle)
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

        partial void exception_handled_c_division_touchUpInside(Foundation.NSObject sender)
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

        partial void exception_unhandled_c_division_touchUpInside(Foundation.NSObject sender)
        {
            int numerator = 42;
            int denominator = 0;

            numerator /= denominator;
        }
    }
}
