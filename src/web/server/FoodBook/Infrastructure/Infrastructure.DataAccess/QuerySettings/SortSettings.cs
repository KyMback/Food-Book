using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FoodBook.Domain.Entities;
using FoodBook.Infrastructure.DataAccess.Enums;

namespace FoodBook.Infrastructure.DataAccess.QuerySettings
{
    public class SortSettings<TEntity> where TEntity: BaseEntity
    {
        public ICollection<SortSetting<TEntity>> OrderExpressions { get; private set; }

        public SortSettings()
        {
            OrderExpressions = new List<SortSetting<TEntity>>();
        }

        public SortSettings<TEntity> ApplySettings(Expression<Func<TEntity, object>> expression, OrderType orderType)
        {
            OrderExpressions.Add(new SortSetting<TEntity>
            {
                Expression = expression,
                OrderType = orderType
            });
            
            return this;
        }
    }
}