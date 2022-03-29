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
	[Register ("NetworkViewController")]
	partial class NetworkViewController
	{
		[Outlet]
		UIKit.UIButton network_error_manual { get; set; }

		[Outlet]
		UIKit.UIButton network_event_manual { get; set; }

		[Action ("network_error_manual_touchUpInside:")]
		partial void network_error_manual_touchUpInside (Foundation.NSObject sender);

		[Action ("network_event_manual_touchUpInside:")]
		partial void network_event_manual_touchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (network_event_manual != null) {
				network_event_manual.Dispose ();
				network_event_manual = null;
			}

			if (network_error_manual != null) {
				network_error_manual.Dispose ();
				network_error_manual = null;
			}
		}
	}
}
