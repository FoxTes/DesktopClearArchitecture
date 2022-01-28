namespace DesktopClearArchitecture.UI.Dialogs.Authorization.ViewModels
{
    using DesktopClearArchitecture.Shared.ViewModels;
    using Prism.Services.Dialogs;
    using Reactive.Bindings;
    using Views;

    /// <summary>
    /// View model for <see cref="AuthorizationControl"/>.
    /// </summary>
    public class AuthorizationControlViewModel : DialogViewModelBase
    {
        /// <inheritdoc />
        public AuthorizationControlViewModel()
        {
            Title = "AuthorizationControl";
            ForceCloseAuthorization.Subscribe(() => RaiseRequestClose(new DialogResult()));
        }

        /// <summary>
        /// Input parameters.
        /// </summary>
        public ReactiveProperty<string> InputParameters { get; } = new(string.Empty);

        /// <summary>
        /// Force сlose authorization.
        /// </summary>
        public ReactiveCommand ForceCloseAuthorization { get; } = new();

        /// <inheritdoc />
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            InputParameters.Value = parameters.ToString();
            base.OnDialogOpened(parameters);
        }
    }
}