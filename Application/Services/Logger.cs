namespace Infrastructure.Services
{
	public static class Logger
	{
		private static readonly string logPath = "logs.txt";

		public static void Log(string message)
		{
			File.AppendAllText(logPath,
				$"[{DateTime.Now}] {message}{Environment.NewLine}");
		}
	}
}