using System;
using FoodBook.Application.Filters.Recipes;
using FoodBook.Application.GraphQL.GraphTypes;
using FoodBook.Domain.Interfaces.Recipes;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Schemes
{
    public class CommonGraphScheme : BaseGraphScheme
    {
        private readonly Lazy<IRecipeService> _recipeService;
        
        public CommonGraphScheme(Lazy<IRecipeService> recipeService)
        {
            _recipeService = recipeService;

            InitializeSchema();
        }

        protected override void InitializeTypes()
        {
            AddGraphType<RecipeGraphType>()
                .Name("recipe")
                .Argument<IdGraphType>("id", "Identifier of recipe")
                .ResolveAsync(async ctx => await _recipeService.Value.Get(new RecipeFilter
                {
                    Id = ctx.GetArgument<Guid>("id")
                }.ToQuery()));
        }
    }
}