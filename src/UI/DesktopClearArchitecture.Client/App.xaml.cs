namespace DesktopClearArchitecture.Client
{
    using System;
    using System.IO;
    using System.Windows;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Prism.Ioc;
    using Prism.Unity;
    using Serilog;
    using Unity;
    using Unity.Microsoft.DependencyInjection;
    using Views;

    /// <inheritdoc />
    public partial class App
    {
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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development"}.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}