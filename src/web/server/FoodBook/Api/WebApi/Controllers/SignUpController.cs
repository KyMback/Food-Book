using System.Threading.Tasks;
using FoodBook.Application.Common.Security.SignUp;
using FoodBook.WebApi.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute]
    public class SignUpController : BaseApiController
    {
        public SignUpController(IMediator mediator) : base(mediator)
        {
        }
        
        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result of operation</returns>
        [HttpPost]
        public async Task SignUp([FromBody] SignUpRequest request)
        {
            await Mediator.Send(request);
        }
    }
}