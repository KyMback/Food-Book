using FoodBook.Infrastructure.Common.Services;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Schemas
{
    internal class GraphSchemaProvider : IGraphSchemaProvider
    {
        private readonly IServiceResolver _serviceResolver;
        
        public GraphSchemaProvider(IServiceResolver serviceResolver
        )
        {
            _serviceResolver = serviceResolver;
        }
        
        public Schema ResolveSchema()
        {
            return _serviceResolver.GetService<CommonGraphScheme>();
        }
    }
}