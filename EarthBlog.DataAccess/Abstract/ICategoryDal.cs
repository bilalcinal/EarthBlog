using EarthBlog.Core.DataAccess;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Abstract;

public interface ICategoryDal: IEntityRepositoryAsync<Category>
{
    Task AddLanguage(CategoryLanguage categoryLanguage);
    Task UpdateLanguage(CategoryLanguage categoryLanguage);
}