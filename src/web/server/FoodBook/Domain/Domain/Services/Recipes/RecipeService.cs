using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Entities.Recipes;
using FoodBook.Domain.Interfaces.Recipes;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;

namespace FoodBook.Domain.Services.Recipes
{
    public class RecipeService : IRecipeService
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

        public async Task<IEnumerable<Recipe>> GetAll(Query<Recipe> query)
        {
            return await _unitOfWork.GetAll(query);
        }

        public async Task<PagingResult<Recipe>> GetAllWithPaging(Query<Recipe> query)
        {
            return await _unitOfWork.GetAllWithPaging(query);
        }

        public async Task<Recipe> InsertOrUpdate(Recipe recipe)
        {
            return await _unitOfWork.InsertOrUpdate(recipe);
        }
    }
}