using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IConfigService
	{
		Dictionary<string, string> Load(string path);
	}
}