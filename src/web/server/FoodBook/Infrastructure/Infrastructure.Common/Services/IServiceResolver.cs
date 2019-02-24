namespace FoodBook.Infrastructure.Common.Services
{
    public interface IServiceResolver
    {
        /// <summary>
        /// Returns needed service implementation
        /// </summary>
        /// <typeparam name="TService">Service for resolving</typeparam>
        /// <returns>Resolved service</returns>
        TService GetService<TService>();
    }
}