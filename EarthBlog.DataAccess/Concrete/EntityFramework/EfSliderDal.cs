using EarthBlog.Core.DataAccess.EntityFramework;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.DataAccess.Concrete.Context;

using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Concrete.EntityFramework;

public class EfSliderDal : EfEntityRepositoryBaseAsync<Slider, EarthBlogContext>, ISliderDal
{
    public async Task AddLanguage(SliderLanguage SliderLanguage)
    {
        using var context = new EarthBlogContext();
        context.SliderLanguages.Add(SliderLanguage);
        await context.SaveChangesAsync();
    }

    public async Task UpdateLanguage(SliderLanguage SliderLanguage)
    {
        using var context = new EarthBlogContext();
        context.SliderLanguages.Update(SliderLanguage);
        await context.SaveChangesAsync();
    }
}