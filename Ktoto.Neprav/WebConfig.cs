namespace Ktoto.Neprav
{
	public static class WebConfig
	{
		static WebConfig()
		{
			ResetSchemata = false;
		}

		public static bool ResetSchemata { get; private set; } 
	}
}