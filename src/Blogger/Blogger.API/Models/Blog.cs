namespace Blogger.API.Models;

public class Blog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CreatorEmailAddress { get; set; } 
    public string BlogTitle { get; set; }
    public string Content { get; set; }
}
