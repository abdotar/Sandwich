using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sandwich.prefabs;
using Xamarin.Forms.Maps;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace Sandwich
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class About : ContentPage
	{
		public About ()
		{
			InitializeComponent ();
			if (Xamarin.Forms.Device.OS == TargetPlatform.Android)
			{
				askper();
			}
			else if (Xamarin.Forms.Device.OS == TargetPlatform.iOS)
			{
				ask();
			}

				
			Header head = new Header();
			Footer foot = new Footer();
			top.Children.Add(head);
			buttom.Children.Add(foot);
		}

		protected override void OnAppearing()
		{
			center.Children.Clear();
			if (Xamarin.Forms.Device.OS == TargetPlatform.Android)
			{
				askper();
			}
			else if (Xamarin.Forms.Device.OS == TargetPlatform.iOS)
			{
				ask();
			}

			Button openinyandex = new Button();
			openinyandex.Text = "Маршрут в яндекс навигаторе";
			openinyandex.Clicked += new EventHandler(openyandexapp);
			center.Children.Add(openinyandex);

		}

		public async void openyandexapp(object sender, EventArgs e)
		{
			
			if (Device.OS == TargetPlatform.Android)
			{
				DependencyService.Get<IOpenApp>().LaunchApp("yandexmaps://maps.yandex.ru/?pt=37.502493,55.653002&z=12&l=map");
			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				var appname = @"yandexnavi://build_route_on_map?lat_to=55.653002&lon_to=37.502493";
				var result = await DependencyService.Get<IOpenApp>().LaunchApp(appname);
			}
			
			
			/*OpenAppService.Launch()
			Device.BeginInvokeOnMainThread(() =>
			{
				double lat = 55.653002;
				double lon = 37.502493;
				Device.OpenUri(new Uri("yandexmaps://maps.yandex.ru/?pt=37.502493,55.653002&z=12&l=map"));
			});*/


		}


		public async void ask()
		{

			var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
			if (status != PermissionStatus.Granted)
			{
				if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
				{
					await DisplayAlert("Предупреждкние", "Требуеться доступ к данным о местоположении", "OK");
				}

				var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
				//Best practice to always check that the key exists
				if (results.ContainsKey(Permission.Location))
					status = results[Permission.Location];
			}

			if (status == PermissionStatus.Granted)
			{
				displaymap();
			}
			else if (status != PermissionStatus.Unknown)
			{
				await DisplayAlert("Трубуеться доступ", "При отказе данная страница не отобразиться, разрешите доступ к местоположению.", "OK");
			}

		}

		public async void askper()
		{
			try
			{
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
				if (status != PermissionStatus.Granted)
				{
					if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
					{
						await DisplayAlert("Need location", "Gunna need that location", "OK");
					}

					var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
					status = results[Permission.Location];
				}

				if (status == PermissionStatus.Granted)
				{
					displaymap();
				}
				else if (status != PermissionStatus.Unknown)
				{
					await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
				}
			}
			catch (Exception ex)
			{
				//...
			}
		}


		public void displaymap()
		{
			var current = Connectivity.NetworkAccess;
			if (current == NetworkAccess.Internet)
			{
				//center.Children.Add(); adding stacklyout with offers
				var map = new Xamarin.Forms.Maps.Map(
		  MapSpan.FromCenterAndRadius(
				  new Position(55.653002, 37.502493), Distance.FromMiles(0.3)))
				{
					IsShowingUser = true,
					HeightRequest = 100,
					WidthRequest = 960,
					VerticalOptions = LayoutOptions.FillAndExpand
				};
				var stack = new StackLayout { Spacing = 0 };
				stack.HeightRequest = 320;
				stack.Children.Add(map);
				var position = new Position(55.653002, 37.502493); // Latitude, Longitude
				var pin = new Pin
				{
					Type = PinType.Place,
					Position = position,
					Label = "Бистро Sandwich",
					Address = "Миклухо - Маклая 11 б."


				};
				map.Pins.Add(pin);
				center.Children.Add(stack);

			}
			else
			{
				Interneterror nonet = new Interneterror();
				center.Children.Add(nonet);
			}
		}
	}
}