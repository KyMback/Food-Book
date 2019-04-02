using System;
using FoodBook.Domain.Entities.Interfaces;
using FoodBook.Infrastructure.DataAccess.Interfaces.OnBeforeInsertingHandlers;

namespace FoodBook.Infrastructure.DataAccess.Services.OnBeforeInsertingHandlers
{
    internal class CreationByInsertingHandler<TEntity> : IBeforeInsertingHandler<TEntity> where TEntity : IHasCreationDate
    {
        public void Handle(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
        }
    }
}