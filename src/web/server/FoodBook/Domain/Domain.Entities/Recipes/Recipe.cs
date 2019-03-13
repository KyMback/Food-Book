using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodBook.Domain.Entities.Interfaces;

namespace FoodBook.Domain.Entities.Recipes
{
    public class Recipe : BaseEntity, IHasCreationDate, IHasCreatedBy
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public virtual Rating Rating { get; set; }

        public Guid CreatedById { get; set; }

        public virtual UserAccount CreatedBy { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<RecipeStep> Steps { get; set; }
    }
}