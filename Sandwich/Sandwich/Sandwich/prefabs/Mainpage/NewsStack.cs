using System;
using System.Collections.Generic;
using System.Text;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sandwich
{
	public class NewsStack : StackLayout
	{
		Label title = new Label();
		Label AboutNews = new Label();
		Button ShowVideobtn = new Button();
		StackLayout videoStack = new StackLayout();
		ProgressBar bar1 = new ProgressBar();
		WebView web = new WebView();


		public NewsStack(string name, string discription, string link)
		{
			this.VerticalOptions = LayoutOptions.FillAndExpand;
			this.HorizontalOptions = LayoutOptions.FillAndExpand;

			title.Text = name;
			AboutNews.Text = discription;
			ShowVideobtn.Text = "Показать видео";
			ShowVideobtn.Clicked += new EventHandler(Showstack);
			//add action to click on show video btn

			this.Children.Add(title);
			this.Children.Add(AboutNews);


			if(link != null)
			{
				this.Children.Add(ShowVideobtn);



				bar1.HorizontalOptions = LayoutOptions.FillAndExpand;
				bar1.IsVisible = false;


				web.Navigating += loading;
				web.Navigated += loaded;
				var htmlSource = new HtmlWebViewSource();

				// change the https when call with correct url to ech video (add variabel instead constatnt url!)
				htmlSource.Html = @"
					<iframe width='100%' height='315' src='" + link + "'frameborder='0' allow=' encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";
				web.Source = htmlSource;

				web.HeightRequest = 350;


				videoStack.IsVisible = false;
				videoStack.Children.Add(bar1);
				videoStack.Children.Add(web);

				this.Children.Add(videoStack);
			}
			
		}

		private async void Showstack (object sender, EventArgs e)
		{
			if (videoStack.IsVisible)
			{
				ShowVideobtn.Text = "Показать видео";
				videoStack.IsVisible = false;
			}
			else
			{
				ShowVideobtn.Text = "Скрыть видео";
				videoStack.IsVisible = true;
			}
			

		}
		private void loading(object sender, WebNavigatingEventArgs e)
		{
			
			bar1.IsVisible = true;
		}
		private async void loaded(object sender, WebNavigatedEventArgs e)
		{
			await bar1.ProgressTo(0.9, 500, Easing.SpringIn);
			bar1.IsVisible = false;
		}




	}
}
