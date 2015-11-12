namespace StatsdClient.Configuration
{
	using System;
	using System.Configuration;

	public static class AsyncSwitch
	{
		private static readonly bool isOn = Convert.ToBoolean(ConfigurationManager.AppSettings["StatsdAsync"]);

		public static bool IsOn
		{
			get
			{
				return isOn;
			}
		}
	}
}
