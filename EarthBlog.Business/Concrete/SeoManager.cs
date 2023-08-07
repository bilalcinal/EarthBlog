using EarthBlog.Business.Contants;
using EarthBlog.Core.Utilities.Result;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;
using IAndOthersWebApp.Business.Abstract;
namespace IAndOthersWebApp.Business.Concrete;

public class SeoManager : ISeoService
{
    private readonly ISeoDal _seoDal;
    public SeoManager(ISeoDal seoDal)
    {
        _seoDal = seoDal;
    }
    public async Task<IDataResult<AppSeo>> AddAsync(AppSeo appSeo)
    {
        await _seoDal.AddAsync(appSeo);
        return new SuccessDataResult<AppSeo>(appSeo, Messages.AddMessage);
    }

    public async Task<IResult> AddLanguageAsync(AppSeoLanguage appSeoLanguage)
    {
        await _seoDal.AddLanguage(appSeoLanguage);
        return new SuccessResult(Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(AppSeo appSeo)
    {
        await _seoDal.RemoveAsync(appSeo);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<List<AppSeo>>> GetAppSeoStaticListAsync()
    {
        return new SuccessDataResult<List<AppSeo>>((await _seoDal.GetListAsync(x => x.IsActived == true && x.IsStaticPage == true,
            x => x.OrderBy(x => x.Id),
            x => x.AppSeoLanguages)).ToList());
    }

    public async Task<IDataResult<AppSeo>> GetByAppSeoIdAsync(int SeoId)
    {
        var row = await _seoDal.GetFirstOrDefaultAsync(x => x.Id == SeoId,
            x => x.AppSeoLanguages);
        if (row != null)
        {
            return new SuccessDataResult<AppSeo>(row);
        }
        return new ErrorDataResult<AppSeo>(new AppSeo(), Messages.RecordMessage);
    }

    public async Task<string> PageSeoAdd(string SeoCode, List<AppSeoLanguage> appSeoLanguages)
    {
        if (SeoCode == string.Empty || SeoCode == null)
        {
            string code = GetId();
            var result = await AddAsync(new AppSeo()
            {
                AppSeoCode = code,
                IsActived = true,
                IsDinamicPage = true,
                IsStaticPage = false,
            });
            if (result.Success)
            {
                foreach (var item in appSeoLanguages)
                {
                    item.AppSeoId = result.Data.Id;
                    await AddLanguageAsync(item);
                }
            }
            return code;
        }
        foreach (var item in appSeoLanguages)
        {
            await UpdateLanguageAsync(item);
        }
        return SeoCode;
    }

    public async Task<IResult> UpdateAsync(AppSeo appSeo)
    {
        await _seoDal.UpdateAsync(appSeo);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> UpdateLanguageAsync(AppSeoLanguage appSeoLanguage)
    {
        await _seoDal.UpdateLanguage(appSeoLanguage);
        return new SuccessResult(Messages.UpdateMessage);
    }
    private static string GetId()
    {
        return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
    }

    public async Task<IDataResult<AppSeo>> GetBySeoCodeAsync(string SeoCode)
    {
        var row = await _seoDal.GetFirstOrDefaultAsync(x => x.AppSeoCode == SeoCode && x.IsDinamicPage == true,
            x => x.AppSeoLanguages);
        return new SuccessDataResult<AppSeo>(row);
    }

    public async Task<IDataResult<AppSeo>> GetByPageNameAsync(string PageName)
    {
        var row = await _seoDal.GetFirstOrDefaultAsync(x => x.Home == PageName,
            x => x.AppSeoLanguages);
        if (row != null)
        {
            return new SuccessDataResult<AppSeo>(row);
        }
        return new ErrorDataResult<AppSeo>(new AppSeo(), Messages.RecordMessage);
    }
}