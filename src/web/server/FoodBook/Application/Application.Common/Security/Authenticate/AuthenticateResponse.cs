using System;

namespace FoodBook.Application.Common.Security.Authenticate
{
    public class AuthenticateResponse
    {
        public string Email { get; set; }

        public Guid Id { get; set; }
    }
}