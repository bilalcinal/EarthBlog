using EarthBlog.Core.Entities;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.Entities.Concrete;

public class Blog : Entity
{
    public Blog()
    {
        BlogLanguages = new HashSet<BlogLanguage>();
    }
    public string FileCode { get; set; }
    public string UrlCode { get; set; }
    public int OrderBy { get; set; }
    public bool IsActived { get; set; }
    public string SlugUrl { get; set; }
    public virtual ICollection<BlogLanguage> BlogLanguages { get; set; }
}