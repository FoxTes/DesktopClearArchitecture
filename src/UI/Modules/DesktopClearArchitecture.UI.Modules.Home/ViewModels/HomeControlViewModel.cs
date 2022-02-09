namespace DesktopClearArchitecture.UI.Modules.Home.ViewModels;

using DesktopClearArchitecture.Shared.ViewModels;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Views;

/// <summary>
/// View model for <see cref="HomeControl"/>.
/// </summary>
public class HomeControlViewModel : NavigationViewModelBase
{
    /// <inheritdoc />
    public HomeControlViewModel(IDialogService dialogService)
    {
        var parameters = new DialogParameters
        {
            { "FirstParam", 1 },
            { "SecondParam", 2 }
        };

        ShowWindowAuthorization.Subscribe(() =>
            dialogService.Show("AuthorizationDialog", parameters, _ => { }));
        ShowDialogAuthorization.Subscribe(() =>
            dialogService.ShowDialog("AuthorizationDialog", parameters, _ => { }));
        CreateСustomException.Subscribe(() =>
                throw new Exception("Test custom exception."));
    }

    /// <summary>
    /// Show window authorization.
    /// </summary>
    public ReactiveCommand ShowWindowAuthorization { get; } = new();

    /// <summary>
    /// Show dialog authorization.
    /// </summary>
    public ReactiveCommand ShowDialogAuthorization { get; } = new();

    /// <summary>
    /// Create custom exception.
    /// </summary>
    public ReactiveCommand CreateСustomException { get; } = new();
}