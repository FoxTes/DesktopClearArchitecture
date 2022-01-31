namespace DesktopClearArchitecture.Application.Extensions;

using System.Reflection;
using FastExpressionCompiler;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension for <see cref="ServiceCollectionExtension"/>.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Added automapper.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    /// <summary>
    /// Added mapster.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        return services;
    }
}