using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XamarinExample.Services.Auth;
using XamarinExample.Utils;
using Xamarin.Android.Net;

namespace XamarinExample.Droid.Services
{
	public class NativeMessageHandler: AndroidClientHandler
	{
		readonly IAuthHolder authHolder;

		public NativeMessageHandler (IAuthHolder authHolder)
		{
			this.authHolder = authHolder;
		}

		protected override Task<HttpResponseMessage> SendAsync (HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.InjectAuthToken (authHolder);

			return base.SendAsync (request, cancellationToken);
		}
	}
}
