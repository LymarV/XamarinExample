using System;

namespace XamarinExample.Exceptions
{
	public class ConnectivityException : Exception
	{
		public ConnectivityException(string message) : base (message)
		{
			
		}
	}
}
