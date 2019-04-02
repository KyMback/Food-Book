using System;
using System.Collections.Generic;
using FoodBook.Infrastructure.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FoodBook.WebApi
{
    internal class WebSafeServiceResolver : ISafeServiceResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public WebSafeServiceResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public TService GetService<TService>()
        {
            return (TService)GetService(typeof(TService));
        }

        public object GetService(Type serviceType)
        {
            return _httpContextAccessor.HttpContext.RequestServices.GetService(serviceType);
        }
        
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _httpContextAccessor.HttpContext.RequestServices.GetServices(serviceType);
        }
    }
}