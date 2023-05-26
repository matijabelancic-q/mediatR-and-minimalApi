using Blogger.API.Models;

namespace Blogger.API.Repository;

public interface IBlogRepository
{
    Task<Blog?> GetById(Guid id);
    Task<Blog> Create(Blog blog);
}
