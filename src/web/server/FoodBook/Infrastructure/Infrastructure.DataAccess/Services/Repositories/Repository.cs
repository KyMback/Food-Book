using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.Common.Extensions;
using FoodBook.Infrastructure.DataAccess.DataAccessConfigurations;
using FoodBook.Infrastructure.DataAccess.Enums;
using FoodBook.Infrastructure.DataAccess.Interfaces.Repositories;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;
using Microsoft.EntityFrameworkCore;

namespace FoodBook.Infrastructure.DataAccess.Services.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: BaseEntity
    {
        private readonly CommonDbContext _dbContext;

        protected DbSet<TEntity> Storage => _dbContext.Set<TEntity>();
        
        public Repository(CommonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<TEntity> Get(Query<TEntity> query)
        {
            return await ExecuteQuery(query).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Query<TEntity> query)
        {
            return await ExecuteQuery(query).ToArrayAsync();
        }
        
        public async Task<PagingResult<TEntity>> GetAllWithPaging(Query<TEntity> query)
        {
            return await ExecuteWithPaging(query);
        }

        public async Task<int> Count(Query<TEntity> query)
        {
            return await ExecuteQuery(query).CountAsync();
        }

        public async Task<bool> Any(Query<TEntity> query)
        {
            return await ApplyFilterSettings(Storage.AsQueryable(), query.FilterSettings).AnyAsync();
        }

        public async Task<TEntity> InsertOrUpdate(TEntity entity)
        {
            if (entity.IsNew)
            {
                SetDataToNewEntity(entity);
                return (await Storage.AddAsync(entity)).Entity;
            }
            
            Storage.Attach(entity);
            MarkAsModified(entity);
            
            return entity;
        }

        public Task Delete(TEntity entity)
        {
            Storage.Remove(entity);

            return Task.CompletedTask;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<TEntity> ExecuteQuery(Query<TEntity> query)
        {
            IQueryable<TEntity> queryable = Storage.AsQueryable();

            queryable = ApplyFilterSettings(queryable, query.FilterSettings);
            
            queryable = ApplySortSettings(queryable, query.SortSettings);

            if (!query.IsTracked)
            {
                queryable = queryable.AsNoTracking();
            }
            
            return queryable;
        }

        private async Task<PagingResult<TEntity>> ExecuteWithPaging(Query<TEntity> query)
        {
            query.IsTracked = false;

            IQueryable<TEntity> queryable = ExecuteQuery(query);

            return new PagingResult<TEntity>
            {
                Entities = await ApplyPageSettings(queryable, query.PageSettings).ToArrayAsync().ConfigureAwait(false),
                Count = await queryable.LongCountAsync().ConfigureAwait(false)
            };
        }

        private IQueryable<TEntity> ApplyFilterSettings(IQueryable<TEntity> queryable, FilterSettings<TEntity> settings)
        {
            foreach (Expression<Func<TEntity, bool>> predicateExpression in settings.PredicateExpressions)
            {
                queryable = queryable.Where(predicateExpression);
            }

            return queryable;
        }
        
        private IQueryable<TEntity> ApplySortSettings(IQueryable<TEntity> queryable, SortSettings<TEntity> settings)
        {
            if (settings.OrderExpressions.IsNullOrEmpty())
            {
                return queryable.OrderBy(entity => entity.Id);
            }
            
            foreach (SortSetting<TEntity> settingsOrderExpression in settings.OrderExpressions)
            {
                queryable = settingsOrderExpression.OrderType == OrderType.Ascending
                    ? queryable.OrderBy(settingsOrderExpression.Expression)
                    : queryable.OrderByDescending(settingsOrderExpression.Expression);
            }

            return queryable;
        }
        
        private IQueryable<TEntity> ApplyPageSettings(IQueryable<TEntity> queryable, PageSettings settings)
        {
            if (settings == null)
            {
                return queryable;
            }

            return queryable.Skip(settings.From).Take(settings.Count);
        }
        
        private void SetDataToNewEntity(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
        }
        
        private void MarkAsModified(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}