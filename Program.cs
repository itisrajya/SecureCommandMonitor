using Application.Interfaces;
using Application.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

class Program
{
	static void Main(string[] args)
	{
		// Setup DI
		var serviceProvider = new ServiceCollection()
			.AddSingleton<IConfigService, ConfigService>()
			.BuildServiceProvider();

		var configService = serviceProvider.GetRequiredService<IConfigService>();

		var config = configService.Load("config.txt");
		var settings = configService.MapToSettings(config);

		// Register remaining services with settings
		var services = new ServiceCollection()
			.AddSingleton(settings)
			.AddSingleton<ICommandService, CommandService>()
			.AddSingleton<IEmailService>(sp => new EmailService(config))
			.BuildServiceProvider();

		var commandService = services.GetRequiredService<ICommandService>();
		var emailService = services.GetRequiredService<IEmailService>();

		try
		{
			Console.WriteLine("=== Secure Command Monitor ===");

			var allowedCommands = commandService.GetAllowedCommands();
			Console.WriteLine("Allowed Commands: " + string.Join(", ", allowedCommands));

			Console.Write("Enter command: ");
			string command = Console.ReadLine()?.Trim().ToLower();

			if (string.IsNullOrEmpty(command))
			{
				Console.WriteLine("Invalid input.");
				return;
			}

			var result = commandService.Execute(command);

			Logger.Log($"Command: {result.Command}");
			Logger.Log($"Output: {result.Output}");

			string body = result.Output;
			if (!string.IsNullOrEmpty(result.Error))
				body += "\nERROR:\n" + result.Error;

			emailService.Send($"CMD Execution Result for [{command}]", body);

			Console.WriteLine("\nSuccess");
		}
		catch (UnauthorizedAccessException ex)
		{
			Logger.Log("SECURITY ALERT: " + ex.Message);
			Console.WriteLine("\n❌ " + ex.Message);
		}
		catch (Exception ex)
		{
			Logger.Log("ERROR: " + ex.Message);
			Console.WriteLine("\nError: " + ex.Message);
		}

		Console.ReadKey();
	}
}