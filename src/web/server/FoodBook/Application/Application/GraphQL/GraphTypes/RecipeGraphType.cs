using FoodBook.Domain.Entities.Entities.Recipes;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.GraphTypes
{
    internal class RecipeGraphType : BaseEntityGraphType<Recipe>
    {
        protected override void Initialize()
        {
            Field<StringGraphType>().Name("title").Resolve(ctx => ctx.Source.Title);
            Field<StringGraphType>().Name("ingredients").Resolve(ctx => ctx.Source.Ingredients);
            
            base.Initialize();
        }
    }
}