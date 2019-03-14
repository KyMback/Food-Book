using System;

namespace FoodBook.Application.Common.UserAccounts.GetCurrentUserDetails
{
    public class GetCurrentUserDetailsResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }
    }
}