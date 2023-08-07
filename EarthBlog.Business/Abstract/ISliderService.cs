using EarthBlog.Core.Utilities.Result;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace IAndOthersWebApp.Business.Abstract;
public interface ISliderService
{
    Task<IDataResult<Slider>> GetBySliderIdAsync(int SliderId);
    Task<IDataResult<List<Slider>>> GetSliderListAsync();
    Task<IDataResult<Slider>> AddAsync(Slider Slider);
    Task<IResult> UpdateAsync(Slider Slider);
    Task<IResult> DeleteAsync(Slider Slider);
    Task<IResult> AddLanguageAsync(SliderLanguage SliderLanguage);
    Task<IResult> UpdateLanguageAsync(SliderLanguage SliderLanguage);
}