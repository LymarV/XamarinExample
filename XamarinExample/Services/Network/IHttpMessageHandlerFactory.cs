using System;
using System.Net.Http;
using XamarinExample.Services.Auth;

namespace XamarinExample.Services.Network
{
	public interface IHttpMessageHandlerFactory
	{
		HttpMessageHandler Create (IAuthHolder authHolder);
	}
}
