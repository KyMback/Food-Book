using System;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Infrastructure.DataAccess.QuerySettings;

namespace FoodBook.Application.GraphQL.Filters.Recipes
{
    internal class RecipesFilter : BasePagingFilter<Recipe>
    {
        public string Title { get; set; }

        public Guid? UserId { get; set; }
        
        protected override FilterSettings<Recipe> GetFilterSettings()
        {
            FilterSettings<Recipe> builder = base.GetFilterSettings();
            
            if (!string.IsNullOrWhiteSpace(Title))
            {
                builder.ApplySettings(recipe =>
                    recipe.Title.Contains(Title, StringComparison.InvariantCultureIgnoreCase));
            }
            
            if (UserId.HasValue)
            {
                builder.ApplySettings(recipe => recipe.CreatedById == UserId);
            }

            return builder;
        }

        protected override IncludeSettings<Recipe> GetIncludeSettings()
        {
            IncludeSettings<Recipe> builder = base.GetIncludeSettings();

            builder.ApplySettings(recipe => recipe.CreatedBy);

            return builder;
        }
    }
}