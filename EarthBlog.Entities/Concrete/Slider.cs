using EarthBlog.Core.Entities;

using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.Entities.Concrete;

public class Slider : Entity
{
    public Slider()
    {
        SliderLanguages = new HashSet<SliderLanguage>();
    }
    public bool IsActived { get; set; }
    public string SlugUrl { get; set; }
    public virtual ICollection<SliderLanguage> SliderLanguages { get; set; }
}