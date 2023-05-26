using AutoMapper;
using Blogger.API.Models.DataTransferObjects;
using Blogger.API.Repository;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Blogger.API.Requests.Queries;

public class GetBlogByIdHandler : IRequestHandler<GetBlogByIdQuery, BlogResponse?>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetBlogByIdQuery> _logger;
    private readonly IMemoryCache _cache;

    public GetBlogByIdHandler(IBlogRepository blogRepository, IMapper mapper, ILogger<GetBlogByIdQuery> logger,
        IMemoryCache cache)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
        _logger = logger;
        _cache = cache;
    }


    public async Task<BlogResponse?> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        if (!_cache.TryGetValue($"blogId-{request.Id}", out BlogResponse? blogsDto))
        {
            var blogs = await _blogRepository.GetById(request.Id);
            if (blogs == null)
            {
                _logger.LogInformation("BlogId {Id} is not found!", request.Id);
                return default;
            }

            blogsDto = _mapper.Map<BlogResponse>(blogs);
            _cache.Set($"blogId-{request.Id}", blogsDto, TimeSpan.FromSeconds(60));
        }
        
        return blogsDto;
    }
}
