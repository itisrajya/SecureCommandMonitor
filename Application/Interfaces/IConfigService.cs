using Domain.Models;

namespace Application.Interfaces
{
	public interface IConfigService
	{
		Dictionary<string, string> Load(string path);
		AppSettings MapToSettings(Dictionary<string, string> config);
	}
}