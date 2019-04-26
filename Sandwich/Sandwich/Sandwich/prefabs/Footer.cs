using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin;
using System.Linq;

namespace Sandwich.prefabs
{
    public class Footer:StackLayout
    {
		public Footer()
		{
			Grid btgrd = new Grid();
			btgrd.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });

			//добовляем столбцы
			int i = 3;
			while (i > 0)
			{
				btgrd.ColumnDefinitions.Add(new ColumnDefinition());
				i--;
			}

			btgrd.RowSpacing = 0;
			btgrd.ColumnSpacing = 0;

			Image img = new Image();
			img.Source = ImageSource.FromResource("Sandwich.images.iconAkcii.png");

			Image menu = new Image();
			menu.Source = ImageSource.FromResource("Sandwich.images.menuIcon.png");

			Image about = new Image();
			about.Source = ImageSource.FromResource("Sandwich.images.about.png");

			pressableimage(img, ToMainPage);
			pressableimage(menu, ToOurmenuPage);
			pressableimage(about, ToAboutPage);

			btgrd.BackgroundColor = Color.Tomato;
			btgrd.Padding = 5;
			btgrd.Children.Add(img, 0, 0);
			btgrd.Children.Add(menu, 1, 0);
			btgrd.Children.Add(about, 2, 0);

			this.Children.Add(btgrd);
		}

		private void pressableimage(Image im, EventHandler ev)
		{
			//Creating TapGestureRecognizers    
			var tapmain = new TapGestureRecognizer();
			//Binding events    
			tapmain.Tapped += ev;
			//Associating tap events to the image buttons    
			im.GestureRecognizers.Add(tapmain);

		}

		private async void ToMainPage(object sender, EventArgs e)
		{


			await Navigation.PushAsync(new MainPage(), true);
			var existingPages = Navigation.NavigationStack.ToList();
			foreach (var page in existingPages)
			{
				Navigation.RemovePage(page);
			}


		}

		private async void ToOurmenuPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Meals(), true);
			var existingPages = Navigation.NavigationStack.ToList();
			foreach (var page in existingPages)
			{
				Navigation.RemovePage(page);
			}
		}

		/*private async void ToOffersPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage(), true);
			var existingPages = Navigation.NavigationStack.ToList();
			foreach (var page in existingPages)
			{
				Navigation.RemovePage(page);
			}
		}*/

		private async void ToAboutPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new About(), true);
			var existingPages = Navigation.NavigationStack.ToList();
			foreach (var page in existingPages)
			{
				Navigation.RemovePage(page);
			}
		}
	}
    
}
