using FoodBook.Infrastructure.Common.Services;
using Microsoft.AspNetCore.Http;

namespace FoodBook.WebApi
{
    public class WebServiceResolver : IServiceResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public WebServiceResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public TService GetService<TService>()
        {
            return (TService)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(TService));
        }
    }
}