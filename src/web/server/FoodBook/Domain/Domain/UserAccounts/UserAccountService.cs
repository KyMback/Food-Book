using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;
using JetBrains.Annotations;

namespace FoodBook.Domain.UserAccounts
{
    [UsedImplicitly]
    internal class UserAccountService : IUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UserAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<UserAccount> GetById(Guid id, bool isReadOnly = true)
        {
            return await _unitOfWork.GetById<UserAccount>(id, isReadOnly);
        }
        
        public async Task<UserAccount> GetByEmail(string email, bool isReadOnly = true)
        {
            return await _unitOfWork.Get(new Query<UserAccount>
            {
                FilterSettings = new FilterSettings<UserAccount>().ApplySettings(userAccount =>
                    userAccount.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)),
                IsTracked = !isReadOnly
            });
        }
        
        public async Task<UserAccount> Get(Query<UserAccount> query)
        {
            return await _unitOfWork.Get(query);
        }

        public async Task<IEnumerable<UserAccount>> GetAll(Query<UserAccount> query)
        {
            return await _unitOfWork.GetAll(query);
        }
        
        public async Task<PagingResult<UserAccount>> GetAllWithPaging(Query<UserAccount> query)
        {
            return await _unitOfWork.GetAllWithPaging(query);
        }

        public Task<UserAccount> Save(UserAccount userAccount)
        {
            return _unitOfWork.InsertOrUpdate(userAccount);
        }

        public async Task<bool> Any(Query<UserAccount> query)
        {
            return await _unitOfWork.Any(query);
        }
        
        public async Task Delete(UserAccount userAccount)
        {
            await _unitOfWork.Delete(userAccount);
        }
    }
}