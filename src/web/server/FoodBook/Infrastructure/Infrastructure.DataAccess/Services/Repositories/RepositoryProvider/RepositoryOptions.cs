using FoodBook.Infrastructure.EFConfigs;

namespace FoodBook.Infrastructure.DataAccess.Services.Repositories.RepositoryProvider
{
    internal class RepositoryOptions
    {
        public BaseDbContext BaseDbContext { get; set; }
    }
}