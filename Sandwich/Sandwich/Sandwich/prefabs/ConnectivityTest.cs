using System;
using System.Collections.Generic;
using System.Text;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Sandwich.prefabs
{
    public class ConnectivityTest
    {
		public ConnectivityTest()
		{
			// Register for connectivity changes, be sure to unsubscribe when finished
			Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

		}
		void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			var access = e.NetworkAccess;
			var profiles = e.ConnectionProfiles;
		}
	}

}
