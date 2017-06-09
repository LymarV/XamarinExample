using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace XamarinExample.Services.Auth
{
	public class AuthService: IAuthService
	{
		readonly ILoginApi loginApi;
		readonly IAuthHolder authHolder;

		public AuthService (IWebApiFactory webApiFactory, IAuthHolder authHolder)
		{
			this.authHolder = authHolder;
			loginApi = webApiFactory.Create<ILoginApi> ();
		}

		public async Task Login (string username, string password)
		{
			try
			{
				var response = await loginApi.Login (new AuthSignIn (username, password)).ConfigureAwait (false);

				var authData = new AuthData
				{
					Username = username,
					ApiCode = response.Data.Orgs.First ().ApiCode,
					Token = response.Data.AuthToken.ApiKey,
				};

				await authHolder.Save (authData).ConfigureAwait (false);
			}
			catch (ApiException e)
			{
				throw WebApiException.FromRefitException (e);
			}
		}

		public async Task Logout ()
		{
			await authHolder.ClearToken ().ConfigureAwait (false);
			await loginApi.Logout ().ConfigureAwait (false);
		}
	}
}
