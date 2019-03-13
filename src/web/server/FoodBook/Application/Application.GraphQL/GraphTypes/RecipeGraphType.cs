using FoodBook.Domain.Entities.Recipes;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.GraphTypes
{
    internal class RecipeGraphType : BaseEntityGraphType<Recipe>
    {
        protected override void Initialize()
        {
            Field<StringGraphType>().Name("title").Resolve(ctx => ctx.Source.Title);
            Field<StringGraphType>().Name("ingredients").Resolve(ctx => ctx.Source.Ingredients);
            Field<StringGraphType>().Name("createdBy").Resolve(ctx => ctx.Source.CreatedBy.Login);
            Field<IntGraphType>().Name("rating").Resolve(ctx => ctx.Source.Rating.RatingNumber);
            Field<DateTimeGraphType>().Name("createdOn").Resolve(ctx => ctx.Source.CreatedOn);
            
            base.Initialize();
        }
    }
}