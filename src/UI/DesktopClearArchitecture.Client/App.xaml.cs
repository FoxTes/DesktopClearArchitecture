namespace DesktopClearArchitecture.Client
{
    using System;
    using System.IO;
    using System.Windows;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Unity;
    using Serilog;
    using UI.Modules.Home;
    using UI.Modules.Products;
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