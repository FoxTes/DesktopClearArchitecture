namespace DesktopClearArchitecture.Shared.ViewModels
{
    using Prism.Regions;

    /// <inheritdoc cref="ViewModelBase" />
    public abstract class NavigationViewModelBase : ViewModelBase, INavigationAware
    {
        /// <inheritdoc />
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <inheritdoc />
        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

        /// <inheritdoc />
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}