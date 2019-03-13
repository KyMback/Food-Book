using FoodBook.Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [Produces(SystemSettings.DefaultContentTypeForApiControllers)]
    [ApiController]
    public class BaseApiController: ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}