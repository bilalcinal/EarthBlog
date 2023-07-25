namespace EarthBlog.Core.Utilities.Email.Abstract;

public interface IEmailSender
{
	void SendEmail(Message message);
}