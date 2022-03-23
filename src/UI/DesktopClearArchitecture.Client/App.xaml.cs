namespace DesktopClearArchitecture.Client;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Application.Extensions;
using DesktopClearArchitecture.UI.Dialogs.Authorization.ViewModels;
using DesktopClearArchitecture.UI.Dialogs.Authorization.Views;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Extensions;
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
    private ILogger _logger = null!;
    private IConfigurationRoot _configuration = null!;

    /// <inheritdoc />
    public App()
    {
        Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;
    }

    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _logger = Log.ForContext<App>();
        _logger.Information("Start application. Start args count: {Count}", e.Args.Length);
    }

    /// <inheritdoc />
    protected override void OnExit(ExitEventArgs e)
    {
        _logger.Information("Exit application. Exit code: {Code}", e.ApplicationExitCode);

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
        containerRegistry.RegisterDialog<AuthorizationControl, AuthorizationControlViewModel>("AuthorizationDialog");
    }

    /// <inheritdoc />
    protected override IContainerExtension CreateContainerExtension()
    {
        GetConfiguration();

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddLazyCache()
            .AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true))
            .AddMapster()
            .AddHttpClient()
            .AddPersistence(_configuration)
            .AddUnitOfWork<ApplicationDbContext>()
            .AddAdvancedDependencyInjection();

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

    private static void ShowUnhandledException(DispatcherUnhandledExceptionEventArgs e)
    {
        e.Handled = true;

        var error = e.Exception.Message +
                    (e.Exception.InnerException != null ? "\n" + e.Exception.InnerException.Message : null);
        var errorMessage =
            "An application error occurred.\nPlease check whether your data is correct and repeat the action. " +
            "If this error occurs again there seems to be a more serious malfunction in the application, " +
            $"and you better close it.\n\nError: {error}\n\n" + "Do you want to continue?\n" +
            "(If you click 'Yes' you will continue with your work, if you click 'No' the application will close).";

        if (MessageBox.Show(
                errorMessage,
                "Application Error.",
                MessageBoxButton.YesNo,
                MessageBoxImage.Error) != MessageBoxResult.No)
            return;
        if (MessageBox.Show(
                "WARNING: The application will close. Any changes will not be saved!\n\n" +
                "Do you really want to close it?",
                "Close the application!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
        {
            Current.Shutdown();
        }
    }

    private void GetConfiguration()
    {
        var currentEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{currentEnvironment}.json")
            .Build();
    }

    private void ConfigurationLogging()
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(_configuration)
            .CreateLogger();
    }

    private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        _logger.Warning(e.Exception.Demystify(), "Application Error");

        if (Debugger.IsAttached)
            e.Handled = false;
        else
            ShowUnhandledException(e);
    }
}