using FoodBook.Infrastructure.Common.ApplicationSettings;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FoodBook.Database.Migrations
{
    public class MigrationDbContextProvider : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            return new MigrationDbContext(GetDbConfigurations());
        }

        private DataBaseConfigurations GetDbConfigurations()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Personal.json", true)
                .AddEnvironmentVariables();

            return builder.Build().GetSection(nameof(DataBaseConfigurations)).Get<DataBaseConfigurations>();
        }
    }
}