

using EarthBlog.Core.DataAccess.EntityFramework;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.DataAccess.Concrete.Context;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Concrete.EntityFramework;

public class EfCategoryDal : EfEntityRepositoryBaseAsync<Category, EarthBlogContext>, ICategoryDal
{
    public async Task AddLanguage(CategoryLanguage categoryLanguage)
    {
        using var context = new EarthBlogContext();
        context.CategoryLanguages.Add(categoryLanguage);
        await context.SaveChangesAsync();
    }

    public async Task UpdateLanguage(CategoryLanguage categoryLanguage)
    {
        using var context = new EarthBlogContext();
        context.CategoryLanguages.Update(categoryLanguage);
        await context.SaveChangesAsync();
    }
}