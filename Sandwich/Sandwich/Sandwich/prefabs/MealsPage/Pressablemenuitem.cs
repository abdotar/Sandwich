using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sandwich.prefabs.MealsPage
{
	public class Pressablemenuitem : StackLayout
	{
		BoxView seperator = new BoxView();
		StackLayout expandedpart = new StackLayout();

		public Pressablemenuitem(string name, string imagepath, string discription, int price)
		{
			seperator.Color = Color.Tomato;
			seperator.WidthRequest = 100;
			seperator.HeightRequest = 2;

			//this.HorizontalOptions = LayoutOptions.Fill;
			expandedpart.IsVisible = false;
			//if pressed expands the discription
			pressablstack(this, expandmeal);
			// meal name

			Label mealtitle = new Label();
			mealtitle.Text = name;
			mealtitle.FontAttributes = FontAttributes.Bold;
			mealtitle.FontSize = 20;
			mealtitle.TextColor = Color.Brown;


			//meal image
			Image mealimage = new Image();

			//no need to explain it's meals price
			Label mealprice = new Label();
			mealprice.Text = "Цена: " + Convert.ToString(price);
			mealprice.HorizontalOptions = LayoutOptions.End;
			mealprice.FontAttributes = FontAttributes.Italic;
			mealprice.FontSize = 17;
			mealprice.TextColor = Color.SaddleBrown;

			//meal discription
			Label mealDiscription = new Label();
			mealDiscription.Text = discription;

			this.Children.Add(mealtitle);


			if (imagepath != null)
			{
				mealimage.HeightRequest = 200;
				mealimage.WidthRequest = 200;
				mealimage.Source = new UriImageSource
				{
					CachingEnabled = true,
					Uri = new Uri(imagepath)
				};

				//expandedpart.HorizontalOptions = LayoutOptions.CenterAndExpand;
				//mealimage.Aspect = Aspect.Fill;
				// стеклайоут с индикатором загрузки фото
				imageloader loadimage = new imageloader(mealimage);

				//imagebutton.Image = imagepath;

				this.Children.Add(loadimage);
				this.Children.Add(mealimage);
			}

			expandedpart.Children.Add(mealDiscription);
			this.Children.Add(expandedpart);
			this.Children.Add(mealprice);
			this.Children.Add(seperator);



		}

		public async void expandmeal(object sender, EventArgs e)
		{
			if (expandedpart.IsVisible)
			{
				await this.FadeTo(0, 250);
				expandedpart.IsVisible = false;
				await this.FadeTo(1, 250);


			}
			else
			{
				await this.FadeTo(0, 250);
				expandedpart.IsVisible = true;
				await this.FadeTo(1, 250);

			}
		}

		private void pressablstack(StackLayout st, EventHandler ev)
		{
			//Creating TapGestureRecognizers    
			var tapmain = new TapGestureRecognizer();
			//Binding events    
			tapmain.Tapped += ev;
			//Associating tap events to the image buttons    
			st.GestureRecognizers.Add(tapmain);

		}

		private async void StartAnimation()
		{

			await this.FadeTo(0, 250);

			await this.FadeTo(1, 250);
		}
	}
}
