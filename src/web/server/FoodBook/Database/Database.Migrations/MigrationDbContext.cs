using FoodBook.Infrastructure.Common.ApplicationSettings;
using FoodBook.Infrastructure.EFConfigs;

namespace FoodBook.Database.Migrations
{
    public class MigrationDbContext : BaseDbContext
    {
        internal MigrationDbContext(DataBaseConfigurations configurations) : base(configurations)
        {
        }
    }
}