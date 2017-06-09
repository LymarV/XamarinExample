using System;
using System.Diagnostics;

namespace XamarinExample
{
	public class Logger
	{
		public static void Log (object message)
		{
			Debug.WriteLine (message);
		}
	}
}
