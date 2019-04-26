using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Xamarin.Forms;
using Sandwich.Models;
using System.Linq;
using Sandwich.Models.ConnectionsCFG;
using Sandwich;
using System.Collections.ObjectModel;

namespace Sandwich
{
    public class offerscollection
    {


		private bool isBusy;    // идет ли загрузка с сервера
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
			}
		}
		public bool IsLoaded
		{
			get { return !isBusy; }
		}


		public ObservableCollection<Offer> Offers { get; set; }
		OffersService Service = new OffersService();

		public offerscollection()
		{
			isBusy = false;
			connecttoserver();
			Offers = new ObservableCollection<Offer>();
			
		}


		public async Task GetOffers()
		{
			IEnumerable<Offer> offers = await Service.Get();

			// очищаем список
			//Friends.Clear();
			while (Offers.Any())
				Offers.RemoveAt(Offers.Count - 1);

			// добавляем загруженные данные
			foreach (Offer f in offers)
				Offers.Add(f);
			Offers = new ObservableCollection<Offer>(Offers.OrderByDescending(x => x.Id));

		}

		protected async void connecttoserver()

		{
			await GetOffers();
			isBusy = false;
			//add method to run trough all types and create diferent albles
		}

	}
}
