using System;
using System.Reflection;
using FoodBook.Infrastructure.Common.ApplicationSettings;
using FoodBook.Infrastructure.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace FoodBook.Infrastructure.EFConfigs
{
    public class BaseDbContext: DbContext
    {
        private readonly DataBaseConfigurations _configurations;

        protected BaseDbContext(DataBaseConfigurations configurations)
        {
            _configurations = configurations;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ResolveDbProvider(_configurations)
                .UseLazyLoadingProxies();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BaseDbContext)));
        }
    }
    
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder ResolveDbProvider(this DbContextOptionsBuilder optionsBuilder, DataBaseConfigurations configurations)
        {
            switch (configurations.Provider)
            {
                case DbProviderType.PostgreSql: return optionsBuilder.UseNpgsql(configurations.ConnectionString);
                case DbProviderType.Sqlite: return  optionsBuilder.UseSqlite(configurations.ConnectionString);
                default: throw new NotImplementedException($"{configurations.Provider} db provider is not supported");
            }
        }
    }
}