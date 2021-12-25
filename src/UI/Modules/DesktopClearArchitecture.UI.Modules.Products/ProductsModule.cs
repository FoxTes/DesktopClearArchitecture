namespace DesktopClearArchitecture.UI.Modules.Products
{
    using Prism.Ioc;
    using Prism.Modularity;
    using ViewModels;
    using Views;

    /// <inheritdoc />
    public class ProductsModule : IModule
    {
        /// <inheritdoc />
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        /// <inheritdoc />
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ProductsControl, ProductsControlViewModel>();
        }
    }
}