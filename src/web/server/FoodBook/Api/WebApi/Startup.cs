using System;
using Autofac;
using AutoMapper;
using FoodBook.Application;
using FoodBook.Application.MappingProfiles;
using FoodBook.Domain;
using FoodBook.Infrastructure.DataAccess;
using FoodBook.Infrastructure.Services;
using FoodBook.WebApi.Constants;
using FoodBook.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FoodBook.WebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services
                .AddCustomOptions(_hostingEnvironment)
                .AddMediatR()
                .AddCustomAutoMapper()
                .AddCustomRouting()
                .AddCustomSwagger()
                .AddCustomCors()
                .AddHttpContextAccessor()
                .AddCustomMvcCore(builder => 
                    builder
                        .AddApiExplorer()
                        .AddCustomMvcOptions()
                        .AddCustomJsonOptions(_hostingEnvironment)
                    )
                .ToAutofacServiceProvider(builder => 
                    builder
                        .RegisterModule<MediatrModule>()
                        .RegisterModule<ApplicationModule>()
                        .RegisterModule<DomainModule>()
                        .RegisterModule<InfrastructureServicesModule>()
                        .RegisterModule<InfrastructureDataAccessModule>()
                    );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<RecipeMappingProfile>();
            });
            
            Mapper.AssertConfigurationIsValid();
            
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
                .UseWhen(context => _hostingEnvironment.IsDevelopment(),
                    builder => builder.UseDeveloperExceptionPage())
                .UseMvc();
        }
    }
}