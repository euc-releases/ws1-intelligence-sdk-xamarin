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
	[Register ("ErrorsViewController")]
	partial class ErrorsViewController
	{
		[Outlet]
		UIKit.UIButton exception_handled_c_division { get; set; }

		[Outlet]
		UIKit.UIButton exception_unhandled_c_division { get; set; }

		[Action ("exception_handled_c_division_touchUpInside:")]
		partial void exception_handled_c_division_touchUpInside (Foundation.NSObject sender);

		[Action ("exception_unhandled_c_division_touchUpInside:")]
		partial void exception_unhandled_c_division_touchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (exception_handled_c_division != null) {
				exception_handled_c_division.Dispose ();
				exception_handled_c_division = null;
			}

			if (exception_unhandled_c_division != null) {
				exception_unhandled_c_division.Dispose ();
				exception_unhandled_c_division = null;
			}
		}
	}
}
