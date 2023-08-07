using EarthBlog.Business.Contants;
using EarthBlog.Core.Utilities.Result;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;
using IAndOthersWebApp.Business.Abstract;

namespace IAndOthersWebApp.Business.Concrete;

public class SliderManager : ISliderService
{
    private readonly ISliderDal _SliderDal;
    public SliderManager(ISliderDal SliderDal)
    {
        _SliderDal = SliderDal;
    }
    public async Task<IDataResult<Slider>> AddAsync(Slider Slider)
    {
        Slider.SlugUrl = UrlSeoHelper.UrlSeo(Slider.SlugUrl);
        await _SliderDal.AddAsync(Slider);
        return new SuccessDataResult<Slider>(Slider, Messages.AddMessage);
    }

    public async Task<IResult> AddLanguageAsync(SliderLanguage SliderLanguage)
    {
        await _SliderDal.AddLanguage(SliderLanguage);
        return new SuccessResult(Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(Slider Slider)
    {
        await _SliderDal.RemoveAsync(Slider);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<Slider>> GetBySliderIdAsync(int SliderId)
    {
        var row = await _SliderDal.GetFirstOrDefaultAsync(x => x.Id == SliderId,
            x => x.SliderLanguages);
        if (row != null)
        {
            return new SuccessDataResult<Slider>(row);
        }
        return new ErrorDataResult<Slider>(new Slider(), Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Slider>>> GetSliderListAsync()
    {
        return new SuccessDataResult<List<Slider>>((await _SliderDal.GetListAsync(x => x.IsActived == true,
            x => x.OrderByDescending(x => x.Id),
            x => x.SliderLanguages)).ToList());
    }
    public async Task<IResult> UpdateAsync(Slider Slider)
    {
        await _SliderDal.UpdateAsync(Slider);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> UpdateLanguageAsync(SliderLanguage SliderLanguage)
    {
        await _SliderDal.UpdateLanguage(SliderLanguage);
        return new SuccessResult(Messages.UpdateMessage);
    }
}