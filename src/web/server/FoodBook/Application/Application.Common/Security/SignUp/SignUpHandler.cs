using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodBook.Domain.Entities;
using FoodBook.Domain.UserAccounts;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using FoodBook.Infrastructure.Services.Security;
using JetBrains.Annotations;
using MediatR;

namespace FoodBook.Application.Common.Security.SignUp
{
    [UsedImplicitly]
    internal class SignUpHandler : IRequestHandler<SignUpRequest>
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICryptographicService _cryptographicService;

        public SignUpHandler(
            IUserAccountService userAccountService,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICryptographicService cryptographicService)
        {
            _userAccountService = userAccountService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cryptographicService = cryptographicService;
        }

        public async Task<Unit> Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.RepeatedPassword)
            {
                throw new InvalidOperationException();
            }
            
            CryptographicData data =
                _cryptographicService.GenerateCryptographicData(request.Password);

            UserAccount userAccount = _mapper.Map<UserAccount>(data);
            _mapper.Map(request, userAccount);
            
            await _userAccountService.Save(userAccount);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}