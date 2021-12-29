namespace DesktopClearArchitecture.Application.Extensions
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension for <see cref="ServiceCollectionExtension"/>.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add auto mapper.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}