using FoodBook.Domain.Entities;
using FoodBook.Infrastructure.DataAccess.QuerySettings;

namespace FoodBook.Application.GraphQL.Filters
{
    public class BaseFilter<TEntity> where TEntity: BaseEntity
    {
        public bool IsReadonly { get; set; } = true;
        
        public virtual Query<TEntity> ToQuery()
        {
            return new Query<TEntity>
            {
                SortSettings = GetOrderSettings(),
                FilterSettings = GetFilterSettings(),
                IncludeSettings = GetIncludeSettings(),
                IsTracked = !IsReadonly
            };
        }

        protected virtual FilterSettings<TEntity> GetFilterSettings()
        {
            return new FilterSettings<TEntity>();
        }

        protected virtual SortSettings<TEntity> GetOrderSettings()
        {
            return new SortSettings<TEntity>();
        }

        protected virtual IncludeSettings<TEntity> GetIncludeSettings()
        {
            return new IncludeSettings<TEntity>();
        }
    }
}