using System;
using FoodBook.Domain.Entities.Entities.Recipes;
using FoodBook.Infrastructure.DataAccess.QuerySettings;

namespace FoodBook.Application.Filters.Recipes
{
    public class RecipeFilter : BaseFilter<Recipe>
    {
        public Guid Id { get; set; }
        
        protected override FilterSettings<Recipe> GetFilterSettings()
        {
            return new FilterSettings<Recipe>().ApplySettings(recipe => recipe.Id == Id);
        }
    }
}