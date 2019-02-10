using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class BaseApiController: ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
        
        protected static JsonResult JsonResponse(object data)
        {
            return new JsonResult(data);
        }
    }
}