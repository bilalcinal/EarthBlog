using EarthBlog.Core.Utilities.Result;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace IAndOthersWebApp.Business.Abstract;

public interface ISeoService
{
    Task<IDataResult<AppSeo>> GetByAppSeoIdAsync(int SeoId);
    Task<IDataResult<AppSeo>> GetBySeoCodeAsync(string SeoCode);
    Task<IDataResult<AppSeo>> GetByPageNameAsync(string PageName);
    Task<IDataResult<List<AppSeo>>> GetAppSeoStaticListAsync();
    Task<IDataResult<AppSeo>> AddAsync(AppSeo appSeo);
    Task<IResult> UpdateAsync(AppSeo appSeo);
    Task<IResult> DeleteAsync(AppSeo appSeo);
    Task<IResult> AddLanguageAsync(AppSeoLanguage appSeoLanguage);
    Task<IResult> UpdateLanguageAsync(AppSeoLanguage appSeoLanguage);
    Task<string> PageSeoAdd(string SeoCode, List<AppSeoLanguage> appSeoLanguages);
}