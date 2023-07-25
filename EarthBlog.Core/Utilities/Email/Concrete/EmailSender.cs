using EarthBlog.Core.Utilities.Email.Abstract;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace EarthBlog.Core.Utilities.Email.Concrete;

public class EmailSender : IEmailSender
{
	private readonly EmailConfiguration _emailConfig;

	public readonly ILogger<EmailSender> _logger;

	public EmailSender(IOptions<EmailConfiguration> emailConfig, ILogger<EmailSender> logger)
	{
		_emailConfig = emailConfig.Value;
		_logger = logger;
	}

	[Obsolete]
	public void SendEmail(Message message)
	{
		var emailMessage = CreateEmailMessage(message);
		Send(emailMessage);
	}

	[Obsolete]
	private MimeMessage CreateEmailMessage(Message message)
	{
		var mimeMessage = new MimeMessage();
		mimeMessage.From.Add(new MailboxAddress("", _emailConfig.From));
		mimeMessage.To.AddRange(message.To);
		mimeMessage.Subject = message.Subject;
		mimeMessage.Body = new TextPart(TextFormat.Html)
		{
			Text = message.Content
		};
		return mimeMessage;
	}

	private void Send(MimeMessage mailMessage)
	{
		using var client = new SmtpClient();
		try
		{
			client.ServerCertificateValidationCallback = (s, c, h, e) => true;
			client.Connect(_emailConfig.SmtpServer, _emailConfig.Port);
			client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
			client.Send(mailMessage);
		}
		catch (Exception ex)
		{
			_logger.LogError("mail-hata: " + ex.Message);
			throw;
		}
		finally
		{
			client.Disconnect(quit: true);
			client.Dispose();
		}
	}
}