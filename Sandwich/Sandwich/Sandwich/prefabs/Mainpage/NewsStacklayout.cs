using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sandwich
{
    public class NewsStacklayout:StackLayout
    {

		//holds the offersstack and unvisible by default
		public StackLayout expanded = new StackLayout();
		//title of stacklayout
		Label title = new Label();
		Frame stackframe = new Frame();
		StackLayout mainholder = new StackLayout();


		public NewsStacklayout()
		{
			title.Margin = 10;
			title.BackgroundColor = Color.Bisque;
			title.HorizontalOptions = LayoutOptions.CenterAndExpand;
			title.Text = "НОВОСТИ";
			title.FontAttributes = FontAttributes.Bold;
			title.FontSize = 20;
			title.TextColor = Color.Brown;
			mainholder.VerticalOptions = LayoutOptions.CenterAndExpand;
			stackframe.BorderColor = Color.Black;
			stackframe.CornerRadius = 20;
			stackframe.BackgroundColor = Color.Bisque;
			mainholder.Children.Add(title);
			mainholder.Children.Add(expanded);
			stackframe.Content = mainholder;
			expanded.IsVisible = false;

			/* add code wich addchildrens to expand(mainoffers stack and other offers)*/




			this.Children.Add(stackframe);
			pressablstack(this, expandmeal);
			//code to add data to expand(for each offer)




		}
		public async void expandmeal(object sender, EventArgs e)
		{
			if (expanded.IsVisible)
			{
				await this.FadeTo(0, 250);
				expanded.IsVisible = false;
				await this.FadeTo(1, 250);


			}
			else
			{
				await this.FadeTo(0, 250);
				expanded.IsVisible = true;
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


	}
}
