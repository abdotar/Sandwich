using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sandwich.prefabs
{
    public class Interneterror:StackLayout
    {
		public Interneterror()
		{
			Label nonetlabel = new Label();
			nonetlabel.Text = "Нет интернет соединения";
			nonetlabel.VerticalOptions = LayoutOptions.CenterAndExpand;
			nonetlabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
			this.Children.Add(nonetlabel);
			this.VerticalOptions = LayoutOptions.FillAndExpand;
			this.HorizontalOptions = LayoutOptions.FillAndExpand;
		}

    }
}
