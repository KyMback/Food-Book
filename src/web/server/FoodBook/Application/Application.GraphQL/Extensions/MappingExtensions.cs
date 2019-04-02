using AutoMapper;
using FoodBook.Application.GraphQL.Filters;
using FoodBook.Domain.Entities;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Extensions
{
    internal static class MappingExtensions
    {
        internal static IMappingExpression<TSource, TDestination> UseBasePagingFilter<TSource, TDestination,
            TDestinationMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression) 
            where TDestinationMember : BaseEntity
            where TDestination : BasePagingFilter<TDestinationMember>
            where TSource : ResolveFieldContext<object>
        {
            return mappingExpression
                .UseBaseFilter<TSource, TDestination, TDestinationMember>()
                .ForMember(d => d.From, ctx => ctx.MapFrom(s => s.GetArgument<int>("from", default(int))))
                .ForMember(d => d.Count, ctx => ctx.MapFrom(s => s.GetArgument<int>("count", default(int))));
        }
        
        internal static IMappingExpression<TSource, TDestination> UseBaseFilter<TSource, TDestination,
            TDestinationMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression) 
            where TDestinationMember : BaseEntity
            where TDestination : BaseFilter<TDestinationMember>
            where TSource : ResolveFieldContext<object>
        {
            return mappingExpression
                .ForMember(d => d.IsReadonly, o => o.MapFrom(s => false));
        }
    }
}