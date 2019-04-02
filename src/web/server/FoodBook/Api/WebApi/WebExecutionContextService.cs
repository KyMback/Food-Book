using System;
using FoodBook.Infrastructure.Common;
using FoodBook.Infrastructure.Common.Services;
using Microsoft.AspNetCore.Http;

namespace FoodBook.WebApi
{
    internal class WebExecutionContextService : IExecutionContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public WebExecutionContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public Guid? GetCurrentUserAccountId()
        {
            string result = _httpContextAccessor.HttpContext.User
                .FindFirst(SystemSettings.NameOfUserAccountIdClaim)?.Value;

            if (string.IsNullOrWhiteSpace(result))
            {
                return null;
            }
            
            return new Guid(result);
        }

        public string GetCurrentHostName()
        {
            return _httpContextAccessor.HttpContext.Request.Host.Value;
        }
        
        public string GetCurrentScheme()
        {
            return _httpContextAccessor.HttpContext.Request.Scheme;
        }
    }
}