using Blogger.API.Models.DataTransferObjects;
using MediatR;

namespace Blogger.API.Requests.Commands;

public record CreateBlogCommand(CreateBlogRequest BlogRequest) : IRequest<BlogResponse>;
