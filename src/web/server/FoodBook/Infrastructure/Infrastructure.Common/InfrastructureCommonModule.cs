using Autofac;

namespace FoodBook.Infrastructure.Common
{
    public class InfrastructureCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(SafeInjection<>))
                .AsSelf()
                .SingleInstance();
        }
    }
}