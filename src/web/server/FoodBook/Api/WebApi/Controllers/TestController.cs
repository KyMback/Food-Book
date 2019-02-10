using System.Threading.Tasks;
using FoodBook.Application;
using FoodBook.WebApi.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute("test")]
    public class TestController : BaseApiController
    {
        public TestController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Test method
        /// </summary>
        /// <returns>Result</returns>
        [HttpGet("testGet")]
        public async Task<JsonResult> GetTestResult()
        {
            return JsonResponse(await Mediator.Send(new TestRequest()));
        }
    }
}