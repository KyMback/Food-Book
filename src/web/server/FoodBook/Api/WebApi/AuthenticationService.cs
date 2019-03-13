using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FoodBook.Application.Common.Security.Authenticate;
using FoodBook.Infrastructure.Common;
using FoodBook.Infrastructure.Common.Services;
using MediatR;

namespace FoodBook.WebApi
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public AuthenticationService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public async Task<ClaimsPrincipal> SignIn(AuthenticationData authenticationData)
        {
            AuthenticateResponse result = await _mediator.Send(_mapper.Map<AuthenticateRequest>(authenticationData));
            
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, result.Email),
                new Claim(SystemSettings.NameOfUserAccountIdClaim, result.Id.ToString())
            };
            
            return GetClaimsPrincipal(claims);
        }

        private ClaimsPrincipal GetClaimsPrincipal(IEnumerable<Claim> claims)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType));
        }
    }
}