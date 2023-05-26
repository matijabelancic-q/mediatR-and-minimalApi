using AutoMapper;
using Blogger.API.Models;
using Blogger.API.Models.DataTransferObjects;

namespace Blogger.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Blog, CreateBlogRequest>().ReverseMap();
        CreateMap<Blog, BlogResponse>().ReverseMap();
    }
}
