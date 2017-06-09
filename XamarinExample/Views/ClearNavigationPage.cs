using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace XamarinExample.Views
{
	public class ClearNavigationPage: NavigationPage, INavigationPageOptions
	{
		public bool ClearNavigationStackOnNavigation
		{
			get { return true; }
		}
	}
}