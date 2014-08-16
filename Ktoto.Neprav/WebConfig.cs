namespace Ktoto.Neprav
{
	public static class WebConfig
	{
		static WebConfig()
		{
			ResetSchemata = true;
		}

		public static bool ResetSchemata { get; private set; } 
	}
}