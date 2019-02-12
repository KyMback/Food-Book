using FoodBook.Infrastructure.Common.ApplicationSettings;
using FoodBook.Infrastructure.EFConfigs;

namespace FoodBook.Infrastructure.DataAccess.DataAccessConfigurations
{
    public class CommonDbContext: BaseDbContext
    {
        public CommonDbContext(DataBaseConfigurations configurations) : base(configurations)
        {
        }
    }
}