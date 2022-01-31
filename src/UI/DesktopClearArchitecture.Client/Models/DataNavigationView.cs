namespace DesktopClearArchitecture.Client.Models;

/// <summary>
/// Data navigation view.
/// </summary>
public readonly struct DataNavigationView
{
    /// <summary>
    /// Name content element.
    /// </summary>
    public string NameContentElement { get; init; }

    /// <summary>
    /// Name control.
    /// </summary>
    public string NameControl { get; init; }

    /// <inheritdoc />
    public override string ToString() => NameContentElement;
}