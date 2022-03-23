namespace DesktopClearArchitecture.UI.Modules.Products.ViewModels
{
    using DesktopClearArchitecture.Shared.ViewModels;
    using Domain.Abstractions.Repositories;
    using Domain.Entities;
    using Reactive.Bindings;
    using Views;

    /// <summary>
    /// View model for <see cref="ProductsControl"/>.
    /// </summary>
    public class ProductsControlViewModel : NavigationViewModelBase
    {
        /// <inheritdoc />
        public ProductsControlViewModel(IUnitOfWork unitOfWork)
        {
            GetAllProducts.WithSubscribe(async () =>
            {
                Products.Value = await unitOfWork
                    .GetRepository<Product>()
                    .GetAllAsync(true);
            });
        }

        /// <summary>
        /// Products.
        /// </summary>
        public ReactiveProperty<IList<Product>> Products { get; } = new();

        /// <summary>
        /// Get all products.
        /// </summary>
        public AsyncReactiveCommand GetAllProducts { get; } = new();
    }
}