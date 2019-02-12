using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;
using FoodBook.Infrastructure.DataAccess.Services.Repositories.RepositoryProvider;

namespace FoodBook.Infrastructure.DataAccess.Services
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryProvider _repositoryProvider;
        
        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }
        
        public async Task<TEntity> Get<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await _repositoryProvider.GetRepository<TEntity>().Get(query);
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await _repositoryProvider.GetRepository<TEntity>().GetAll(query);
        }

        public async Task<PagingResult<TEntity>> GetAllWithPaging<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await _repositoryProvider.GetRepository<TEntity>().GetAllWithPaging(query);
        }

        public async Task<int> Count<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await _repositoryProvider.GetRepository<TEntity>().Count(query);
        }

        public async Task<bool> Any<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await _repositoryProvider.GetRepository<TEntity>().Any(query);
        }

        public async Task<TEntity> InsertOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return await _repositoryProvider.GetRepository<TEntity>().InsertOrUpdate(entity);
        }

        public async Task Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            await _repositoryProvider.GetRepository<TEntity>().Delete(entity);
        }

        public async Task Commit<TEntity>() where TEntity : BaseEntity
        {
            await _repositoryProvider.GetRepository<TEntity>().Commit();
        }
    }
}