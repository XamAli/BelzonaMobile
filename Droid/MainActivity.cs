//using Android.App;
//using Android.Widget;
//using Android.OS;

//namespace BelzonaMobile.Droid
//{
//    [Activity(Label = "BelzonaMobile.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
//    public class MainActivity : Activity
//    {
//        int count = 1;

//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);

//            // Set our view from the "main" layout resource
//            SetContentView(Resource.Layout.Main);

//            // Get our button from the layout resource,
//            // and attach an event to it
//            Button button = FindViewById<Button>(Resource.Id.myButton);

//            button.Click += delegate { button.Text = $"{count++} clicks!"; };
//        }
//    }
//}

using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BelzonaMobile.Droid
{
    [Activity(Label = "BelzonaMobile.Droid",  Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}
