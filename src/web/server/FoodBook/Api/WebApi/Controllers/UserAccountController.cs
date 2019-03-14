using System.Threading.Tasks;
using FoodBook.Application.Common.UserAccounts.GetCurrentUserDetails;
using FoodBook.WebApi.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute]
    public class UserAccountController : BaseApiController
    {
        public UserAccountController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Returns details of current user
        /// </summary>
        /// <returns>Result of operation</returns>
        [Authorize]
        [HttpGet("details")]
        public async Task<GetCurrentUserDetailsResponse> GetCurrentUserDetails()
        {
            return await Mediator.Send(new GetCurrentUserDetailsRequest());
        }
    }
}