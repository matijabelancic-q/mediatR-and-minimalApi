using Blogger.API.Models;
using MediatR;

namespace Blogger.API.Notifications;

public record BlogCreatedNotification(Blog Blog) : INotification;
