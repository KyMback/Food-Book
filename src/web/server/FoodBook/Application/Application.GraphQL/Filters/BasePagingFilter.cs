using FoodBook.Domain.Entities;
using FoodBook.Infrastructure.DataAccess.QuerySettings;

namespace FoodBook.Application.GraphQL.Filters
{
    public class BasePagingFilter<TEntity>: BaseFilter<TEntity> where TEntity: BaseEntity
    {
        public int From { get; set; }

        public int Count { get; set; }
        
        public override Query<TEntity> ToQuery()
        {
            var query = base.ToQuery();
            query.PageSettings = new PageSettings
            {
                Count = Count,
                From = From
            };
            
            return query;
        }
    }
}