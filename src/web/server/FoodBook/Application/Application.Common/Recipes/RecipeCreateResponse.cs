using System;

namespace FoodBook.Application.Common.Recipes
{
    public class RecipeCreateResponse
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string Ingredients { get; set; }
    }
}