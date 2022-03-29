
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

namespace WS1IntelligenceTestAppAndroid.Fragments
{
    public class NetworkFragment : AndroidX.Fragment.App.Fragment
    {
        private View view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static NetworkFragment NewInstance()
        {
            var frag1 = new NetworkFragment { Arguments = new Bundle() };
            return frag1;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.network_fragment, container, false);

            Button network_request = (Button)view.FindViewById<Button>(Resource.Id.network_request);
            network_request.Click += onCrash;

            Button network_error = (Button)view.FindViewById<Button>(Resource.Id.network_error);
            network_error.Click += onHandleException;
            return view;
        }

        public void onCrash(object sender, EventArgs e)
        {

            logNetworkRequest();

        }

        public void onHandleException(object sender, EventArgs e)
        {
            logNetworkError();
        }

        private void logNetworkRequest()
        {
            Com.Crittercism.App.Crittercism.LogNetworkRequest("GET", new Java.Net.URL("https://www.google.ca"), 1, 342, 77, 202, null);
        }

        private void logNetworkError()
        {
            Com.Crittercism.App.Crittercism.LogNetworkRequest("GET", new Java.Net.URL("https://www.google.ca"), 1, 342, 77, 202, null);
        }
    }
}
