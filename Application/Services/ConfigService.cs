using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Services
{
	public class ConfigService : IConfigService
	{
		public Dictionary<string, string> Load(string path)
		{
			var dict = new Dictionary<string, string>();

			foreach (var line in File.ReadAllLines(path))
			{
				if (string.IsNullOrWhiteSpace(line)) continue;

				var parts = line.Split('=');
				if (parts.Length == 2)
				{
					dict[parts[0].Trim()] = parts[1].Trim();
				}
			}

			return dict;
		}

		public AppSettings MapToSettings(Dictionary<string, string> config)
		{
			return new AppSettings
			{
				AllowedCommands = config.ContainsKey("AllowedCommands")
					? config["AllowedCommands"].Split(',').Select(x => x.Trim().ToLower()).ToList()
					: new List<string>()
			};
		}
	}
}