using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FoodBook.Domain.Entities.Entities;

namespace FoodBook.Infrastructure.DataAccess.QuerySettings
{
    public class IncludeSettings<TEntity> where TEntity: BaseEntity
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressionsExpressions { get; private set; }
        
        public IncludeSettings()
        {
            IncludeExpressionsExpressions = new List<Expression<Func<TEntity, object>>>();
        }

        public IncludeSettings<TEntity> ApplySettings(Expression<Func<TEntity, object>> expression)
        {
            IncludeExpressionsExpressions.Add(expression);
            
            return this;
        }

    }
}