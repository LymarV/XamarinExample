using System;
using System.IO;
using System.Reflection;

namespace XamarinExample.Utils
{
	public static class ResourceLoader
	{
		public static Stream Load (string name)
		{
			return typeof (ResourceLoader).GetTypeInfo ().Assembly.GetManifestResourceStream ("XamarinExample.Resources." + name);
		}
	}
}
