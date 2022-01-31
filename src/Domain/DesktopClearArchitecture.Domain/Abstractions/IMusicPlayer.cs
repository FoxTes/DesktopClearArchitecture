namespace DesktopClearArchitecture.Domain.Abstractions;

using System.Collections.Generic;
using Models;

/// <summary>
/// Music player.
/// </summary>
public interface IMusicPlayer
{
    /// <summary>
    /// Get all songs.
    /// </summary>
    IEnumerable<Song> GetSongs();
}