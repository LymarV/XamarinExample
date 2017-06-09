using Plugin.Settings;

namespace XamarinExample.Services.Settings
{
	public class SettingsService: ISettingsService
	{
		public static bool DefaultDevelopmentMode;

		public bool IsDevelopmentMode
		{
			get { return CrossSettings.Current.GetValueOrDefault (nameof(IsDevelopmentMode), DefaultDevelopmentMode); }
			set { CrossSettings.Current.AddOrUpdateValue (nameof (IsDevelopmentMode), value); }
		}

		public bool IsEverLoggedIn
		{
			get { return CrossSettings.Current.GetValueOrDefault (nameof (IsEverLoggedIn), false); }
			set { CrossSettings.Current.AddOrUpdateValue (nameof (IsEverLoggedIn), value); }
		}
	}
}
