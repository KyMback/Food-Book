using System.Reflection;
using Autofac;
using FoodBook.Infrastructure.DataAccess.DataAccessConfigurations;
using FoodBook.Infrastructure.DataAccess.Interfaces.Repositories;
using FoodBook.Infrastructure.DataAccess.Services.OnBeforeInsertingHandlers;
using FoodBook.Infrastructure.DataAccess.Services.Repositories;
using FoodBook.Infrastructure.EFConfigs;
using Microsoft.EntityFrameworkCore;
using Module = Autofac.Module;

namespace FoodBook.Infrastructure.DataAccess
{
    public class InfrastructureDataAccessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CommonDbContext>()
                .As<CommonDbContext>()
                .InstancePerLifetimeScope();
            
            builder.RegisterGeneric(typeof(Repository<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            RegisterBeforeInsertingHandlers(builder);
        }
        
        private void RegisterBeforeInsertingHandlers(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(CreatedByInsertingHandler<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();            

            builder
                .RegisterGeneric(typeof(CreationByInsertingHandler<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}