using System;
using System.Collections.Concurrent;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.DataAccessConfigurations;
using FoodBook.Infrastructure.DataAccess.Interfaces.Repositories;
using FoodBook.Infrastructure.EFConfigs;

namespace FoodBook.Infrastructure.DataAccess.Services.Repositories.RepositoryProvider
{
    internal class RepositoryProvider: IRepositoryProvider
    {
        private readonly CommonDbContext _baseDbContext;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public RepositoryProvider(CommonDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.TryGetValue(typeof(TEntity), out object repository))
            {
                return repository as IRepository<TEntity>;
            }

            IRepository<TEntity> resolvedRepository =
                RepositoryBuilder.BuildRepository<TEntity>(GetRepositoryOptions());
            _repositories.TryAdd(typeof(TEntity), resolvedRepository);
            
            return _repositories[typeof(TEntity)] as IRepository<TEntity>;
        }
        
        private RepositoryOptions GetRepositoryOptions()
        {
            return new RepositoryOptions
            {
                BaseDbContext = _baseDbContext
            };
        }
    }
}