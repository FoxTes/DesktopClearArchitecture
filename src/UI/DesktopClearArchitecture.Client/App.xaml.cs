namespace DesktopClearArchitecture.Client
{
    using System.Windows;
    using Prism.Ioc;
    using Views;
    
    /// <inheritdoc />
    public partial class App
    {
        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        /// <inheritdoc />
        protected override Window CreateShell() => Container.Resolve<MainWindow>();
    }
}