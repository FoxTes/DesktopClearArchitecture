namespace DesktopClearArchitecture.Domain.Abstractions;

using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

/// <summary>
/// Game searcher.
/// </summary>
public interface IGameSearcher
{
    /// <summary>
    /// Get all game on steam platform.
    /// </summary>
    Task<IEnumerable<Game>> GetGames();
}