using Xamarin.Forms;
using System.Linq;
using Sandwich.Models;

namespace Sandwich
{
    public class NewsView:StackLayout
    {
		NewsCollection nw1 = new NewsCollection();
		//button wich expands with news
		NewsStacklayout news = new NewsStacklayout();
		ActivityIndicator act1 = new ActivityIndicator();
		StackLayout indicatorholder = new StackLayout();
		StackLayout holder = new StackLayout();

		public NewsView()
		{
			this.Children.Add(news);
			news.expanded.Children.Add(indicatorholder);
			act1.IsRunning = true;
			indicatorholder.HorizontalOptions = LayoutOptions.CenterAndExpand;
			indicatorholder.VerticalOptions = LayoutOptions.Center;
			indicatorholder.Orientation = StackOrientation.Horizontal;
			Label loadinglabel = new Label();
			loadinglabel.VerticalOptions = LayoutOptions.CenterAndExpand;
			loadinglabel.Text = "Загрузка данных.....";
			indicatorholder.Children.Add(act1);
			indicatorholder.Children.Add(loadinglabel);
			fillnews();

		}

		protected async void fillnews()

		{
			await nw1.GetNews();

			foreach (New n in nw1.News.Where(x => x.IsActive == true))
			{
				NewsStack new2 = new NewsStack(n.Name, n.Discription, n.VideoPath);
				news.expanded.Children.Add(new2);
			}
			indicatorholder.IsVisible = false;

		}
	}
}
