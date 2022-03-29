// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WS1IntelligenceTestApp.iOS
{
	[Register ("UserFlowsViewController")]
	partial class UserFlowsViewController
	{
		[Outlet]
		UIKit.UIButton user_flow_cancel_login { get; set; }

		[Outlet]
		UIKit.UIButton user_flow_end_login { get; set; }

		[Outlet]
		UIKit.UIButton user_flow_fail_login { get; set; }

		[Outlet]
		UIKit.UIButton user_flow_start_login { get; set; }

		[Action ("user_flow_cancel_login_touchUpInside:")]
		partial void user_flow_cancel_login_touchUpInside (Foundation.NSObject sender);

		[Action ("user_flow_end_login_touchUpInside:")]
		partial void user_flow_end_login_touchUpInside (Foundation.NSObject sender);

		[Action ("user_flow_fail_login_touchUpInside:")]
		partial void user_flow_fail_login_touchUpInside (Foundation.NSObject sender);

		[Action ("user_flow_start_login_touchUpInside:")]
		partial void user_flow_start_login_touchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (user_flow_start_login != null) {
				user_flow_start_login.Dispose ();
				user_flow_start_login = null;
			}

			if (user_flow_end_login != null) {
				user_flow_end_login.Dispose ();
				user_flow_end_login = null;
			}

			if (user_flow_fail_login != null) {
				user_flow_fail_login.Dispose ();
				user_flow_fail_login = null;
			}

			if (user_flow_cancel_login != null) {
				user_flow_cancel_login.Dispose ();
				user_flow_cancel_login = null;
			}
		}
	}
}
