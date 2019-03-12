using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FoodBook.Application.Common.MappingProfiles;
using FoodBook.Application.GraphQL.MappingProfiles;
using FoodBook.Infrastructure.Common.ApplicationSettings;
using FoodBook.WebApi.Constants;
using GraphQL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FoodBook.WebApi.Extensions
{
    public static class CustomServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services ti DI container for mvc core
        /// </summary>
        /// <param name="services">DI services collection</param>
        /// <param name="builder">Builder for custom configuring mvc core</param>
        public static IServiceCollection AddCustomMvcCore(
            this IServiceCollection services,
            Action<IMvcCoreBuilder> builder)
        {
            builder(services.AddMvcCore());
            return services;
        }
        
        /// <summary>
        /// Adds services
        /// </summary>
        /// <param name="services">DI services collection</param>
        /// <param name="builderConfig"></param>
        /// <returns></returns>
        public static AutofacServiceProvider ToAutofacServiceProvider(
            this IServiceCollection services,
            Action<ContainerBuilder> builderConfig)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builderConfig.Invoke(builder);
            return builder.ToServiceProvider();
        }
        
        public static IServiceCollection AddCustomOptions(
            this IServiceCollection services,
            IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true)
                .AddJsonFile("appsettings.Personal.json", true)
                .AddEnvironmentVariables();
            
            RegisterConfigurations(builder.Build(), services);
            
            return services;
        }

        private static void RegisterConfigurations(IConfigurationRoot configs, IServiceCollection services)
        {
            services.AddSingleton(configs.GetSection(nameof(DataBaseConfigurations)).Get<DataBaseConfigurations>());
        }
        
        public static IServiceCollection AddCustomRouting(this IServiceCollection services)
        {
            return services.AddRouting(options => { options.LowercaseUrls = true; });
        }
        
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Food book Api", Version = "v1" });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
        
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            return services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        CorsPolicyNames.AllowAny,
                        x => x
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                });
        }
        
        public static IServiceCollection AddCustomAutoMapper(
            this IServiceCollection services,
            IHostingEnvironment hostingEnvironment,
            Action<IMapperConfigurationExpression> builder)
        {
            services.AddAutoMapper(builder);
            if (hostingEnvironment.IsDevelopment())
            {
                Mapper.Initialize(builder);
                Mapper.AssertConfigurationIsValid();
            }

            return services;
        }
    }
}