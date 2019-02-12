using System.Collections.Generic;
using System.Linq;

namespace FoodBook.Infrastructure.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<TEntity>(this IEnumerable<TEntity> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}