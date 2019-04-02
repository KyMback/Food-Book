using GraphQL.Builders;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Extensions
{
    internal static class GraphSchemaExtensions
    {
        public static FieldBuilder<object, object> AddPagingArguments(this FieldBuilder<object, object> builder)
        {
            return builder
                .Argument<NonNullGraphType<IntGraphType>>("from", "Indicates sequence number of first element")
                .Argument<NonNullGraphType<IntGraphType>>("count", "Indicates number of elements");
        }
    }
}