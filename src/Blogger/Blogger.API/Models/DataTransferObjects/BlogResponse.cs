namespace Blogger.API.Models.DataTransferObjects;

public class BlogResponse
{
    public Guid Id { get; set; }
    public string CreatorEmailAddress { get; set; } = default!;
    public string BlogTitle { get; set; } = default!;
    public string Content { get; set; } = default!;
}
