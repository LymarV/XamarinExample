using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using XamarinExample.Views;
using System.Diagnostics;
using XamarinExample.Services.Auth;
using Xamarin.Forms;

namespace XamarinExample.ViewModels
{
	public class WelcomePageViewModel: ViewModelBase
	{
		readonly INavigationService navigationService;
		readonly IAuthService authService;

		public WelcomePageViewModel (INavigationService navigationService,
		                             IAuthService authService)
		{
			this.navigationService = navigationService;
			this.authService = authService;
		}

		#region Command LogoutCommand

		public ICommand LogoutCommand => new Command (Logout);

		async void Logout ()
		{
#pragma warning disable CS4014 
			// We don't need to await logout. Just show Login screen immediately
			authService.Logout ();
#pragma warning restore CS4014
			await navigationService.NavigateAsync ($"/{nameof (LoginPage)}");
		}

		#endregion
	}
}
