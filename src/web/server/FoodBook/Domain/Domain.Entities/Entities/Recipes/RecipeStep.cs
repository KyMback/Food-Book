using System;

namespace FoodBook.Domain.Entities.Entities.Recipes
{
    public class RecipeStep : BaseEntity
    {
        public string Description { get; set; }

        public int StepNumber { get; set; }

        public Guid RecipeId { get; set; }
    }
}