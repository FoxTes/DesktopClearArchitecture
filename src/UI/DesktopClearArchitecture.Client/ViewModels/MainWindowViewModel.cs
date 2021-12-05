namespace DesktopClearArchitecture.Client.ViewModels
{
    using System.Diagnostics;
    using System.Reactive;
    using DesktopClearArchitecture.Shared.ViewModels;
    using ReactiveUI;
    using Views;

    /// <summary>
    /// View model for <see cref="MainWindow"/>.
    /// </summary>
    public class MainWindowViewModel : NavigationViewModelBase
    {
        /// <inheritdoc />
        public MainWindowViewModel()
        {
            Quit = ReactiveCommand.Create(() => Process.GetCurrentProcess().Kill());
        }

        /// <summary>
        /// Команда выхода из приложения.
        /// </summary>
        public ReactiveCommand<Unit, Unit> Quit { get; }
    }
}