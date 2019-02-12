using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.Interfaces.Repositories;

namespace FoodBook.Infrastructure.DataAccess.Services.Repositories.RepositoryProvider
{
    internal interface IRepositoryProvider
    {
        /// <summary>
        /// Gets repository
        /// </summary>
        /// <typeparam name="TEntity">Type of stored entity in repository</typeparam>
        /// <returns>Repository</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}