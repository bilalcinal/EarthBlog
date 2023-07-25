using MimeKit;

namespace EarthBlog.Core.Utilities.Email;

public class Message
{
	public List<MailboxAddress> To { get; set; }

	public string Subject { get; set; }

	public string Content { get; set; }

	[Obsolete]
	public Message(IEnumerable<string> to, string subject, string content)
	{
		To = new List<MailboxAddress>();
		To.AddRange(to.Select((string x) => new MailboxAddress(x, x)));
		Subject = subject;
		Content = content;
	}
}