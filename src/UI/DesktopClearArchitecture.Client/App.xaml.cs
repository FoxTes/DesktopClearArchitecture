﻿namespace DesktopClearArchitecture.Client
{
    using System;
    using System.IO;
    using System.Windows;
    using DesktopClearArchitecture.Application.Extensions;
    using Domain.Abstractions;
    using Infrastructure.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Unity;
    using Serilog;
    using UI.Modules.Games;
    using UI.Modules.Home;
    using UI.Modules.Music;
    using UI.Modules.Products;
    using UI.Modules.Settings;
    using Unity;
    using Unity.Microsoft.DependencyInjection;
    using Views;

    /// <inheritdoc />
    public partial class App
    {
        private ILogger<App> _logger;

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _logger = Container
                .GetContainer()
                .Resolve<ILogger<App>>();
            _logger.LogInformation("Start application.");
        }

        /// <inheritdoc />
        protected override void OnExit(ExitEventArgs e)
        {
            _logger.LogInformation("Exit application.");

            base.OnExit(e);
        }

        /// <inheritdoc />
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HomeModule>();
            moduleCatalog.AddModule<ProductsModule>();
            moduleCatalog.AddModule<MusicModule>();
            moduleCatalog.AddModule<GamesModule>();
            moduleCatalog.AddModule<SettingsModule>();
        }

        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMusicPlayer, MusicPlayer>();
        }

        /// <inheritdoc />
        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));
            serviceCollection.AddMapper();

            var container = new UnityContainer();
            container.BuildServiceProvider(serviceCollection);

            return new UnityContainerExtension(container);
        }

        /// <inheritdoc />
        protected override Window CreateShell()
        {
            ConfigurationLogging();

            return Container.Resolve<MainWindow>();
        }

        private static void ConfigurationLogging()
        {
            var currentEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{currentEnvironment}.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}