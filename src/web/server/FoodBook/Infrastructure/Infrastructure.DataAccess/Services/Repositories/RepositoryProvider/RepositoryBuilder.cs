using System;
using System.Collections.Generic;
using FoodBook.Domain.Entities.Entities;
using FoodBook.Domain.Entities.Entities.Recipes;
using FoodBook.Infrastructure.DataAccess.Interfaces.Repositories;

namespace FoodBook.Infrastructure.DataAccess.Services.Repositories.RepositoryProvider
{
    internal static class RepositoryBuilder
    {
        private static readonly IDictionary<Type, Func<RepositoryOptions, object>> Repositories =
            new Dictionary<Type, Func<RepositoryOptions, object>>
            {
                { typeof(Recipe), options => new Repository<Recipe>(options.BaseDbContext) },
                { typeof(RecipeStep), options => new Repository<RecipeStep>(options.BaseDbContext) },
                { typeof(UserAccount), options => new Repository<UserAccount>(options.BaseDbContext) },
            };

        public static IRepository<TEntity> BuildRepository<TEntity>(RepositoryOptions options) where TEntity : BaseEntity
        {
            return Repositories[typeof(TEntity)](options) as IRepository<TEntity>;
        }
    }
}