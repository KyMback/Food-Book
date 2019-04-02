using System.Threading.Tasks;
using FoodBook.Infrastructure.DataAccess.DataAccessConfigurations;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using JetBrains.Annotations;

namespace FoodBook.Infrastructure.DataAccess.Services
{
    [UsedImplicitly]
    internal class DataTransitionService : IDataTransitionService
    {
        private readonly CommonDbContext _context;

        public DataTransitionService(CommonDbContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}