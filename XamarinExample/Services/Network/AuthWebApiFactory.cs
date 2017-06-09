using System.Net.Http;
using XamarinExample.Services.Auth;

namespace XamarinExample.Services.Network
{
	public class AuthWebApiFactory: WebApiFactory
	{
		readonly IAuthHolder authHolder;
		readonly IHttpMessageHandlerFactory handlerFactory;

		public AuthWebApiFactory (IAuthHolder authHolder, IHttpMessageHandlerFactory handlerFactory)
		{
			this.authHolder = authHolder;
			this.handlerFactory = handlerFactory;
		}

		protected override HttpClient CreateHttpClient ()
		{
			var handler = handlerFactory.Create (authHolder);

			return new HttpClient (handler);
		}
	}
}
