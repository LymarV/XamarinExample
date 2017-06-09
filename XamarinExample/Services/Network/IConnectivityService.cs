using System.Threading.Tasks;

namespace XamarinExample.Services.Network
{
	public interface IConnectivityService
	{
		bool IsNetworkAvailable { get; }
	}
}
