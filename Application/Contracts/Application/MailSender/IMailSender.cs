namespace PowerKlubbAPI.Application.Contracts.Application.MailSender;

using Models;

public interface IMailSender
{
	Task<bool> SendMailAsync(Email email);
}
