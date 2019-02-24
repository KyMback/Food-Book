using System;
using AutoMapper;
using FoodBook.Application.GraphQL.Extensions;
using FoodBook.Application.GraphQL.Filters;
using FoodBook.Application.GraphQL.Filters.Recipes;
using FoodBook.Application.GraphQL.GraphTypes;
using FoodBook.Domain.Entities.Entities.Recipes;
using FoodBook.Domain.Interfaces.Recipes;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Schemas
{
    public class CommonGraphScheme : BaseGraphScheme
    {
        private readonly Lazy<IRecipeService> _recipeService;
        private readonly Lazy<IMapper> _mapper;
        
        public CommonGraphScheme(
            Lazy<IRecipeService> recipeService,
            Lazy<IMapper> mapper)
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
                .Argument<IdGraphType>("id", "Identifier of recipe")
                .ResolveAsync(async ctx =>
                    await _recipeService.Value.Get(_mapper.Value.Map<RecipeFilter>(ctx).ToQuery()));

            AddGraphType<PagingResultGraphType<RecipeGraphType, Recipe>>()
                .Name("recipes")
                .AddPagingArguments()
                .ResolveAsync(async ctx =>
                    await _recipeService.Value.GetAllWithPaging(_mapper.Value.Map<BasePagingFilter<Recipe>>(ctx)
                        .ToQuery()));
        }
    }
}