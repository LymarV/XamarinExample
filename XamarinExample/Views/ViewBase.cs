using System;
using XamarinExample.ViewModels;
using Xamarin.Forms;

namespace XamarinExample.Views
{
	public abstract class ViewBase: ContentPage
	{
		public ViewModelBase BaseViewModel
		{
			get { return (ViewModelBase)BindingContext; }
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			BaseViewModel.OnAppearing ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			BaseViewModel.OnDisappearing ();
		}
	}
}

