using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XamarinExample.Services.Auth;
using XamarinExample.Utils;

namespace XamarinExample.iOS.Services
{
	public class NativeMessageHandler: NSUrlSessionHandler
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
