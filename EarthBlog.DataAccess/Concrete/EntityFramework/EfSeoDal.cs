using EarthBlog.Core.DataAccess.EntityFramework;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.DataAccess.Concrete.Context;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Concrete.EntityFramework;

public class EfSeoDal : EfEntityRepositoryBaseAsync<AppSeo, EarthBlogContext>, ISeoDal
{
    public async Task AddLanguage(AppSeoLanguage appSeoLanguage)
    {
        using var context = new EarthBlogContext();
        context.AppSeoLanguages.Add(appSeoLanguage);
        await context.SaveChangesAsync();
    }

    

    public async Task UpdateLanguage(AppSeoLanguage appSeoLanguage)
    {
        using var context = new EarthBlogContext();
        context.AppSeoLanguages.Update(appSeoLanguage);
        await context.SaveChangesAsync();
    }

   
}