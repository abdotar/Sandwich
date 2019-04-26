using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Sandwich.prefabs;


namespace Sandwich
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class MainPage : ContentPage
	{
		StackLayout holder = new StackLayout();
		ConnectivityTest testnet = new ConnectivityTest();

		public MainPage()
		{
			
			InitializeComponent();
			Header head = new Header();
			Footer foot = new Footer();
			top.Children.Add(head);
			buttom.Children.Add(foot);
			if (testnet != null)
			{
				center.Children.Clear();
				var current = Connectivity.NetworkAccess;
				if (current == NetworkAccess.Internet)
				{
					/*Label l1 = new Label();
					l1.Text = "Works Fine for me";
					center.Children.Add(l1);*/

					//button wich expands with offers
					center.Children.Clear();
					ScrollView mainscrol = new ScrollView();// скрол вюхи
					NewsView news = new NewsView();
					offersview offers = new offersview();
					holder.Children.Add(offers);
					holder.Children.Add(news);
					mainscrol.Content = holder;
					center.Children.Add(mainscrol);

				}
				else
				{
					Interneterror nonet = new Interneterror();
					center.Children.Add(nonet);
				}

			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
	}
}
