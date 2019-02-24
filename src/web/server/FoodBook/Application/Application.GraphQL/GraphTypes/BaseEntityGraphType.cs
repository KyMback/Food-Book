using FoodBook.Domain.Entities.Entities;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.GraphTypes
{
    internal class BaseEntityGraphType<TBaseEntity> : BaseGraphType<TBaseEntity> where TBaseEntity : BaseEntity
    {
        protected override void Initialize()
        {
            Field<IdGraphType>().Name("id").Resolve(ctx => ctx.Source.Id);
        }
    }
}