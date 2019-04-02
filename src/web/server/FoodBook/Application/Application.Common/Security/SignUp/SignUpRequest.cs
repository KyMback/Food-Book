using MediatR;

namespace FoodBook.Application.Common.Security.SignUp
{
    public class SignUpRequest : IRequest<Unit>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RepeatedPassword { get; set; }
    }
}