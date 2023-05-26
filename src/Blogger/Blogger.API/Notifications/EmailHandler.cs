using Blogger.API.Models;
using Blogger.API.Services;
using MediatR;

namespace Blogger.API.Notifications;

public class EmailHandler : INotificationHandler<BlogCreatedNotification>
{
    private readonly IEmailService _emailService;
    private readonly ILogger<BlogCreatedNotification> _logger;
    public EmailHandler(IEmailService emailService, ILogger<BlogCreatedNotification> logger)
    {
        _emailService = emailService;
        _logger = logger;
    }
    public async Task Handle(BlogCreatedNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            var email = new Email() 
            { 
                To = notification.Blog.CreatorEmailAddress,
                Subject = $"Blog {notification.Blog.BlogTitle} was created!",
                Body = "Hey buddy, your blog is created successfully!"
            };
            
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogError("Blog {Id} failed due to an error with the mail service: {ExMessage}", notification.Blog.Id, ex.Message);
        }
    }
}