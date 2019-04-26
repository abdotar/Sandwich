using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandwich;
using System.Threading.Tasks;
using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net.Http;
using Sandwich.Droid;
using Android.Content.PM;

[assembly: Xamarin.Forms.Dependency(typeof(OpenAppAndroid))]


namespace Sandwich.Droid
{
	[Activity(Label = "OpenAppAndroid")]
	public class OpenAppAndroid : Activity, IOpenApp
	{

		public Task<bool> LaunchApp(string uri)
		{
			bool result = false;

			try
			{
				//var aUri = Android.Net.Uri.Parse(uri.ToString());
				//var intent = new Intent(Intent.ActionView, aUri);
				Intent intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage("ru.yandex.yandexnavi");

				if (intent != null)
				{
					//yandexnavi://build_route_on_map?lat_to=55.70&lon_to=37.64
					var aUri = Android.Net.Uri.Parse("yandexnavi://build_route_on_map?lat_to=55.653002&lon_to=37.502493");
					//var aUri = Android.Net.Uri.Parse("yandexnavi://show_point_on_map?lat=55.653002&lon=37.502493&zoom=12&no-balloon=0&desc=Бистро SanDwich");
					//yandexnavi://show_point_on_map?lat=55.77&lon=37.44&zoom=12&no-balloon=0&desc=кафе с wi-fi"
					var intent1 = new Intent(Intent.ActionView, aUri);
					intent1.AddFlags(ActivityFlags.NewTask);
					Forms.Context.StartActivity(intent1);
					result = true;
				}
				else
				{
					intent = new Intent(Intent.ActionView);
					intent.AddFlags(ActivityFlags.NewTask);
					
						intent.SetData(Android.Net.Uri.Parse("market://details?id=ru.yandex.yandexnavi"));
						Forms.Context.StartActivity(intent);
					
					result = true;
				}
				
			}
			catch (ActivityNotFoundException)
			{
				result = false;
			}

			return Task.FromResult(result);

		}



		/*public void OpenExternalApp()
		{
			double lat = 55.653002;
			double lon = 37.502493;

			Intent intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage("ru.yandex.yandexmaps,yandexmaps://maps.yandex.ru/?ll=" + lat + "," + lon + "&z=12");
			//intent.setData(Uri.parse("www.onliner.by"));
			//intent.Data("ru.yandex.yandexmaps,yandexmaps://maps.yandex.ru/?ll=" + lat + "," + lon + "&z=12");

			// If not NULL run the app, if not, take the user to the app store
			if (intent != null)
			{

				

				intent.AddFlags(ActivityFlags.NewTask);
				Forms.Context.StartActivity(intent);
			}
			else
			{
				intent = new Intent(Intent.ActionView);
				intent.AddFlags(ActivityFlags.NewTask);
				intent.SetData(Android.Net.Uri.Parse("market://details?id=ru.yandex.yandexmaps"));
				Forms.Context.StartActivity(intent);
			}
		}*/
	}
}