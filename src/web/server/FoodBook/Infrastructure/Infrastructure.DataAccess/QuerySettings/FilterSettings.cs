using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FoodBook.Domain.Entities;

namespace FoodBook.Infrastructure.DataAccess.QuerySettings
{
    public class FilterSettings<TEntity> where TEntity: BaseEntity
    {
        public ICollection<Expression<Func<TEntity, bool>>> PredicateExpressions { get; private set; }
        
        public FilterSettings()
        {
            PredicateExpressions = new List<Expression<Func<TEntity, bool>>>();
        }

        public FilterSettings<TEntity> ApplySettings(Expression<Func<TEntity, bool>> expression)
        {
            PredicateExpressions.Add(expression);
            
            return this;
        }
    }
}