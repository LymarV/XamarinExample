using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace XamarinExample.Views
{
	public class SimpleNavigationPage : NavigationPage, INavigationPageOptions
	{
		public bool ClearNavigationStackOnNavigation
		{
			get { return false; }
		}
	}
}


