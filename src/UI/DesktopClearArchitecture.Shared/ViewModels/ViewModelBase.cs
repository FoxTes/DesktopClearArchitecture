namespace DesktopClearArchitecture.Shared.ViewModels
{
    using System.Reactive.Disposables;
    using Prism.Navigation;
    using ReactiveUI;

    /// <inheritdoc cref="ReactiveUI.ReactiveObject" />
    public class ViewModelBase : ReactiveObject, IDestructible
    {
        private readonly CompositeDisposable _disposal = new();

        /// <inheritdoc />
        public void Destroy() => _disposal.Dispose();
    }
}