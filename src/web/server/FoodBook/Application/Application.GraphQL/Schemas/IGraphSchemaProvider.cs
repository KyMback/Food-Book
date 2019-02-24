using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Schemas
{
    public interface IGraphSchemaProvider
    {
        /// <summary>
        /// Resolved appropriate grapg schema
        /// </summary>
        /// <returns>Resolved graph schema</returns>
        Schema ResolveSchema();
    }
}