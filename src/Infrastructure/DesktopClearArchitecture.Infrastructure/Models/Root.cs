namespace DesktopClearArchitecture.Infrastructure.Models;

using System.Runtime.Serialization;

/// <summary>
/// Base class for deserialization.
/// </summary>
public class Root
{
    /// <summary>
    /// App list.
    /// </summary>
    [DataMember(Name = "applist")]
    public GameList GameList { get; set; }
}