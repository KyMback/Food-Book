using System.Threading.Tasks;
using FoodBook.Infrastructure.Common;
using FoodBook.WebApi.Attributes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute]
    [Produces(SystemSettings.DefaultContentTypeForApiControllers)]
    [ApiController]
    public class SignOutController : ControllerBase
    {
        /// <summary>
        /// Sign outs from the system
        /// </summary>
        /// <returns>Result of operation</returns>
        [HttpGet]
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}