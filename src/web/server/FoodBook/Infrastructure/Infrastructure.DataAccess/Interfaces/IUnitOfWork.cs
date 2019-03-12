using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;

namespace FoodBook.Infrastructure.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Retrieves entity by corresponding query
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Found entity</returns>
        Task<TEntity> Get<TEntity>(Query<TEntity> query) where TEntity: BaseEntity;
        
        /// <summary>
        /// Retrieves entities by corresponding query
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Found entities</returns>
        Task<IEnumerable<TEntity>> GetAll<TEntity>(Query<TEntity> query) where TEntity: BaseEntity;

        /// <summary>
        /// Returns paged entities
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Paged entities</returns>
        Task<PagingResult<TEntity>> GetAllWithPaging<TEntity>(Query<TEntity> query) where TEntity: BaseEntity;
        
        /// <summary>
        /// Returns count of entities by corresponding query
        /// </summary>
        /// <param name="query">Query for counting</param>
        /// <returns>Count of entities</returns>
        Task<int> Count<TEntity>(Query<TEntity> query) where TEntity: BaseEntity;

        /// <summary>
        /// Returns true if found at least one entity by corresponding query
        /// </summary>
        /// <param name="query">Query for searching</param>
        Task<bool> Any<TEntity>(Query<TEntity> query) where TEntity: BaseEntity;

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">Entity for updating</param>
        /// <returns>Updated entity</returns>
        Task<TEntity> InsertOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity;

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entity">Entity for deleting</param>
        Task Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;

        /// <summary>
        /// Commits changes
        /// </summary>
        Task Commit();
    }
}