using System;
using AutoMapper;
using FoodBook.Application.GraphQL.Extensions;
using FoodBook.Application.GraphQL.Filters;
using FoodBook.Application.GraphQL.Filters.Recipes;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Infrastructure.Common.Extensions;
using GraphQL.Types;
using GraphQL.Utilities;
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
                .ForMember(d => d.Id, o => o.MapFrom(s => new Guid(s.GetArgument("id", default(string)))));

            CreateMap<ResolveFieldContext<object>, RecipesFilter>()
                .UseBasePagingFilter<ResolveFieldContext<object>, RecipesFilter, Recipe>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.GetArgument("title", default(string))))
                .ForMember(d => d.UserId,
                    o => o.MapFrom(s => s.GetArgument("ownerId", default(string)).ToNullableGuid()));

        }
    }
}