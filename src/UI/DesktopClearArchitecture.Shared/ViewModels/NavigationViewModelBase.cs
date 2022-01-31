namespace DesktopClearArchitecture.Shared.ViewModels;

using System;
using Prism.Regions;

/// <summary>
/// Basic view model for navigation.
/// </summary>
public class NavigationViewModelBase : ViewModelBase, IConfirmNavigationRequest
{
    /// <inheritdoc/>
    public virtual void ConfirmNavigationRequest(
        NavigationContext navigationContext,
        Action<bool> continuationCallback) => continuationCallback(true);

    /// <inheritdoc/>
    public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

    /// <inheritdoc/>
    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    /// <inheritdoc/>
    public virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
    }
}