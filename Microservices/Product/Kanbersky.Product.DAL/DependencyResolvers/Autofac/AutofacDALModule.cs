using Autofac;
using Kanbersky.Product.DAL.Concrete.Dapper;

namespace Kanbersky.Product.DAL.DependencyResolvers.Autofac
{
    public class AutofacDALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDbConnection>().As<IProductDbConnection>().SingleInstance();
        }
    }
}
