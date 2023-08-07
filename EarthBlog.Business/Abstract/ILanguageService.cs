using EarthBlog.Core.Utilities.Result;
using EarthBlog.Entities.Concrete;

namespace IAndOthersWebApp.Business.Abstract;

public interface ILanguageService
{
    Task<IDataResult<List<Language>>> GetListLangAsync();
    Task<IDataResult<Language>> GetByIdAsync(int Id);
    Task<IResult> AddAsync(Language language);
    Task<IResult> UpdateAsync(Language language);
}