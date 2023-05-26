using Blogger.API.Models;

namespace Blogger.API.Services;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}
