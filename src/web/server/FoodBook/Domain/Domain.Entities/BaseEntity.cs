using System;

namespace FoodBook.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsNew => Id == Guid.Empty;
    }
}