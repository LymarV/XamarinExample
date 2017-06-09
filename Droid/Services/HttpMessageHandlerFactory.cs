using System;
using System.Net.Http;
using XamarinExample.Services.Auth;
using XamarinExample.Services.Network;

namespace XamarinExample.Droid.Services
{
	public class HttpMessageHandlerFactory: IHttpMessageHandlerFactory
	{
		public HttpMessageHandler Create (IAuthHolder authHolder)
		{
			return new NativeMessageHandler (authHolder);
		}
	}
}
