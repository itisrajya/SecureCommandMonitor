using System.Diagnostics;
using Application.Interfaces;
using Domain.Models;

namespace Application.Services
{
	public class CommandService : ICommandService
	{
		private readonly List<string> _allowedCommands = new()
		{
			"ipconfig",
			"whoami",
			"netstat",
			"tasklist"
		};

		public CommandResult Execute(string command)
		{
			if (!_allowedCommands.Contains(command.ToLower()))
				throw new UnauthorizedAccessException("Command not allowed.");

			ProcessStartInfo psi = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c " + command,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			using var process = Process.Start(psi);

			string output = process.StandardOutput.ReadToEnd();
			string error = process.StandardError.ReadToEnd();

			process.WaitForExit();

			return new CommandResult
			{
				Command = command,
				Output = output,
				Error = error,
				ExecutedAt = DateTime.Now
			};
		}
	}
}