using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using XamarinExample.Services.Auth;
using Xamarin.Forms;
using Prism.Navigation;
using System;
using XamarinExample.Utils;
using System.IO;
using XamarinExample.Views;
using XamarinExample.Services.Network;
using XamarinExample.Exceptions;

namespace XamarinExample.ViewModels
{
	public class LoginPageViewModel: ViewModelBase
	{
		#region NotifyProperty Username

		private string _Username;
		public string Username
		{
			get { return _Username; }
			set { SetProperty (ref _Username, value); }
		}

		#endregion

		#region NotifyProperty Password

		private string _Password;
		public string Password
		{
			get { return _Password; }
			set { SetProperty (ref _Password, value); }
		}

		#endregion

		readonly IAuthService authService;
		readonly INavigationService navigationService;
		readonly IConnectivityService connectivityService;

		public LoginPageViewModel (IAuthService authService,
		                       INavigationService navigationService,
		                       IConnectivityService connectivityService)
		{
			this.authService = authService;
			this.navigationService = navigationService;
			this.connectivityService = connectivityService;
		}

		#region Command LoginCommand

		public ICommand LoginCommand => new DelegateCommand (Login, CanLogin)
		                                               .ObservesProperty (() => IsLoading);

		async void Login ()
		{
			IsLoading = true;

			await FillDebugCredentials ();

			Exception = null;

			try
			{
				if (!connectivityService.IsNetworkAvailable)
				{
					throw new ConnectivityException ("No Internet Connection");
				}

				await authService.Login (Username, Password);
				await navigationService.NavigateAsync ($"/{nameof (ClearNavigationPage)}/{nameof (WelcomePage)}");
			}
			catch (Exception e)
			{
				Exception = e;
			}

			IsLoading = false;
		}

		bool CanLogin ()
		{
			return !IsLoading;
		}

		#endregion

		#region Command SignUpCommand

		public ICommand SignUpCommand => new DelegateCommand (SignUp);

		void SignUp ()
		{
			var uri = new Uri ("https://app.myXamarinExample.com/sign-up");
			Device.OpenUri (uri);
		}

		#endregion

		async Task FillDebugCredentials ()
		{
#if DEBUG
			if (!string.IsNullOrEmpty (Username))
			{
				return;
			}

			await 10.ConfigureAwaitDelay ();

			using (var stream = ResourceLoader.Load ("Credentials.txt"))
			{
				using (var reader = new StreamReader (stream))
				{
					var text = reader.ReadToEnd ();
					
					var credentials = text.Split (new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
					
					Username = credentials[0];
					Password = credentials[1];
				}
			}
#endif
		}
	}
}
