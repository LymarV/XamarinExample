using System;

namespace XamarinExample.Services.Settings
{
	public interface ISettingsService
	{
		bool IsDevelopmentMode { get; set; }
		bool IsEverLoggedIn { get; set; }
	}
}
