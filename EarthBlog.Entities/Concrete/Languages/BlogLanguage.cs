using EarthBlog.Core.Entities;


namespace EarthBlog.Entities.Concrete.Languages;

public class BlogLanguage : Entity
{
    public int BlogId { get; set; }
    public string Language_Code { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string SubTitle2 { get; set; }
    public string Content { get; set; }
    public virtual Blog Blog { get; set; }
}