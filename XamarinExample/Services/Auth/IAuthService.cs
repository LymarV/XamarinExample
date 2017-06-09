using System;
using System.Threading.Tasks;

namespace XamarinExample.Services.Auth
{
	public interface IAuthService
	{
		Task Login (string username, string password);
		Task Logout ();
	}
}
