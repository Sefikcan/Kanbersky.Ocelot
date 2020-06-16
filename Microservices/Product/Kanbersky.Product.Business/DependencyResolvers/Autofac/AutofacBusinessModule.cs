using Autofac;
using Kanbersky.Product.Business.Abstract;
using Kanbersky.Product.Business.Concrete;

namespace Kanbersky.Product.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
        }
    }
}
