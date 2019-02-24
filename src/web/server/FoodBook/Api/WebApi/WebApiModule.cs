using Autofac;
using FoodBook.Infrastructure.Common.Services;

namespace FoodBook.WebApi
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebServiceResolver>()
                .As<IServiceResolver>()
                .InstancePerLifetimeScope();
        }
    }
}