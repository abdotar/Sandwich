using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using Sandwich.Models.ConnectionsCFG;
using Sandwich.Models;

namespace Sandwich
{
    public class offersview:StackLayout
    {
		offersstack offers = new offersstack();
		offerscollection of1 = new offerscollection();
		//button wich expands with news
		ActivityIndicator act1 = new ActivityIndicator();
		StackLayout indicatorholder = new StackLayout();
		StackLayout mainoffersstack = new StackLayout();
		bool busy;

		public offersview()
		{
			
			busy = true;
			this.Children.Add(indicatorholder);
			this.Children.Add(mainoffersstack);
			this.Children.Add(offers);
			act1.IsRunning = true;
			indicatorholder.HorizontalOptions = LayoutOptions.CenterAndExpand;
			indicatorholder.VerticalOptions = LayoutOptions.Center;
			indicatorholder.Orientation = StackOrientation.Horizontal;
			Label loadinglabel = new Label();
			loadinglabel.VerticalOptions = LayoutOptions.CenterAndExpand;
			loadinglabel.Text = "Загрузка данных.....";
			indicatorholder.Children.Add(act1);
			indicatorholder.Children.Add(loadinglabel);
			fillmainofferframe();
			fillsecondaryoffersframe();
		}

		protected async void fillmainofferframe()

		{
			await of1.GetOffers();

			foreach (Offer offer in of1.Offers.Where(x => x.IsMain == true && x.IsActive == true))
			{
				if (offer.ImagePath != null)
				{
					Image offerimage = new Image();
					offerimage.Source = new UriImageSource
					{
						CachingEnabled = false,
						Uri = new System.Uri(offer.ImagePath)
					};
					Offerframe offer1 = new Offerframe(offer.Name, offer.Discription, offerimage);
					mainoffersstack.Children.Add(offer1);
				}
				indicatorholder.IsVisible = false;


			}

		}

		protected async void fillsecondaryoffersframe()
		{
			await of1.GetOffers();
			foreach (Offer offer in of1.Offers.Where(x => x.IsMain == false && x.IsActive == true))
			{
				if (offer.ImagePath != null)
				{
					Image offerimage = new Image();
					offerimage.Source = new UriImageSource
					{
						CachingEnabled = false,
						Uri = new System.Uri(offer.ImagePath)
					};
					Offerframe offer1 = new Offerframe(offer.Name, offer.Discription, offerimage);

					//offers.fillexpander(offer1);
					offers.expanded.Children.Add(offer1);
					//mainoffersstack.Children.Add(offer1);
				}
				indicatorholder.IsVisible = false;


			}
			busy = false;
		}

	}

}
