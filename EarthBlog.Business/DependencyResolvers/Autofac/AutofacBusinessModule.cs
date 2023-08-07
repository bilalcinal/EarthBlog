using Autofac;
using EarthBlog.DataAccess.Abstract;
using EarthBlog.DataAccess.Concrete.EntityFramework;
using IAndOthersWebApp.Business.Abstract;
using IAndOthersWebApp.Business.Concrete;

namespace IAndOthersWebApp.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region Category
        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
        #endregion Category

        #region Language
        builder.RegisterType<LanguageManager>().As<ILanguageService>();
        builder.RegisterType<EfLanguageDal>().As<ILanguageDal>();
        #endregion Language

        #region Service
        builder.RegisterType<BlogManager>().As<IBlogService>();
        builder.RegisterType<EfBlogDal>().As<IBlogDal>();
        #endregion
        
        #region Slider
        builder.RegisterType<SliderManager>().As<ISliderService>();
        builder.RegisterType<EfSliderDal>().As<ISliderDal>();
        #endregion
       

        #region Seo
        builder.RegisterType<SeoManager>().As<ISeoService>();
        builder.RegisterType<EfSeoDal>().As<ISeoDal>();
        #endregion

        
    }
}