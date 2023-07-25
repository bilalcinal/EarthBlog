using EarthBlog.Core.Entities;
using EarthBlog.Entities.Concrete.Languages;


namespace EarthBlog.Entities.Concrete;

public class AppSeo : Entity
{
    public AppSeo()
    {
        AppSeoLanguages = new HashSet<AppSeoLanguage>();
    }
    public string AppSeoCode { get; set; }
    public string Home { get; set; }
    public bool IsStaticPage { get; set; }
    public bool IsDinamicPage { get; set; }
    public bool IsActived { get; set; }
    public virtual ICollection<AppSeoLanguage> AppSeoLanguages { get; set; }
}
