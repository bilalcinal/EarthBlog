
using EarthBlog.Business.Contants;
using EarthBlog.Core.Utilities.Result;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;
using IAndOthersWebApp.Business.Abstract;

namespace IAndOthersWebApp.Business.Concrete;

public class BlogManager : IBlogService
{
    private readonly IBlogDal _BlogDal;
    public BlogManager(IBlogDal BlogDal)
    {
        _BlogDal = BlogDal;
    }
    public async Task<IDataResult<Blog>> AddBlogAsync(Blog Blog)
    {
        // Blog.SlugUrl = UrlSeoHelper.UrlSeo(Blog.SlugUrl);
        await _BlogDal.AddAsync(Blog);
        return new SuccessDataResult<Blog>(Blog, Messages.AddMessage);
    }

    public async Task<IResult> AddBlogLanguageAsync(BlogLanguage BlogLanguage)
    {
        await _BlogDal.AddLanguage(BlogLanguage);
        return new SuccessResult(Messages.AddMessage);
    }

    public async Task<IResult> DeleteBlogAsync(Blog Blog)
    {
        await _BlogDal.UpdateAsync(Blog);
        return new SuccessResult(Messages.DeleteMessage);
    }

    public async Task<IDataResult<Blog>> GetByBlogIdAsync(int BlogId)
    {
        var row = await _BlogDal.GetFirstOrDefaultAsync(x => x.Id == BlogId,
            x => x.BlogLanguages);
        if (row != null)
        {
            return new SuccessDataResult<Blog>(row);
        }
        return new ErrorDataResult<Blog>(new Blog(), Messages.RecordMessage);
    }

    public async Task<IResult> GetOrderByBlogAsync(Blog Blog)
    {
        await _BlogDal.UpdateAsync(Blog);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IDataResult<List<Blog>>> GetBlogListAsync()
    {
        return new SuccessDataResult<List<Blog>>((await _BlogDal.GetListAsync(x => x.IsActived == true,
            x => x.OrderBy(x => x.OrderBy),
            x => x.BlogLanguages)).ToList());
    }

    public async Task<IResult> UpdateBlogAsync(Blog Blog)
    {
        Blog.SlugUrl = UrlSeoHelper.UrlSeo(Blog.SlugUrl);
        await _BlogDal.UpdateAsync(Blog);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> UpdateBlogLanguageAsync(BlogLanguage BlogLanguage)
    {
        await _BlogDal.UpdateLanguage(BlogLanguage);
        return new SuccessResult(Messages.UpdateMessage);
    }
}