using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodBook.Infrastructure.Common.Services
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticationData"></param>
        /// <returns></returns>
        Task<ClaimsPrincipal> SignIn(AuthenticationData authenticationData);
    }
}