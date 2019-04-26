using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sandwich
{

    public class Offerframe:Frame
    {
		StackLayout maincontainer = new StackLayout();
		StackLayout expandedstack = new StackLayout();
		public Offerframe(string title,string discription,Image mainimage)
		{
			this.CornerRadius = 20;
			this.BorderColor = Color.Black;
			this.Margin = 40;


			imageloader loader = new imageloader(mainimage);


			Label OfeerTitle = new Label();
			OfeerTitle.HorizontalOptions = LayoutOptions.CenterAndExpand;
			OfeerTitle.Text = title;
			OfeerTitle.FontAttributes = FontAttributes.Bold;
			OfeerTitle.FontSize = 20;
			OfeerTitle.TextColor = Color.Brown;


			Label offerdiscription = new Label();
			offerdiscription.Text = discription;


			expandedstack.IsVisible = false;
			expandedstack.Children.Add(offerdiscription);


			maincontainer.Children.Add(loader);
			maincontainer.Children.Add(mainimage);
			maincontainer.Children.Add(OfeerTitle);
			maincontainer.Children.Add(expandedstack);

			pressablstack(this, expand);
			this.Content = maincontainer;

		}
		public async void expand(object sender, EventArgs e)
		{
			if (expandedstack.IsVisible)
			{
				await this.FadeTo(0, 250);
				expandedstack.IsVisible = false;
				await this.FadeTo(1, 250);


			}
			else
			{
				await this.FadeTo(0, 250);
				expandedstack.IsVisible = true;
				await this.FadeTo(1, 250);

			}
		}


		private void pressablstack(Frame st, EventHandler ev)
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
