using System;
using System.Collections.Generic;

namespace FoodBook.Infrastructure.Common.Services
{
    public interface ISafeServiceResolver
    {
        /// <summary>
        /// Returns required service implementation
        /// </summary>
        /// <typeparam name="TService">Service for resolving</typeparam>
        /// <returns>Resolved service</returns>
        TService GetService<TService>();
        
        /// <summary>
        /// Returns required service implementation
        /// </summary>
        /// <param name="serviceType">Service for resolving</param>
        /// <returns>Resolved service</returns>
        object GetService(Type serviceType);

        /// <summary>
        /// Returns required service implementations
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        IEnumerable<object> GetServices(Type serviceType);
    }
}