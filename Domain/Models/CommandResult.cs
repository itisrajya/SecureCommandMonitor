namespace Domain.Models
{
	public class CommandResult
	{
		public string Command { get; set; }
		public string Output { get; set; }
		public string Error { get; set; }
		public DateTime ExecutedAt { get; set; }
	}
}