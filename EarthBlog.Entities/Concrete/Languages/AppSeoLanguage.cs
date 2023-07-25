using EarthBlog.Core.Entities;
using EarthBlog.Entities.Concrete;

namespace EarthBlog.Entities.Concrete.Languages;

public class AppSeoLanguage : Entity
{
    public int AppSeoId { get; set; }
    public string Language_Code { get; set; }
    public string Title { get; set; }
    public string Keyword { get; set; }
    public string Description { get; set; }
    public virtual AppSeo AppSeo { get; set; }
}