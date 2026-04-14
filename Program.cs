using Application.Interfaces;
using Application.Services;
using Infrastructure.Services;

class Program
{
	static void Main(string[] args)
	{
		try
		{
			// Load Config
			IConfigService configService = new ConfigService();
			var config = configService.Load("config.txt");

			// Initialize Services
			ICommandService commandService = new CommandService();
			IEmailService emailService = new EmailService(config);

			string command = "ipconfig";

			var result = commandService.Execute(command);

			// Logging
			Logger.Log($"Command: {result.Command}");
			Logger.Log($"Output: {result.Output}");

			// Email
			string body = result.Output;
			if (!string.IsNullOrEmpty(result.Error))
				body += "\nERROR:\n" + result.Error;

			emailService.Send("CMD Execution Result", body);

			Console.WriteLine("Executed and email sent successfully.");
		}
		catch (Exception ex)
		{
			Logger.Log("ERROR: " + ex.Message);
			Console.WriteLine("Error: " + ex.Message);
		}

		Console.ReadKey();
	}
}