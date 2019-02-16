using System.Reflection;
using FoodBook.Infrastructure.Common.ApplicationSettings;
using FoodBook.Infrastructure.EFConfigs;
using Microsoft.EntityFrameworkCore;

namespace FoodBook.Database.Migrations
{
    public class MigrationDbContext : BaseDbContext
    {
        internal MigrationDbContext(DataBaseConfigurations configurations) : base(configurations)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BaseDbContext)));
        }
    }
}