using System;
using System.Reflection;
using Autofac;
using MediatR;
using Module = Autofac.Module;

namespace FoodBook.Application.Common
{
    public class MediatrModule: Module
    {
        private static readonly Type[] MediatrOpenTypes =
        {
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>),
        };
        
        protected override void Load(ContainerBuilder builder)
        {
            foreach (Type mediatrOpenType in MediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }
        }
    }
}