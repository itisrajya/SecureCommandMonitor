using Domain.Models;

namespace Application.Interfaces
{
	public interface ICommandService
	{
		CommandResult Execute(string command);
	}
}