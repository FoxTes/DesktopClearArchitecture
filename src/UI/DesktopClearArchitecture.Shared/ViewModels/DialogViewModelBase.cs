namespace DesktopClearArchitecture.Shared.ViewModels
{
    using System;
    using Prism.Services.Dialogs;

    /// <summary>
    /// Basic presentation model for dialogs.
    /// </summary>
    public class DialogViewModelBase : NavigationViewModelBase, IDialogAware
    {
        private string _title = string.Empty;

        /// <inheritdoc/>
        public event Action<IDialogResult> RequestClose;

        /// <inheritdoc/>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <inheritdoc/>
        public virtual bool CanCloseDialog() => true;

        /// <inheritdoc/>
        public virtual void OnDialogClosed()
        {
        }

        /// <inheritdoc/>
        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
