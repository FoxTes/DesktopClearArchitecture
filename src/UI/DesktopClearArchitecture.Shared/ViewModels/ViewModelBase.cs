namespace DesktopClearArchitecture.Shared.ViewModels;

using Prism.Mvvm;
using Prism.Navigation;

/// <inheritdoc cref="Prism.Mvvm.BindableBase" />
public abstract class ViewModelBase : BindableBase, IDestructible
{
    /// <inheritdoc />
    public virtual void Destroy()
    {
    }
}