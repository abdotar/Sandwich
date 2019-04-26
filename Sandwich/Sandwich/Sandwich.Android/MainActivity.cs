using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Permissions;

namespace Sandwich.Droid
{
    [Activity(Label = "Sandwich", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
			Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
			Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
			Xamarin.FormsMaps.Init(this, savedInstanceState);
			TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			LoadApplication(new App());

        }

		protected override void OnStart()
		{
			base.OnStart();

			if (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
			{
				ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("Permission Granted!!!");
			}
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
		{
			Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}

	
}