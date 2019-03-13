using System;
using System.Net;
using System.Threading.Tasks;
using FoodBook.Infrastructure.Services.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vas.Web.Api.Middleware;

namespace FoodBook.WebApi.Middleware
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly IHostingEnvironment _environment;
        private readonly ILogger _logger;
 
        public ExceptionHandlerMiddleware(
            IHostingEnvironment environment,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _environment = environment;
            _logger = logger;
        }
 
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (NotAuthorizedException)
            {
                httpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
 
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
 
            return context.Response.WriteAsync(GetExceptionMessage(context, exception));
        }

        private string GetExceptionMessage(HttpContext context, Exception exception)
        {
            var viewModel = new ExceptionViewModel
            {
                StatusCode = context.Response.StatusCode,
                Message = _environment.IsDevelopment() ? exception.ToString() : null
            };
            _logger.Log(LogLevel.Error, exception.ToString());
            return JsonConvert.SerializeObject(viewModel);
        }
    }
    
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}