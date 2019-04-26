
using Xamarin.Forms;

//создает временный стеклайоут серого цвета в котором индикатор загрузки изаброжения.По окончанию загрузки изаброжения стеклайоут становиться невидимым.
namespace Sandwich
{
    public class imageloader: StackLayout
    {
		public imageloader(Image image)
		{
			this.HorizontalOptions = LayoutOptions.FillAndExpand;
			this.VerticalOptions = LayoutOptions.FillAndExpand;
			this.BackgroundColor = Color.LightSlateGray;

			StackLayout l1 = new StackLayout();
			l1.HorizontalOptions = LayoutOptions.CenterAndExpand;
			l1.VerticalOptions = LayoutOptions.CenterAndExpand;

			var indicator = new ActivityIndicator { Color = Color.Accent };
			indicator.HorizontalOptions = LayoutOptions.Center;
			indicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
			indicator.HeightRequest = 40;
			indicator.BindingContext = image;

			Label loadingimage = new Label();
			loadingimage.Text = "загрузка Изображения ....";
			loadingimage.HorizontalOptions = LayoutOptions.Center;



			this.SetBinding(StackLayout.IsVisibleProperty, "IsRunning");
			this.BindingContext = indicator;


			l1.Children.Add(loadingimage);
			l1.Children.Add(indicator);

			this.Children.Add(l1);

		}
    }
}
