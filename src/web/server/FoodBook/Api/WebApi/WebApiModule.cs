using Autofac;
using FoodBook.Infrastructure.Common.Services;
using FoodBook.WebApi.Middleware;

namespace FoodBook.WebApi
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebSafeServiceResolver>()
                .As<ISafeServiceResolver>()
                .InstancePerLifetimeScope();

            builder.RegisterType<WebExecutionContextService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>()
                .InstancePerLifetimeScope();

            RegisterMiddlewares(builder);
        }
        
        private void RegisterMiddlewares(ContainerBuilder builder)
        {
            builder.RegisterType<ExceptionHandlerMiddleware>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<AutofacMiddlewareFactory>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}