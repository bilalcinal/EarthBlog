using EarthBlog.Core.Entities;


namespace EarthBlog.Entities.Concrete.Languages;

public class CategoryLanguage : Entity
{
    public int CategoryId { get; set; }
    public string Language_Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }     
    public virtual Category Category { get; set; }
}