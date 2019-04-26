using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Sandwich.Models;
using System.Linq;
using Sandwich.Models.ConnectionsCFG;
using Sandwich;
using System.Collections.ObjectModel;

namespace Sandwich.prefabs.MealsPage
{


	public class MealtypesStack : StackLayout
	{
		BoxView seperator = new BoxView();
		ActivityIndicator act1 = new ActivityIndicator();
		StackLayout indicatorholder = new StackLayout();

		// stack contains the pressable lable with meal type from menu and expand when pressed
		StackLayout labelstack = new StackLayout();

		//expandingstack
		StackLayout expand = new StackLayout();

		// stack contains all meals from one type
		StackLayout menustack = new StackLayout();



		//pressable stack holds title, image and price of meal
		StackLayout pressablepart = new StackLayout();


		//holds the discription hidden by default
		StackLayout expandedpart = new StackLayout();


		Titlelable typelabel = new Titlelable();


		public ObservableCollection<Meal> Meals { get; set; }
		MealsService mealsService = new MealsService();

		Image labelicon = new Image();

		private bool isBusy;    // идет ли загрузка с сервера
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				OnPropertyChanged("IsBusy");
				OnPropertyChanged("IsLoaded");
			}
		}
		public bool IsLoaded
		{
			get { return !isBusy; }
		}




		public MealtypesStack(int typeid/*type id from database  */)
		{
			seperator.Color = Color.Black;
			seperator.WidthRequest = 100;
			seperator.HeightRequest = 1;
			labelicon.HeightRequest = 70;
			labelicon.WidthRequest = 70;
			labelicon.Margin = 20;
			this.Children.Add(indicatorholder);
			act1.IsRunning = true;
			expand.IsVisible = false;
			indicatorholder.HorizontalOptions = LayoutOptions.CenterAndExpand;
			indicatorholder.VerticalOptions = LayoutOptions.Center;
			indicatorholder.Orientation = StackOrientation.Horizontal;
			Label loadinglabel = new Label();
			loadinglabel.VerticalOptions = LayoutOptions.CenterAndExpand;
			loadinglabel.Text = "Загрузка данных.....";
			indicatorholder.Children.Add(act1);
			indicatorholder.Children.Add(loadinglabel);
			expand.Children.Add(indicatorholder);
			IsBusy = false;
			Meals = new ObservableCollection<Meal>();
			if (typeid == 1)
			{
				typelabel.Text = "БЛЮДА ВО ФРИТЮРЕ";
				labelicon.Source = ImageSource.FromResource("Sandwich.images.frylogo.png");
			}
			if (typeid == 2)
			{
				typelabel.Text = "СЕНДВИЧИ И РОЛЛЫ";
				labelicon.Source = ImageSource.FromResource("Sandwich.images.rollicon.png");
			}
			if (typeid == 3)
			{
				typelabel.Text = "БУРГЕРЫ";
				labelicon.Source = ImageSource.FromResource("Sandwich.images.burgericon.png");
			}
			if (typeid == 4)
			{
				typelabel.Text = "КОМПЛЕКСЫ И ДРУГОЕ";
				labelicon.Source = ImageSource.FromResource("Sandwich.images.complexicon.png");
			}
			if (typeid == 5)
			{
				typelabel.Text = "ШАУРМА";
				labelicon.Source = ImageSource.FromResource("Sandwich.images.Shawerma.png");
			}
			typelabel.VerticalOptions = LayoutOptions.CenterAndExpand;
			pressablstack(labelstack, expandstack);
			labelstack.Orientation = StackOrientation.Horizontal;
			labelstack.Children.Add(labelicon);
			labelstack.Children.Add(typelabel);
			this.Children.Add(labelstack);
			expand.Children.Add(menustack);
			connecttoserver(typeid);
			this.Children.Add(expand);
			this.Children.Add(seperator);
		}

		//creates mealstack
		/*private StackLayout createMenuStack(string name, string imagepath, string discription, int price)
		{



			Grid discriptiongrid = new Grid();
			{

				discriptiongrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) });
				discriptiongrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				discriptiongrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
				discriptiongrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

			};
			// 
			Grid imagegrid = new Grid();
			{
				imagegrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				imagegrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(270, GridUnitType.Absolute) });
			};
			StackLayout menustack = new StackLayout();
			StackLayout namestack = new StackLayout();
			namestack.VerticalOptions = LayoutOptions.FillAndExpand;
			Image mealimage = new Image();
			Label mealname = new Label();
			Label mealdisc = new Label();
			Label mealprice = new Label();
			mealname.HorizontalTextAlignment = TextAlignment.Center;
			mealname.Text = name;
			mealdisc.Text = discription;
			mealprice.Text = "Цена: " + Convert.ToString(price);
			mealprice.HorizontalOptions = LayoutOptions.FillAndExpand;
			mealprice.VerticalTextAlignment = TextAlignment.End;

			if (imagepath == null)
			{

				namestack.Children.Add(mealname);
				menustack.Children.Add(namestack);
				discriptiongrid.Children.Add(mealdisc, 0, 0);
				Grid.SetRowSpan(mealdisc, 1);
				Grid.SetColumnSpan(mealdisc, 2);
				discriptiongrid.Children.Add(mealprice, 1, 1);
				menustack.Children.Add(discriptiongrid);

			}
			else
			{


				mealimage.Source = new UriImageSource
				{
					CachingEnabled = false,
					Uri = new System.Uri(imagepath)
				};

				// стеклайоут с индикатором загрузки фото
				imageloader loadimage = new imageloader(mealimage);


				mealimage.Aspect = Aspect.Fill;
				namestack.Children.Add(mealname);
				menustack.Children.Add(namestack);

				imagegrid.Children.Add(mealimage, 0, 0);
				imagegrid.Children.Add(loadimage, 0, 0);
				menustack.Children.Add(imagegrid);

				discriptiongrid.Children.Add(mealdisc, 0, 0);
				Grid.SetRowSpan(mealdisc, 1);
				Grid.SetColumnSpan(mealdisc, 2);
				discriptiongrid.Children.Add(mealprice, 1, 1);
				menustack.Children.Add(discriptiongrid);



				menustack.Children.Add(imagegrid);

			}


			return menustack;
		}*/

		public void expandmeal(object sender, EventArgs e)
		{
			if (expandedpart.IsVisible)
			{
				expandedpart.IsVisible = false;
			}
			else
			{

				expandedpart.IsVisible = true;
			}
		}

		public async Task GetMeals()
		{
			IEnumerable<Meal> meals = await mealsService.Get();

			// очищаем список
			//Friends.Clear();
			while (Meals.Any())
				Meals.RemoveAt(Meals.Count - 1);

			// добавляем загруженные данные
			foreach (Meal f in meals)
				Meals.Add(f);
		}

		protected async void connecttoserver(int typeid)
		{
			await GetMeals();
			//add method to run trough all types and create diferent albles

			//only burgers
			foreach (Meal meal in Meals.Where(x => x.MealTypeId == typeid))
			{
				string name = meal.Name;
				string imagepath = meal.ImagePath;
				string discription = meal.Discription;
				int price = meal.Price;
				Pressablemenuitem item1 = new Pressablemenuitem(name, imagepath, discription, price);
				menustack.Children.Add(item1);

			}
			indicatorholder.IsVisible = IsBusy;
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

		// method called when pressed on labelstack
		private async void expandstack(object sender, EventArgs e)
		{
			if (expand.IsVisible)
			{

				await labelstack.FadeTo(0, 250);
				expand.IsVisible = false;
				await labelstack.FadeTo(1, 250);

			}
			else
			{

				await labelstack.FadeTo(0, 250);
				expand.IsVisible = true;
				await labelstack.FadeTo(1, 250);

			}
		}
		private async void StartAnimation()
		{

			await labelstack.FadeTo(0, 250);

			await labelstack.FadeTo(1, 250);
		}

	}
}
