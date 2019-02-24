using GraphQL.Types;

namespace FoodBook.Application.GraphQL.GraphTypes
{
    internal abstract class BaseGraphType<TEntity> : ObjectGraphType<TEntity>
    {
        protected BaseGraphType()
        {
            Initialize();
        }

        protected abstract void Initialize();
    }
}