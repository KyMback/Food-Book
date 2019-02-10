using System;
using Autofac;
using FoodBook.Application;
using FoodBook.Domain;
using FoodBook.Infrastructure.Services;
using FoodBook.WebApi.Constants;
using FoodBook.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace FoodBook.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services
                .AddCustomOptions(_configuration, _hostingEnvironment)
                .AddMediatR()
                .AddCustomRouting()
                .AddCustomSwagger()
                .AddCustomCors()
                .AddHttpContextAccessor()
                .AddMvcCore()
                .AddApiExplorer()
                .AddCustomMvcOptions()
                .AddCustomJsonOptions(_hostingEnvironment)
                .Services
                .ToAutofacServiceProvider(builder => 
                    builder
                        .RegisterModule<MediatrModule>()
                        .RegisterModule<ApplicationModule>()
                        .RegisterModule<DomainModule>()
                        .RegisterModule<InfrastructureServicesModule>()
                    );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app
                .UseCors(CorsPolicyNames.AllowAny)
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseSwagger()
                .UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Food book Api");
                    opt.RoutePrefix = string.Empty;
                })
                .UseMvc();
        }
    }
}