using System;
using System.Linq.Expressions;
using AutoMapper;

namespace FoodBook.Infrastructure.Common.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination, TIgnoredValue>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TIgnoredValue>> ignoreExpression)
        {
            return mappingExpression.ForMember(ignoreExpression, cfg => cfg.Ignore());
        }
    }
}