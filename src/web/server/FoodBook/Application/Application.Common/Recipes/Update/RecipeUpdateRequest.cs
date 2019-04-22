using System;
using MediatR;

namespace FoodBook.Application.Common.Recipes.Update
{
    public class RecipeUpdateRequest : IRequest<RecipeUpdateResponse>
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string Ingredients { get; set; }
    }
}