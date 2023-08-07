using EarthBlog.Core.DataAccess.EntityFramework;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.DataAccess.Concrete.Context;

using EarthBlog.Entities.Concrete;

namespace EarthBlog.DataAccess.Concrete.EntityFramework;

public class EfLanguageDal : EfEntityRepositoryBaseAsync<Language, EarthBlogContext>, ILanguageDal
{

}