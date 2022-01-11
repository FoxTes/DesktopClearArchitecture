namespace DesktopClearArchitecture.UI.Modules.Games.ViewModels
{
    using System.Collections.Generic;
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
        /// <inheritdoc />
        public GamesControlViewModel(IGameSearcher gameSearcher)
        {
            GetAllGames.WithSubscribe(async () =>
            {
                var games = await gameSearcher.GetGames();
                Games.Value = games.ToList();
            });
        }

        /// <summary>
        /// Navigation search items.
        /// </summary>
        public ReactiveProperty<List<Game>> Games { get; } = new();

        /// <summary>
        /// Create navigation menu.
        /// </summary>
        public AsyncReactiveCommand GetAllGames { get; } = new();
    }
}