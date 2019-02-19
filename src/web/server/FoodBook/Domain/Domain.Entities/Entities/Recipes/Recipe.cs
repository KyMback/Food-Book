using System.Collections.Generic;

namespace FoodBook.Domain.Entities.Entities.Recipes
{
    public class Recipe : BaseEntity
    {
        public string Title { get; set; }

        public string Ingredients { get; set; }

        public virtual ICollection<RecipeStep> Steps { get; set; }
    }
}