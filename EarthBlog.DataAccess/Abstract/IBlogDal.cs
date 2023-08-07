using EarthBlog.Core.DataAccess;
using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;

namespace EarthBlog.DataAccess.Abstract;

public interface IBlogDal : IEntityRepositoryAsync<Blog>
{
    Task AddLanguage(BlogLanguage BlogLanguage);
    Task UpdateLanguage(BlogLanguage BlogLanguage);    
}