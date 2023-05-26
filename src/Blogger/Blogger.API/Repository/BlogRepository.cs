using Blogger.API.Models;

namespace Blogger.API.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly Dictionary<Guid, Blog> _blogs = new();
  
    
    public async Task<Blog?> GetById(Guid id)
    {
        return await Task.FromResult(_blogs.GetValueOrDefault(id));
    }

    public async Task<Blog> Create(Blog blog)
    {
        _blogs[blog.Id] = blog;
        return await Task.FromResult(blog);
    }
    
}
