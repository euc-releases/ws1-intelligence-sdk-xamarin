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
	[Register ("OtherViewController")]
	partial class OtherViewController
	{
		[Outlet]
		UIKit.UIButton breadcrumb_async { get; set; }

		[Outlet]
		UIKit.UIButton breadcrumb_xamarin { get; set; }

		[Outlet]
		UIKit.UIButton didCrashOnLastLoad { get; set; }

		[Outlet]
		UIKit.UIButton optout_get { get; set; }

		[Outlet]
		UIKit.UIButton optout_toggle { get; set; }

		[Outlet]
		UIKit.UIButton set_location_sf { get; set; }

		[Outlet]
		UIKit.UIButton set_location_toronto { get; set; }

		[Outlet]
		UIKit.UIButton set_username_xamarin { get; set; }

		[Outlet]
		UIKit.UIButton uuid_get { get; set; }

		[Action ("breacrumb_async_touchUpInside:")]
		partial void breacrumb_async_touchUpInside (Foundation.NSObject sender);

		[Action ("breadcrumb_async_touchUpInside:")]
		partial void breadcrumb_async_touchUpInside (Foundation.NSObject sender);

		[Action ("breadcrumb_xamarin_touchUpInside:")]
		partial void breadcrumb_xamarin_touchUpInside (Foundation.NSObject sender);

		[Action ("didCrashOnLastLoad_touchUpInside:")]
		partial void didCrashOnLastLoad_touchUpInside (Foundation.NSObject sender);

		[Action ("optout_get_touchUpInside:")]
		partial void optout_get_touchUpInside (Foundation.NSObject sender);

		[Action ("optout_toggle_touchUpInside:")]
		partial void optout_toggle_touchUpInside (Foundation.NSObject sender);

		[Action ("set_location_sf_touchUpInside:")]
		partial void set_location_sf_touchUpInside (Foundation.NSObject sender);

		[Action ("set_location_toronto_touchUpInside:")]
		partial void set_location_toronto_touchUpInside (Foundation.NSObject sender);

		[Action ("set_username_xamarin_touchUpInside:")]
		partial void set_username_xamarin_touchUpInside (Foundation.NSObject sender);

		[Action ("uuid_get_touchUpInside:")]
		partial void uuid_get_touchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (breadcrumb_xamarin != null) {
				breadcrumb_xamarin.Dispose ();
				breadcrumb_xamarin = null;
			}

			if (breadcrumb_async != null) {
				breadcrumb_async.Dispose ();
				breadcrumb_async = null;
			}

			if (didCrashOnLastLoad != null) {
				didCrashOnLastLoad.Dispose ();
				didCrashOnLastLoad = null;
			}

			if (optout_get != null) {
				optout_get.Dispose ();
				optout_get = null;
			}

			if (optout_toggle != null) {
				optout_toggle.Dispose ();
				optout_toggle = null;
			}

			if (set_location_sf != null) {
				set_location_sf.Dispose ();
				set_location_sf = null;
			}

			if (set_location_toronto != null) {
				set_location_toronto.Dispose ();
				set_location_toronto = null;
			}

			if (set_username_xamarin != null) {
				set_username_xamarin.Dispose ();
				set_username_xamarin = null;
			}

			if (uuid_get != null) {
				uuid_get.Dispose ();
				uuid_get = null;
			}
		}
	}
}
