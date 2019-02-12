using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.QuerySettings;

namespace FoodBook.Application.Filters
{
    public abstract class BaseFilter<TEntity> where TEntity: BaseEntity
    {
        public bool IsReadonly { get; set; } = true;
        
        public virtual Query<TEntity> ToQuery()
        {
            return new Query<TEntity>
            {
                SortSettings = GetOrderSettings(),
                FilterSettings = GetFilterSettings(),
                IsTracked = !IsReadonly
            };
        }

        protected abstract FilterSettings<TEntity> GetFilterSettings();
        
        protected abstract SortSettings<TEntity> GetOrderSettings();
    }
}