using System.Net.Http;
using XamarinExample.Services.Auth;
using XamarinExample.Services.Network;

namespace XamarinExample.iOS.Services
{
	public class HttpMessageHandlerFactory: IHttpMessageHandlerFactory
	{
		public HttpMessageHandler Create (IAuthHolder authHolder)
		{
			return new NativeMessageHandler (authHolder);
		}
	}
}
