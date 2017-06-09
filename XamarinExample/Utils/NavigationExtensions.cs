using Prism.Navigation;
using System.Threading.Tasks;
using XamarinExample.Services.Auth;
using XamarinExample.Views;

namespace XamarinExample.Utils
{
	public static class NavigationExtensions
	{
		public static async Task HandleAppLink (this INavigationService navigationService, string url)
		{
			var authHolder = App.Resolve<IAuthHolder> ();
			if (!authHolder.HasToken)
			{
				// TODO cache link and proceed with it after login
				var page = authHolder.HasToken
						 ? $"/{nameof (ClearNavigationPage)}/{nameof (WelcomePage)}"
						 : $"/{nameof (ClearNavigationPage)}/{nameof (LoginPage)}";

				await navigationService.NavigateAsync (page);
			}
		}
	}
}
