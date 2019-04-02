using MediatR;

namespace FoodBook.Application.Common.Security.Authenticate
{
    public class AuthenticateRequest : IRequest<AuthenticateResponse>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}