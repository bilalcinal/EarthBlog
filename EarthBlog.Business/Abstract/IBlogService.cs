using EarthBlog.Core.Utilities.Result;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace IAndOthersWebApp.Business.Abstract;

public interface IBlogService
{
    Task<IDataResult<Blog>> GetByBlogIdAsync(int BlogId);
    Task<IDataResult<List<Blog>>> GetBlogListAsync();
    Task<IResult> GetOrderByBlogAsync(Blog Blog);
    Task<IDataResult<Blog>> AddBlogAsync(Blog Blog);
    Task<IResult> UpdateBlogAsync(Blog Blog);
    Task<IResult> DeleteBlogAsync(Blog Blog);
    Task<IResult> AddBlogLanguageAsync(BlogLanguage BlogLanguage);
    Task<IResult> UpdateBlogLanguageAsync(BlogLanguage BlogLanguage);
}