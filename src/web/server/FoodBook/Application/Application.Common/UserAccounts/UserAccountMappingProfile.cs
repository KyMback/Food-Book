using AutoMapper;
using FoodBook.Application.Common.UserAccounts.GetCurrentUserDetails;
using FoodBook.Domain.Entities;
using JetBrains.Annotations;

namespace FoodBook.Application.Common.UserAccounts
{
    [UsedImplicitly]
    internal class UserAccountMappingProfile : Profile
    {
        public UserAccountMappingProfile()
        {
            CreateMap<UserAccount, GetCurrentUserDetailsResponse>();
        }
    }
}