
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
    public class UserflowFragment : AndroidX.Fragment.App.Fragment
    {
        private View view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }


        public static UserflowFragment NewInstance()
        {
            var frag1 = new UserflowFragment { Arguments = new Bundle() };
            return frag1;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.userflow_fragment, container, false);

            Button logBeginUserFlowButton = (Button)view.FindViewById<Button>(Resource.Id.logBeginUserFlow);
            logBeginUserFlowButton.Click += logBeginUserFlow;

            Button logEndUserFlowButton = (Button)view.FindViewById<Button>(Resource.Id.logEndUserFlow);
            logEndUserFlowButton.Click += logEndUserFlow;

            Button logCancelUserFlowButton = (Button)view.FindViewById<Button>(Resource.Id.logCancelUserFlow);
            logCancelUserFlowButton.Click += logCancelUserFlow;


            Button logFailUserFlowButton = (Button)view.FindViewById<Button>(Resource.Id.logFailUserFlow);
            logFailUserFlowButton.Click += logFailUserFlow;

            return view;
        }


        public void logBeginUserFlow(object sender, EventArgs e)
        {

            logBeginUserFlow();

        }

        private void logBeginUserFlow()
        {
            Com.Crittercism.App.Crittercism.BeginUserFlow("Xamarin Native Flow");
        }

        public void logEndUserFlow(object sender, EventArgs e)
        {

            logEndUserFlow();

        }

        private void logEndUserFlow()
        {
            Com.Crittercism.App.Crittercism.EndUserFlow("Xamarin Native Flow");
        }

        public void logCancelUserFlow(object sender, EventArgs e)
        {

            logCancelUserFlow();

        }

        private void logCancelUserFlow()
        {
            Com.Crittercism.App.Crittercism.CancelUserFlow("Xamarin Native Flow");
        }

        public void logFailUserFlow(object sender, EventArgs e)
        {
            logFailUserFlow();

        }

        private void logFailUserFlow()
        {
            Com.Crittercism.App.Crittercism.FailUserFlow("Xamarin Native Flow");
        }
    }
}
