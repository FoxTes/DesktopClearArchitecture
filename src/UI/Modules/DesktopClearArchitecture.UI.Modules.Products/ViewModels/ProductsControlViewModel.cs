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
                    .Repository<Product>()
                    .GetAllAsync();
            });
        }

        /// <summary>
        /// Products.
        /// </summary>
        public ReactiveProperty<List<Product>> Products { get; } = new();

        /// <summary>
        /// Get all products.
        /// </summary>
        public AsyncReactiveCommand GetAllProducts { get; } = new();
    }
}