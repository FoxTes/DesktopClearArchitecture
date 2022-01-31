namespace DesktopClearArchitecture.UI.Modules.Games.ViewModels;

using System;
using System.Linq;
using DesktopClearArchitecture.Shared.ViewModels;
using Domain.Abstractions;
using Domain.Models;
using Reactive.Bindings;
using Views;

/// <summary>
/// View model for <see cref="GamesControl"/>.
/// </summary>
public class GamesControlViewModel : NavigationViewModelBase
{
    private readonly Random _random = new();

    /// <inheritdoc />
    public GamesControlViewModel(IGameSearcher gameSearcher)
    {
        GetAllGames.WithSubscribe(async () =>
        {
            Games.Value = (await gameSearcher.GetGames())
                .Skip(_random.Next(100, 5000))
                .Take(20)
                .ToArray();
        });
    }

    /// <summary>
    /// Navigation search items.
    /// </summary>
    public ReactiveProperty<Game[]> Games { get; } = new();

    /// <summary>
    /// Create navigation menu.
    /// </summary>
    public AsyncReactiveCommand GetAllGames { get; } = new();
}