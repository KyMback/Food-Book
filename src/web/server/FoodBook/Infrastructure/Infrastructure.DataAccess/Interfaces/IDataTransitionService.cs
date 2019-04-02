using System.Threading.Tasks;

namespace FoodBook.Infrastructure.DataAccess.Interfaces
{
    public interface IDataTransitionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> Commit();
    }
}