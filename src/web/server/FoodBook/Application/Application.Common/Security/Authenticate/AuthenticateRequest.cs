using MediatR;

namespace FoodBook.Application.Common.Security.Authenticate
{
    public class AuthenticateRequest : IRequest<AuthenticateResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}