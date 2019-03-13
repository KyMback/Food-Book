using System.Threading.Tasks;
using FoodBook.Application.Common.Recipes;
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
    }
}