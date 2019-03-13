using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodBook.Infrastructure.Common.Services;
using JetBrains.Annotations;
using MediatR;

namespace FoodBook.Application.Common.Security.SignIn
{
    [UsedImplicitly]
    internal class SignInHandler : IRequestHandler<SignInRequest, ClaimsPrincipal>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public SignInHandler(
            IAuthenticationService authenticationService,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<ClaimsPrincipal> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            return await _authenticationService.SignIn(_mapper.Map<AuthenticationData>(request));
        }
    }
}