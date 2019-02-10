using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace FoodBook.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .ConfigureLogging(cfg => cfg.SetMinimumLevel(LogLevel.Warning))
                .Build()
                .Run();
        }
    }
}