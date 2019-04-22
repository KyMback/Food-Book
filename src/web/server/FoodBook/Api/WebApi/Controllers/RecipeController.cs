using System;
using System.Threading.Tasks;
using FoodBook.Application.Common.Recipes;
using FoodBook.Application.Common.Recipes.Create;
using FoodBook.Application.Common.Recipes.Delete;
using FoodBook.Application.Common.Recipes.Update;
using FoodBook.WebApi.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute]
    public class RecipeController : BaseApiController
    {
        public RecipeController(IMediator mediator) : base(mediator)
        {
        }
        
        /// <summary>
        /// Creates recipe
        /// </summary>
        /// <param name="request">Recipe for creating</param>
        /// <returns>Created recipe</returns>
        [HttpPut]
        [Authorize]
        public async Task<RecipeCreateResponse> Create([FromBody] RecipeCreateRequest request)
        {
            return await Mediator.Send(request);
        }
        
        /// <summary>
        /// Updates recipe
        /// </summary>
        /// <param name="request">Recipe for updating</param>
        /// <returns>Updated recipe</returns>
        [HttpPost]
        [Authorize]
        public async Task<RecipeUpdateResponse> Update([FromBody] RecipeUpdateRequest request)
        {
            return await Mediator.Send(request);
        }
        
        /// <summary>
        /// Deletes recipe
        /// </summary>
        /// <param name="id">Recipe id for deleting</param>
        /// <returns>DeletesRecipe recipe</returns>
        [HttpDelete]
        [Authorize]
        public async Task<Unit> Delete([FromQuery] Guid id)
        {
            return await Mediator.Send(new RecipeDeleteRequest
            {
                Id = id
            });
        }
    }
}