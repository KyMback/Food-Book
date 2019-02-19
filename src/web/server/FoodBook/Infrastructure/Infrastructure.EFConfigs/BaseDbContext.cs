using FoodBook.Domain.Entities.Entities;
using FoodBook.Domain.Entities.Entities.Recipes;
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
                .UseLazyLoadingProxies()
                .UseSqlite(_connectionString);
        }

        public DbSet<UserAccount> Users { get; set; }
        
        public DbSet<Recipe> Recipes { get; set; }
        
        public DbSet<RecipeStep> RecipeSteps { get; set; }
    }
}