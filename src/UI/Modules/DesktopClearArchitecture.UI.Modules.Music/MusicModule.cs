namespace DesktopClearArchitecture.UI.Modules.Music
{
    using Prism.Ioc;
    using Prism.Modularity;
    using ViewModels;
    using Views;

    /// <inheritdoc />
    public class MusicModule : IModule
    {
        /// <inheritdoc />
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MusicControl, MusicControlViewModel>();
        }

        /// <inheritdoc />
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}