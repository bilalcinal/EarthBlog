using EarthBlog.Core.Utilities.Result;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace IAndOthersWebApp.Business.Abstract;

public interface ICategoryService
{
    Task<IDataResult<Category>> GetByCategoryIdAsync(int CategoryId);
    Task<IDataResult<List<Category>>> GetCategoryListAsync();
    Task<IDataResult<List<Category>>> GetCategoryParentListAsync(int CategoryId);
    Task<IDataResult<Category>> AddAsync(Category category);
    Task<IResult> UpdateAsync(Category category);
    Task<IResult> DeleteAsync(Category category);
    Task<IResult> AddLanguageAsync(CategoryLanguage category);
    Task<IResult> UpdateLanguageAsync(CategoryLanguage category);
    Task<IResult> GetOrderByCategoryAsync(Category category);
}
