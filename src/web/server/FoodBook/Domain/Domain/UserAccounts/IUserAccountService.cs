using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodBook.Domain.Entities;
using FoodBook.Infrastructure.DataAccess.QuerySettings;
using FoodBook.Infrastructure.DataAccess.ResultHelpers;

namespace FoodBook.Domain.UserAccounts
{
    public interface IUserAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isReadOnly"></param>
        /// <returns></returns>
        Task<UserAccount> GetById(Guid id, bool isReadOnly = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="isReadOnly"></param>
        /// <returns></returns>
        Task<UserAccount> GetByEmail(string email, bool isReadOnly = true);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<UserAccount> Get(Query<UserAccount> query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<UserAccount>> GetAll(Query<UserAccount> query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<PagingResult<UserAccount>> GetAllWithPaging(Query<UserAccount> query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        Task<UserAccount> Save(UserAccount userAccount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<bool> Any(Query<UserAccount> query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAccount"></param>
        Task Delete(UserAccount userAccount);
    }
}