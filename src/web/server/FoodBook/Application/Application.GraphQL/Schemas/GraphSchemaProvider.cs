using FoodBook.Infrastructure.Common.Services;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Schemas
{
    internal class GraphSchemaProvider : IGraphSchemaProvider
    {
        private readonly ISafeServiceResolver _safeServiceResolver;
        
        public GraphSchemaProvider(ISafeServiceResolver safeServiceResolver
        )
        {
            _safeServiceResolver = safeServiceResolver;
        }
        
        public Schema ResolveSchema()
        {
            return _safeServiceResolver.GetService<CommonGraphScheme>();
        }
    }
}