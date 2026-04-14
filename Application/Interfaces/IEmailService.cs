namespace Application.Interfaces
{
	public interface IEmailService
	{
		void Send(string subject, string body);
	}
}