using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Sandwich.Models.ConnectionsCFG;
using Sandwich.prefabs;
using Sandwich.prefabs.MealsPage;


namespace Sandwich
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Meals : ContentPage
	{

		MealsService mealsService = new MealsService();
		public Meals()
		{
			InitializeComponent();
			Header head = new Header();
			Footer foot = new Footer();
			top.Children.Add(head);
			buttom.Children.Add(foot);
			var current = Connectivity.NetworkAccess;
			if (current == NetworkAccess.Internet)
			{
				//menugrid();
				menuholder.IsVisible = true;
				StackLayout mealstack = new StackLayout();
				mealstack.VerticalOptions = LayoutOptions.StartAndExpand;
				mealstack.HorizontalOptions = LayoutOptions.Start;

				mealstack.VerticalOptions = LayoutOptions.StartAndExpand;
				mealstack.HorizontalOptions = LayoutOptions.Start;

				MealtypesStack prosted = new MealtypesStack(1);
				MealtypesStack burgers = new MealtypesStack(3);
				MealtypesStack sandwiches = new MealtypesStack(2);
				MealtypesStack complex = new MealtypesStack(4);
				MealtypesStack shawerma = new MealtypesStack(5);


				mealstack.Children.Add(prosted);
				mealstack.Children.Add(burgers);
				mealstack.Children.Add(sandwiches);
				mealstack.Children.Add(complex);
				mealstack.Children.Add(shawerma);

				menuholder.Children.Add(mealstack);


			}
			else
			{
				menuholder.IsVisible = false;
				Interneterror nonet = new Interneterror();
				center.Children.Add(nonet);
			}



		}

	}
}