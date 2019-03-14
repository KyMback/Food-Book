using System;

namespace FoodBook.Infrastructure.Common.Extensions
{
    public static class StringExtensions
    {
        public static Guid? ToNullableGuid(this string source)
        {
            if (Guid.TryParse(source, out Guid result))
            {
                return result;
            }

            return null;
        }
    }
}