using System;

namespace FoodBook.Domain.Entities
{
    public class Rating : BaseEntity
    {
        public Guid EntityId { get; set; }
        
        public int RatingNumber { get; set; }
    }
}