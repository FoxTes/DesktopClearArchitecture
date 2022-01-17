namespace DesktopClearArchitecture.Client
{
    using System;
    using System.IO;
    using System.Windows;
    using Application.Extensions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
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
        private ILogger _logger;

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _logger = Log.ForContext<App>();
            _logger.Information("Start application. Start args count: {Count}.", e.Args.Length);
        }

        /// <inheritdoc />
        protected override void OnExit(ExitEventArgs e)
        {
            _logger.Information("Exit application. Exit code: {Code}.", e.ApplicationExitCode);

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
        }

        /// <inheritdoc />
        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));
            serviceCollection.AddMapster();
            serviceCollection.AddHttpClient();
            serviceCollection.AddAdvancedDependencyInjection();

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