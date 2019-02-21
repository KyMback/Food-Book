using FoodBook.Domain.Entities.Entities;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.GraphTypes
{
    internal class BaseEntityGraphType<TBaseEntity> : ObjectGraphType<TBaseEntity> where TBaseEntity : BaseEntity
    {
        protected BaseEntityGraphType()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            Field<IdGraphType>().Name("id").Resolve(ctx => ctx.Source.Id);
        }
    }
}