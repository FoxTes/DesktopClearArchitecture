namespace DesktopClearArchitecture.UI.Modules.Games;

using Prism.Ioc;
using Prism.Modularity;
using ViewModels;
using Views;

/// <inheritdoc />
public class GamesModule : IModule
{
    /// <inheritdoc />
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<GamesControl, GamesControlViewModel>();
    }

    /// <inheritdoc />
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }
}