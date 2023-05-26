using AutoMapper;
using Blogger.API.Models;
using Blogger.API.Models.DataTransferObjects;
using Blogger.API.Notifications;
using Blogger.API.Repository;
using MediatR;

namespace Blogger.API.Requests.Commands;

public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, BlogResponse>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateBlogCommand> _logger;
    private readonly IMediator _mediator;

    public CreateBlogHandler(IBlogRepository blogRepository, IMapper mapper, ILogger<CreateBlogCommand> logger,
        IMediator mediator)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator;
    }

    public async Task<BlogResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blogEntity = _mapper.Map<Blog>(request.BlogRequest);
        var newBlog = await _blogRepository.Create(blogEntity);

        await _mediator.Publish(new BlogCreatedNotification(newBlog), cancellationToken);

        _logger.LogInformation("Blog {Id} is successfully created", newBlog.Id);

        var blogsResponse = _mapper.Map<BlogResponse>(newBlog);

        return blogsResponse;
    }
}
