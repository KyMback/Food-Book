using System;
using System.Collections.Generic;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Infrastructure.DataAccess.Interfaces.Repositories;

namespace FoodBook.Infrastructure.DataAccess.Services.Repositories.RepositoryProvider
{
    internal static class RepositoryBuilder
    {
        private static readonly IDictionary<Type, Func<RepositoryOptions, object>> Repositories =
            new Dictionary<Type, Func<RepositoryOptions, object>>();

        public static IRepository<TEntity> BuildRepository<TEntity>(RepositoryOptions options) where TEntity : BaseEntity
        {
            return Repositories[typeof(TEntity)](options) as IRepository<TEntity>;
        }
    }
}