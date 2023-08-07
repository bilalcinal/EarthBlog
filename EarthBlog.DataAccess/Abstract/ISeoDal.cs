using EarthBlog.Core.DataAccess;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Abstract;

public interface ISeoDal : IEntityRepositoryAsync<AppSeo>
{
    Task AddLanguage(AppSeoLanguage appSeoLanguage);
    Task UpdateLanguage(AppSeoLanguage appSeoLanguage);
}