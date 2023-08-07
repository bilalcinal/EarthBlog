using EarthBlog.Core.DataAccess;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Abstract;

public interface ISliderDal : IEntityRepositoryAsync<Slider>
{
    Task AddLanguage(SliderLanguage SliderLanguage);
    Task UpdateLanguage(SliderLanguage SliderLanguage);
}