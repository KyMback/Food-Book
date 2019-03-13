using System;

namespace FoodBook.Infrastructure.Common.Services
{
    public interface IExecutionContextService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Guid? GetCurrentUserAccountId();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetCurrentHostName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetCurrentScheme();
    }
}