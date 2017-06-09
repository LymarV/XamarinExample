using System;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace XamarinExample.Services.Auth
{
	public interface IAuthHolder
	{
		string Username { get; }

		string ApiCode { get; }

		string AuthToken { get; }

		bool HasToken { get; }

		Task ClearToken();

		Task Save (AuthData authData);

		Task Save(Account account);
	}
}

