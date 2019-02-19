using FoodBook.Infrastructure.DataAccess.DataAccessConfigurations;

namespace FoodBook.Infrastructure.DataAccess.Services.Repositories.RepositoryProvider
{
    internal class RepositoryOptions
    {
        public CommonDbContext BaseDbContext { get; set; }
    }
}