using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.Common.Services;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using FoodBook.Infrastructure.DataAccess.Interfaces.Repositories;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;
using JetBrains.Annotations;

namespace FoodBook.Infrastructure.DataAccess.Services
{
    [UsedImplicitly]
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IDataTransitionService _dataTransitionService;
        private readonly IServiceResolver _serviceResolver;
        
        public UnitOfWork(
            IDataTransitionService dataTransitionService,
            IServiceResolver serviceResolver)
        {
            _dataTransitionService = dataTransitionService;
            _serviceResolver = serviceResolver;
        }
        
        public async Task<TEntity> Get<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await GetRepository<TEntity>().Get(query);
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await GetRepository<TEntity>().GetAll(query);
        }

        public async Task<PagingResult<TEntity>> GetAllWithPaging<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await GetRepository<TEntity>().GetAllWithPaging(query);
        }

        public async Task<int> Count<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await GetRepository<TEntity>().Count(query);
        }

        public async Task<bool> Any<TEntity>(Query<TEntity> query) where TEntity : BaseEntity
        {
            return await GetRepository<TEntity>().Any(query);
        }

        public async Task<TEntity> InsertOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return await GetRepository<TEntity>().InsertOrUpdate(entity);
        }

        public async Task Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            await GetRepository<TEntity>().Delete(entity);
        }

        public async Task Commit()
        {
            await _dataTransitionService.Commit();
        }
        
        private IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return _serviceResolver.GetService<IRepository<TEntity>>();
        }
    }
}