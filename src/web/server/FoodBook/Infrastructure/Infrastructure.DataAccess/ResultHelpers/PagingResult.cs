using System.Collections.Generic;
using FoodBook.Domain.Entities.Entities;

namespace FoodBook.Infrastructure.DataAccess.ResultHelpers
{
    public class PagingResult<TEntity> where TEntity: BaseEntity
    {
        public IEnumerable<TEntity> Entities { get; set; }

        public long Count { get; set; }
    }
}