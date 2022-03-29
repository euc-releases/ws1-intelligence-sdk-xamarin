
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
using Android.Support;

namespace WS1IntelligenceTestAppAndroid.Fragments
{

    public class ErrorFragment : AndroidX.Fragment.App.Fragment
    {
        private View view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public static ErrorFragment NewInstance()
        {
            var frag1 = new ErrorFragment { Arguments = new Bundle() };
            return frag1;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            base.OnCreateView(inflater, container, savedInstanceState);

            view = inflater.Inflate(Resource.Layout.error_fragment, container, false);

            Button triggerCrash = (Button)view.FindViewById<Button>(Resource.Id.triggerCrash);
            triggerCrash.Click += onCrash;

            Button handleException = (Button)view.FindViewById<Button>(Resource.Id.logHandledException);
            handleException.Click += onHandleException;
            return view;


        }
        public void onCrash(object sender, EventArgs e)
        {
            
            logUnHandledException();
                
        }

        public void onHandleException(object sender, EventArgs e)
        {
            logHandledException();
        }

        private void logUnHandledException()
        {
                int[] array = new int[1];
                int arr = array[2];
        }

        private void logHandledException()
        {
            try
            {
                int[] array = new int[1];
                int arr = array[2];
            }
            catch (Exception handledException)
            {
                Com.Crittercism.App.Crittercism.LogPluginException(handledException.GetType().FullName, handledException.Message, WS1IntelligenceAndroid.WS1Intelligence.StackTrace(handledException), 1);
            }
        }
    }
}
