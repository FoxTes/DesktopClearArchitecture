namespace DesktopClearArchitecture.Infrastructure.Persistence.Extensions;

using Contexts;
using DesktopClearArchitecture.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

/// <summary>
/// Extension for <see cref="ServiceCollectionExtension"/>.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Added persistence.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <param name="configuration"><see cref="IConfiguration"/>.</param>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ApplicationDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        return services;
    }

    /// <summary>
    /// Add repositories.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IGenericRepositoryAsync<>), typeof(IGenericRepositoryAsync<>))
            .AddTransient<IProductRepository, ProductRepository>()
            .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

        return services;
    }
}