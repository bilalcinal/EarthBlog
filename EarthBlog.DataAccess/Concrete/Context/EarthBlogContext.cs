using EarthBlog.Entities.Concrete;
using EarthBlog.Entities.Concrete.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EarthBlog.DataAccess.Concrete.Context;

    public class EarthBlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string ConnetDeveloper = "server=localhost; port=3306; database=EarthBlogDb; user=root;password=0987654321; Charset=utf8;";
       
        optionsBuilder.UseLazyLoadingProxies()
            .UseMySql(ConnetDeveloper, ServerVersion.AutoDetect(ConnetDeveloper))
            .EnableSensitiveDataLogging()
            .ConfigureWarnings(warnings =>
            {
                warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
            });
    }

    
    public DbSet<Category> Categories { get; set; }
   
    public DbSet<Blog> Blog { get; set; }
    public DbSet<AppSeo> AppSeos { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Slider> Slider { get; set; }

    #region Languages-table
    public DbSet<AppSeoLanguage> AppSeoLanguages { get; set; }
    public DbSet<CategoryLanguage> CategoryLanguages { get; set; }
    public DbSet<BlogLanguage> BlogLanguages { get; set; }
    public DbSet<SliderLanguage> SliderLanguages { get; set; }
    #endregion
    }
