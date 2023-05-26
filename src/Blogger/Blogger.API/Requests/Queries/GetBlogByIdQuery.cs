using Blogger.API.Models.DataTransferObjects;
using MediatR;

namespace Blogger.API.Requests.Queries;

public record GetBlogByIdQuery(Guid Id) : IRequest<BlogResponse>;
