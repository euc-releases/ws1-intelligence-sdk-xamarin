
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Locations;

namespace WS1IntelligenceTestAppAndroid.Fragments
{
    public class OthersFragment : AndroidX.Fragment.App.Fragment
    {
        private View view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static OthersFragment NewInstance()
        {
            var frag1 = new OthersFragment { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            base.OnCreateView(inflater, container, savedInstanceState);
            //return inflater.Inflate(Resource.Layout.others_fragment, container, false);
            view = inflater.Inflate(Resource.Layout.others_fragment, container, false);

            Button logBreadcrumbButton = (Button)view.FindViewById<Button>(Resource.Id.logBreadcrumbButton);
            logBreadcrumbButton.Click += logBreadcrumb;

            Button setUserName = (Button)view.FindViewById<Button>(Resource.Id.setUserName);
            setUserName.Click += setUser;

            Button getOptOut = (Button)view.FindViewById<Button>(Resource.Id.getOptOutStatus);
            getOptOut.Click += getOptOutStatus;


            Button setOptOut = (Button)view.FindViewById<Button>(Resource.Id.setOptOutStatus);
            setOptOut.Click += setOptOutStatus;


            Button setlocation1 = (Button)view.FindViewById<Button>(Resource.Id.setlocation1);
            setlocation1.Click += setlocationSF;

            Button setlocation2 = (Button)view.FindViewById<Button>(Resource.Id.setlocation2);
            setlocation2.Click += setlocationToronto;


            Button didCrashOnlastLoad = (Button)view.FindViewById<Button>(Resource.Id.didCrashOnlastLoad);
            didCrashOnlastLoad.Click += didCrashOnlastLoadStatus;
            return view;
        }

        public void logBreadcrumb(object sender, EventArgs e)
        {

            logBreadcrumb();

        }

        private void logBreadcrumb()
        {
            Com.Crittercism.App.Crittercism.LeaveBreadcrumb("Xamarin Android");
        }

        public void setUser(object sender, EventArgs e)
        {

            setUser();

        }

        private void setUser()
        {
            Com.Crittercism.App.Crittercism.SetUsername("Xamarin User");
        }

        public void getOptOutStatus(object sender, EventArgs e)
        {

            getOptOutStatus();

        }

        private void getOptOutStatus()
        {
           var status = Com.Crittercism.App.Crittercism.OptOutStatus;
            Console.WriteLine("OptoutStatus :{0}", status);
        }

        public void setOptOutStatus(object sender, EventArgs e)
        {
            setOptOut();
            
        }

        private void setOptOut()
        {
            bool status = Com.Crittercism.App.Crittercism.OptOutStatus;
            Console.WriteLine("OptoutStatus was :{0}", status);
            Com.Crittercism.App.Crittercism.OptOutStatus = !status;
            status = Com.Crittercism.App.Crittercism.OptOutStatus;
            Console.WriteLine("OptoutStatus is :{0}", status);
        }

        public void setlocationSF(object sender, EventArgs e)
        {

            setlocationSF();

        }
        private void setlocationSF()
        {
            Location loc = new Location("");
            loc.Latitude = 37.7749;
            loc.Longitude = -122.431297;
            Com.Crittercism.App.Crittercism.UpdateLocation(loc);
        }
        public void setlocationToronto(object sender, EventArgs e)
        {

            Location loc = new Location("");
            loc.Latitude = 43.6532;
            loc.Longitude = -79.347015;
            Com.Crittercism.App.Crittercism.UpdateLocation(loc);

        }
        public void didCrashOnlastLoadStatus(object sender, EventArgs e)
        {

            didCrashOnlastLoadStatus();

        }
        private void didCrashOnlastLoadStatus()
        {
            bool crashed = Com.Crittercism.App.Crittercism.DidCrashOnLastLoad();
            Console.WriteLine("App did crashed on last load {0} ", crashed ? "YES" : "NO");
        }

    }
}
