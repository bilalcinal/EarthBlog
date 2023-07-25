using EarthBlog.Core.Entities;


namespace EarthBlog.Entities.Concrete.Languages;

public class SliderLanguage:Entity
{
    public int SliderId { get; set; }
    public string Language_Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual Slider Slider { get; set; }
}