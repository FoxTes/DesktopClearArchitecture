namespace DesktopClearArchitecture.UI.Modules.Home
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using Shared.Constants;
    using ViewModels;
    using Views;

    /// <inheritdoc />
    public class HomeModule : IModule
    {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeModule"/> class.
        /// </summary>
        /// <param name="regionManager"><see cref="IRegionManager"/>.</param>
        public HomeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <inheritdoc />
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeControl, HomeControlViewModel>();
        }

        /// <inheritdoc />
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.MainContent, nameof(HomeControl));
        }
    }
}