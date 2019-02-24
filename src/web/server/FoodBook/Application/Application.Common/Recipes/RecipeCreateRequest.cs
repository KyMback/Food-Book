using MediatR;

namespace FoodBook.Application.Common.Recipes
{
    public class RecipeCreateRequest : IRequest<RecipeCreateResponse>
    {
        public string Title { get; set; }

        public string Ingredients { get; set; }
    }
}