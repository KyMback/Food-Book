using Autofac;
using FoodBook.Application.GraphQL.Schemas;
using GraphQL;

namespace FoodBook.Application.GraphQL
{
    public class GraphQLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommonGraphScheme>()
                .As<CommonGraphScheme>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GraphSchemaProvider>()
                .As<IGraphSchemaProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DocumentExecuter>()
                .As<IDocumentExecuter>()
                .InstancePerLifetimeScope();
        }
    }
}