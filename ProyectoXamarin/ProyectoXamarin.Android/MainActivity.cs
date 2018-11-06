using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Xamarin.Forms;

namespace ProyectoXamarin.Droid
{
    [Activity(Label = "ProyectoXamarin", Icon = "@mipmap/icon", Theme = "@style/AppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //SetContentView(Resource.Layout.Main);
            //var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            //SetSupportActionBar(toolbar);
            //SupportActionBar.Title = "JUEGOSeñas"; 
            
            //Picker picker = FindViewById<Picker> ();

            LoadApplication(new App());
        }
    }
}