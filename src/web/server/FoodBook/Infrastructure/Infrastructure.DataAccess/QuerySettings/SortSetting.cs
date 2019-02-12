using System;
using System.Linq.Expressions;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.Enums;

namespace FoodBook.Infrastructure.DataAccess.QuerySettings
{
    public class SortSetting<TEntity> where TEntity: BaseEntity
    {
        public Expression<Func<TEntity, object>> Expression { get; set; }

        public OrderType OrderType { get; set; }
    }
}