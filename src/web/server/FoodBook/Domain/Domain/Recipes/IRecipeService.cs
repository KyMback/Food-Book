using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;

namespace FoodBook.Domain.Recipes
{
    public interface IRecipeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<Recipe> Get(Query<Recipe> query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<Recipe>> GetAll(Query<Recipe> query);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<PagingResult<Recipe>> GetAllWithPaging(Query<Recipe> query);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task<Recipe> InsertOrUpdate(Recipe recipe);
    }
}