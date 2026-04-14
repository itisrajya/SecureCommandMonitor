using System.Net;
using System.Net.Mail;
using Application.Interfaces;

namespace Infrastructure.Services
{
	public class EmailService : IEmailService
	{
		private readonly Dictionary<string, string> _config;

		public EmailService(Dictionary<string, string> config)
		{
			_config = config;
		}

		public void Send(string subject, string body)
		{
			var message = new MailMessage
			{
				From = new MailAddress(_config["From"]),
				Subject = subject,
				Body = body
			};

			message.To.Add(_config["To"]);

			var smtp = new SmtpClient(_config["SmtpServer"], int.Parse(_config["Port"]))
			{
				Credentials = new NetworkCredential(_config["From"], _config["Password"]),
				EnableSsl = true
			};

			smtp.Send(message);
		}
	}
}