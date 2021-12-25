namespace DesktopClearArchitecture.UI.Modules.Settings
{
    using Prism.Ioc;
    using Prism.Modularity;
    using ViewModels;
    using Views;

    /// <inheritdoc />
    public class SettingsModule : IModule
    {
        /// <inheritdoc />
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        /// <inheritdoc />
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SettingsControl, SettingsControlViewModel>();
        }
    }
}