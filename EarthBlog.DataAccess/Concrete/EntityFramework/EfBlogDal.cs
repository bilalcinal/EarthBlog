

using EarthBlog.Core.DataAccess.EntityFramework;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.DataAccess.Concrete.Context;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Concrete.EntityFramework;

public class EfBlogDal : EfEntityRepositoryBaseAsync<Blog, EarthBlogContext>, IBlogDal
{
    public async Task AddLanguage(BlogLanguage ProductLanguage)
    {
        using var context = new EarthBlogContext();
        context.BlogLanguages.Add(ProductLanguage);
        await context.SaveChangesAsync();
    }

    public async Task UpdateLanguage(BlogLanguage ProductLanguage)
    {
        using var context = new EarthBlogContext();
        context.BlogLanguages.Update(ProductLanguage);
        await context.SaveChangesAsync();
    }
}