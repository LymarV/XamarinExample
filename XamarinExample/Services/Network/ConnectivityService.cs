using Plugin.Connectivity;

namespace XamarinExample.Services.Network
{
	public class ConnectivityService: IConnectivityService
	{
		public ConnectivityService ()
		{
			
		}

		public bool IsNetworkAvailable => CrossConnectivity.Current.IsConnected;
	}
}
