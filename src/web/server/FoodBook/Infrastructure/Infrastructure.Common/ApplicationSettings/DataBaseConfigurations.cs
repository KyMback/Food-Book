using FoodBook.Infrastructure.Common.Enums;

namespace FoodBook.Infrastructure.Common.ApplicationSettings
{
    public class DataBaseConfigurations
    {
        public string ConnectionString { get; set; }

        public DbProviderType Provider { get; set; }
    }
}