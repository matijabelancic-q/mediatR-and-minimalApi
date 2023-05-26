using System.ComponentModel.DataAnnotations;

namespace Blogger.API.Models.DataTransferObjects;

public class CreateBlogRequest
{
    [EmailAddress]
    public string CreatorEmailAddress { get; set; } = default!;
    public string BlogTitle { get; set; } = default!;
    public string Content { get; set; } = default!;
}
