using FoodBook.Infrastructure.Common.ApplicationSettings;
using Microsoft.EntityFrameworkCore;

namespace FoodBook.Infrastructure.EFConfigs
{
    public class BaseDbContext: DbContext
    {
        private readonly string _connectionString;

        protected BaseDbContext(DataBaseConfigurations configurations)
        {
            _connectionString = configurations.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(_connectionString);
        }
    }
}