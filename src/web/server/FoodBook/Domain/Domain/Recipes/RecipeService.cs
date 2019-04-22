using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;
using JetBrains.Annotations;

namespace FoodBook.Domain.Recipes
{
    [UsedImplicitly]
    internal class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Recipe> Get(Query<Recipe> query)
        {
            return await _unitOfWork.Get(query);
        }
        
        public async Task<Recipe> GetById(Guid id)
        {
            return await _unitOfWork.GetById<Recipe>(id, false);
        }

        public async Task<IEnumerable<Recipe>> GetAll(Query<Recipe> query)
        {
            return await _unitOfWork.GetAll(query);
        }

        public async Task<PagingResult<Recipe>> GetAllWithPaging(Query<Recipe> query)
        {
            return await _unitOfWork.GetAllWithPaging(query);
        }

        public async Task<Recipe> Save(Recipe recipe)
        {
            return await _unitOfWork.InsertOrUpdate(recipe);
        }
        
        public async Task Delete(Guid id)
        {
            await _unitOfWork.Delete(await _unitOfWork.GetById<Recipe>(id, false));
        }
    }
}