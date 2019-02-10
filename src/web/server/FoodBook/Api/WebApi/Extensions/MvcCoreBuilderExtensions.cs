using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FoodBook.WebApi.Extensions
{
    public static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder AddCustomMvcOptions(this IMvcCoreBuilder builder)
        {
            return builder.AddMvcOptions(
                options =>
                {
                    options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();
                    
                    options.ReturnHttpNotAcceptable = true;
                });
        }
        
        public static IMvcCoreBuilder AddCustomJsonOptions(this IMvcCoreBuilder builder,
            IHostingEnvironment hostingEnvironment)
        {
            return builder
                .AddJsonFormatters(settings =>
                {
                    if (hostingEnvironment.IsDevelopment())
                    {
                        settings.Formatting = Formatting.Indented;
                    }
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
        }
    }
}