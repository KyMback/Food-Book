using System;
using AutoMapper;
using FoodBook.Application.GraphQL.Extensions;
using FoodBook.Application.GraphQL.Filters;
using FoodBook.Application.GraphQL.Filters.Recipes;
using FoodBook.Domain.Entities.Recipes;
using GraphQL.Types;
using JetBrains.Annotations;

namespace FoodBook.Application.GraphQL.MappingProfiles
{
    [UsedImplicitly]
    internal class ConvertersMappingProfile : Profile
    {
        public ConvertersMappingProfile()
        {
            CreateMap<ResolveFieldContext<object>, RecipeFilter>()
                .UseBaseFilter<ResolveFieldContext<object>, RecipeFilter, Recipe>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.GetArgument<Guid>("id", default(Guid))));
            
            CreateMap<ResolveFieldContext<object>, BasePagingFilter<Recipe>>()
                .UseBasePagingFilter<ResolveFieldContext<object>, BasePagingFilter<Recipe>, Recipe>();
        }
    }
}