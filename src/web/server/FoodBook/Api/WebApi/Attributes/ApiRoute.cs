using FoodBook.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Attributes
{
    public class ApiRoute: RouteAttribute
    {
        public ApiRoute(string template) : base($"api/{template}")
        {
        }
        
        public ApiRoute() : base(SystemSettings.DefaultRouteForApiControllers)
        {
        }
    }
}