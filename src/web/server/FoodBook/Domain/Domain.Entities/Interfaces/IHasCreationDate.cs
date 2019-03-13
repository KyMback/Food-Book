using System;

namespace FoodBook.Domain.Entities.Interfaces
{
    public interface IHasCreationDate
    {
        DateTime CreatedOn { get; set; }
    }
}