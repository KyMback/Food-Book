using System.Security.Claims;
using System.Threading.Tasks;
using FoodBook.Application.Common.Security.SignIn;
using FoodBook.WebApi.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute]
    public class SignInController : BaseApiController
    {
        public SignInController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Result of operation</returns>
        [HttpPost]
        public async Task SignIn([FromBody] SignInRequest request)
        {
            ClaimsPrincipal result = await Mediator.Send(request);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result);
        }
    }
}