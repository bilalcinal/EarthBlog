using EarthBlog.Core.Entities;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.Entities.Concrete;

public class Category : Entity
{
    public Category()
    {
        CategoryLanguages = new HashSet<CategoryLanguage>();
    }
    public bool IsActived { get; set; }
    public string SlugUrl { get; set; }
    public virtual ICollection<CategoryLanguage> CategoryLanguages{ get; set; }
   
}