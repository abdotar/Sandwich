using System;
using System.Collections.Generic;
using System.Text;
using Xamarin;
using Xamarin.Forms;

namespace Sandwich.prefabs
{
    public class Header:StackLayout
    {
		public Header()
		{
			this.Padding = 20;
			Image image = new Image();
			image.Aspect = Aspect.Fill;
			image.Source = ImageSource.FromResource("Sandwich.images.logo2.png");
			image.HorizontalOptions = LayoutOptions.CenterAndExpand;

			this.Children.Add(image);

		}
    }
}
