using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;

namespace FoodBook.Infrastructure.DataAccess.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        /// <summary>
        /// Retrieves entity by corresponding query
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Found entity</returns>
        Task<TEntity> Get(Query<TEntity> query);
        
        /// <summary>
        /// Retrieves entities by corresponding query
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Found entities</returns>
        Task<IEnumerable<TEntity>> GetAll(Query<TEntity> query);

        /// <summary>
        /// Returns paged entities
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Paged entities</returns>
        Task<PagingResult<TEntity>> GetAllWithPaging(Query<TEntity> query);
        
        /// <summary>
        /// Returns count of entities by corresponding query
        /// </summary>
        /// <param name="query">Query for counting</param>
        /// <returns>Count of entities</returns>
        Task<int> Count(Query<TEntity> query);

        /// <summary>
        /// Returns true if found at least one entity by corresponding query
        /// </summary>
        /// <param name="query">Query for searching</param>
        Task<bool> Any(Query<TEntity> query);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">Entity for updating</param>
        /// <returns>Updated entity</returns>
        Task<TEntity> InsertOrUpdate(TEntity entity);

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entity">Entity for deleting</param>
        Task Delete(TEntity entity);
        
        /// <summary>
        /// Commits changes
        /// </summary>
        Task Commit();
    }
}