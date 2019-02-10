using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace FoodBook.WebApi.Extensions
{
    public static class AutofacContainerBuilderExtensions
    {
        /// <summary>
        /// Converts <see cref="ContainerBuilder"/> to <see cref="AutofacServiceProvider"/>
        /// </summary>
        /// <param name="builder"><see cref="ContainerBuilder"/>.</param>
        /// <returns><see cref="AutofacServiceProvider"/></returns>
        public static AutofacServiceProvider ToServiceProvider(this ContainerBuilder builder)
        {
            return new AutofacServiceProvider(builder.Build());
        }
    }
}