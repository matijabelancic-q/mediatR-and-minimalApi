using Blogger.API.Models;

namespace Blogger.API.Services;

public class EmailService : IEmailService
{
    private ILogger<EmailService> Logger { get; }
    public EmailService(ILogger<EmailService> logger)
    {
        Logger = logger;
    }

    public Task<bool> SendEmail(Email email)
    {
        Logger.LogInformation("{EmailSubject} email is succesfuly send to {To}", email.Subject, email.To);
        return Task.FromResult(true);
    }
}
