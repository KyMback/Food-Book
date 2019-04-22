using System;

namespace FoodBook.Application.Common.Recipes.Update
{
    public class RecipeUpdateResponse
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string Ingredients { get; set; }
    }
}