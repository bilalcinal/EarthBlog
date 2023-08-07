using EarthBlog.Business.Contants;
using EarthBlog.Core.Utilities.Result;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;
using IAndOthersWebApp.Business.Abstract;
namespace IAndOthersWebApp.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    public async Task<IDataResult<Category>> AddAsync(Category category)
    {
        category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
        await _categoryDal.AddAsync(category);
        return new SuccessDataResult<Category>(category, Messages.AddMessage);
    }

    public async Task<IResult> AddLanguageAsync(CategoryLanguage category)
    {

        await _categoryDal.AddLanguage(category);
        return new SuccessResult(Messages.AddMessage);
    }

    public async Task<IResult> DeleteAsync(Category category)
    {
        await _categoryDal.RemoveAsync(category);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<Category>> GetByCategoryIdAsync(int CategoryId)
    {
        var result = await _categoryDal.GetFirstOrDefaultAsync(x => x.Id == CategoryId, x => x.CategoryLanguages);
        return result != null ? new SuccessDataResult<Category>(result) : new ErrorDataResult<Category>(Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Category>>> GetCategoryListAsync()
    {
        var resultList = await _categoryDal.GetListAsync(x => x.IsActived == true, null,
            x => x.CategoryLanguages);
        return new SuccessDataResult<List<Category>>(resultList.ToList());
    }

    public async Task<IDataResult<List<Category>>> GetCategoryParentListAsync(int CategoryId)
    {
        var resultList = await _categoryDal.GetListAsync(x => x.IsActived == true, null,
            x => x.CategoryLanguages);
        return new SuccessDataResult<List<Category>>(resultList.ToList());
    }

    public async Task<IResult> GetOrderByCategoryAsync(Category category)
    {
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> UpdateAsync(Category category)
    {
        category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> UpdateLanguageAsync(CategoryLanguage category)
    {
        await _categoryDal.UpdateLanguage(category);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
