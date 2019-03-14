using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodBook.Domain.Entities;
using FoodBook.Domain.UserAccounts;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.Services.Exceptions;
using FoodBook.Infrastructure.Services.Security;
using JetBrains.Annotations;
using MediatR;

namespace FoodBook.Application.Common.Security.Authenticate
{
    [UsedImplicitly]
    internal class AuthenticateHandler : IRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;
        private readonly ICryptographicService _cryptographicService;
        
        public AuthenticateHandler(
            IUserAccountService userAccountService,
            IMapper mapper,
            ICryptographicService cryptographicService)
        {
            _userAccountService = userAccountService;
            _mapper = mapper;
            _cryptographicService = cryptographicService;
        }
        
        public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            UserAccount userAccount = await _userAccountService.Get(new Query<UserAccount>
            {
                FilterSettings = new FilterSettings<UserAccount>().ApplySettings(account =>
                    account.Email == request.Login || account.Login == request.Login)
            });
            
            if (userAccount == null)
            {
                throw new NotAuthorizedException();
            }
            
            if (!_cryptographicService.VerifySourceValueWithCryptographicData(
                _mapper.Map<CryptographicData>(userAccount), request.Password))
            {
                throw new NotAuthorizedException();
            }

            return _mapper.Map<AuthenticateResponse>(userAccount);
        }
    }
}