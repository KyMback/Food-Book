using System;

namespace FoodBook.Domain.Entities.Interfaces
{
    public interface IHasCreatedBy
    {
        Guid CreatedById { get; set; }
    }
}