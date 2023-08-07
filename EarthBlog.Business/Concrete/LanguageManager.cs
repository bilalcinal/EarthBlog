using EarthBlog.Business.Contants;
using EarthBlog.Core.Utilities.Result;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.Entities.Concrete;
using IAndOthersWebApp.Business.Abstract;
namespace IAndOthersWebApp.Business.Concrete;

public class LanguageManager : ILanguageService
{
    private readonly ILanguageDal _languageDal;
    public LanguageManager(ILanguageDal languageDal)
    {
        _languageDal = languageDal;
    }
    public async Task<IResult> AddAsync(Language language)
    {
        await _languageDal.AddAsync(language);
        return new SuccessResult(Messages.AddMessage);
    }

    public async Task<IDataResult<Language>> GetByIdAsync(int Id)
    {
        var languageRow = await _languageDal.GetAsync(Id);
        return languageRow != null
            ? new SuccessDataResult<Language>(languageRow)
            : new ErrorDataResult<Language>(languageRow, Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Language>>> GetListLangAsync()
    {
        var languageList = await _languageDal.GetListAsync(x => x.IsActived == true);
        return new SuccessDataResult<List<Language>>(languageList.ToList());
    }

    public async Task<IResult> UpdateAsync(Language language)
    {
        await _languageDal.UpdateAsync(language);
        return new SuccessResult(Messages.UpdateMessage);
    }
}