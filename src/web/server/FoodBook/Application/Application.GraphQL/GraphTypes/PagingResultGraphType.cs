using FoodBook.Domain.Entities;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.GraphTypes
{
    internal class PagingResultGraphType<TGraphEntity, TEntity> : BaseGraphType<PagingResult<TEntity>>
        where TEntity : BaseEntity
        where TGraphEntity : BaseEntityGraphType<TEntity>
    {
        protected override void Initialize()
        {
            Field<ListGraphType<TGraphEntity>>().Name("entities").Resolve(context => context.Source.Entities);
            Field<IntGraphType>().Name("count").Resolve(context => context.Source.Count);
        }
    }
}