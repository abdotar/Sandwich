using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sandwich
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
			
			
			if (Xamarin.Forms.Device.OS == TargetPlatform.Android)
			{
				AppCenter.Start("c0bcb3a5-894a-4887-8c9c-dab197e4ed31", typeof(Push));
			}
			else if (Xamarin.Forms.Device.OS == TargetPlatform.iOS)
			{
				AppCenter.Start("1259b196-1a74-4aef-ab91-4c46607e3840", typeof(Push));
			}

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
