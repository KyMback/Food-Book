using FoodBook.Domain.Entities.Interfaces;
using FoodBook.Infrastructure.Common.Services;
using FoodBook.Infrastructure.DataAccess.Interfaces.OnBeforeInsertingHandlers;

namespace FoodBook.Infrastructure.DataAccess.Services.OnBeforeInsertingHandlers
{
    internal class CreatedByInsertingHandler<TEntity> : IBeforeInsertingHandler<TEntity> where TEntity : IHasCreatedBy
    {
        private readonly IExecutionContextService _executionContextService;
        
        public CreatedByInsertingHandler(IExecutionContextService executionContextService)
        {
            _executionContextService = executionContextService;
        }
        
        public void Handle(TEntity entity)
        {
            entity.CreatedById = _executionContextService.GetCurrentUserAccountId().Value;
        }
    }
}