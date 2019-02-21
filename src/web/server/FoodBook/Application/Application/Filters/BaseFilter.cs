using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.QuerySettings;

namespace FoodBook.Application.Filters
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
            return null;
        }

        protected virtual SortSettings<TEntity> GetOrderSettings()
        {
            return null;
        }

        protected virtual IncludeSettings<TEntity> GetIncludeSettings()
        {
            return null;
        }
    }
}