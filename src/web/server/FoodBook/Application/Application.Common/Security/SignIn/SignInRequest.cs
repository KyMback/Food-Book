using System.Security.Claims;
using MediatR;

namespace FoodBook.Application.Common.Security.SignIn
{
    public class SignInRequest : IRequest<ClaimsPrincipal>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}