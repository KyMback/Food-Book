using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodBook.Domain.Entities;
using FoodBook.Domain.UserAccounts;
using FoodBook.Infrastructure.Common.Services;
using JetBrains.Annotations;
using MediatR;

namespace FoodBook.Application.Common.UserAccounts.GetCurrentUserDetails
{
    [UsedImplicitly]
    internal class GetCurrentUserDetailsHandler : IRequestHandler<GetCurrentUserDetailsRequest, GetCurrentUserDetailsResponse>
    {
        private readonly IExecutionContextService _executionContextService;
        private readonly IUserAccountService  _userAccountService;
        private readonly IMapper _mapper;

        public GetCurrentUserDetailsHandler(
            IExecutionContextService executionContextService,
            IMapper mapper,
            IUserAccountService userAccountService)
        {
            _executionContextService = executionContextService;
            _mapper = mapper;
            _userAccountService = userAccountService;
        }

        public async Task<GetCurrentUserDetailsResponse> Handle(GetCurrentUserDetailsRequest request, CancellationToken cancellationToken)
        {
            Guid? userId = _executionContextService.GetCurrentUserAccountId();
            UserAccount user = await _userAccountService.GetById(userId.Value);

            return _mapper.Map<GetCurrentUserDetailsResponse>(user);
        }
    }
}