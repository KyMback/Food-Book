using System;
using AutoMapper;
using FoodBook.Application.GraphQL.Extensions;
using FoodBook.Application.GraphQL.Filters;
using FoodBook.Application.GraphQL.Filters.Recipes;
using FoodBook.Application.GraphQL.GraphTypes;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Domain.Recipes;
using FoodBook.Infrastructure.Common;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Schemas
{
    public class CommonGraphScheme : BaseGraphScheme
    {
        private readonly SafeInjection<IRecipeService> _recipeService;
        private readonly SafeInjection<IMapper> _mapper;
        
        public CommonGraphScheme(
            SafeInjection<IRecipeService> recipeService,
            SafeInjection<IMapper> mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;

            InitializeSchema();
        }

        protected override void InitializeTypes()
        {
            InitializeRecipeGraphTypes();
        }

        private void InitializeRecipeGraphTypes()
        {
            AddGraphType<RecipeGraphType>()
                .Name("recipe")
                .Argument<NonNullGraphType<StringGraphType>>("id", "Identifier of recipe")
                .ResolveAsync(async ctx =>
                    await _recipeService.Value.Get(_mapper.Value.Map<RecipeFilter>(ctx).ToQuery()));

            AddGraphType<PagingResultGraphType<RecipeGraphType, Recipe>>()
                .Name("recipes")
                .AddPagingArguments()
                .Argument<StringGraphType>("title", "Title of recipe")
                .Argument<StringGraphType>("ownerId", "Identifier of recipe owner")
                .ResolveAsync(async ctx =>
                    await _recipeService.Value.GetAllWithPaging(_mapper.Value.Map<RecipesFilter>(ctx)
                        .ToQuery()));
        }
    }
}