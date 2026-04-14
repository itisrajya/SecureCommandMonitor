using Application.Interfaces;

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
	}
}