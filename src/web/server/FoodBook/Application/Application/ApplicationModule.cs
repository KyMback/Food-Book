using Autofac;
using FoodBook.Application.GraphQL.Schemes;

namespace FoodBook.Application
{
    public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommonGraphScheme>()
                .As<CommonGraphScheme>()
                .InstancePerLifetimeScope();
        }
    }
}