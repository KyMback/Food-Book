using Autofac;

namespace FoodBook.Infrastructure.Services
{
    public class InfrastructureServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}