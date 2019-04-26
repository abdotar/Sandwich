using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Sandwich.iOS
{
	class OpenAppiOS : IOpenApp
	{
		public Task<bool> LaunchApp(string uri)
		{
			try
			{

				var canOpen = UIApplication.SharedApplication.CanOpenUrl(new NSUrl(uri));

				if (!canOpen)
				{

					uri = "itms://itunes.apple.com/ru/app//id474500851?mt=8";
					return Task.FromResult(UIApplication.SharedApplication.OpenUrl(new NSUrl(uri)));
				}
					

				return Task.FromResult(UIApplication.SharedApplication.OpenUrl(new NSUrl(uri)));

			}
			catch (Exception ex)
			{
				return Task.FromResult(false);
			}
		}
	}
}