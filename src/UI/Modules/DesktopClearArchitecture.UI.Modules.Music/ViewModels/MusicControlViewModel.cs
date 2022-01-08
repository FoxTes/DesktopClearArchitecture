namespace DesktopClearArchitecture.UI.Modules.Music.ViewModels
{
    using System.Linq;
    using System.Reactive.Linq;
    using Application.Dtos;
    using DesktopClearArchitecture.Shared.ViewModels;
    using Domain.Abstractions;
    using Mapster;
    using Reactive.Bindings;
    using Views;

    /// <summary>
    /// View model for <see cref="MusicControl"/>.
    /// </summary>
    public class MusicControlViewModel : NavigationViewModelBase
    {
        /// <inheritdoc />
        public MusicControlViewModel(IMusicPlayer musicPlayer)
        {
            SongDtos = GetAllSongs
                .Select(_ => musicPlayer
                    .GetSongs()
                    .ToArray()
                    .Adapt<SongDto[]>())
                .ToReadOnlyReactivePropertySlim();
        }

        /// <summary>
        /// Navigation search items.
        /// </summary>
        public ReadOnlyReactivePropertySlim<SongDto[]> SongDtos { get; }

        /// <summary>
        /// Create navigation menu.
        /// </summary>
        public ReactiveCommand GetAllSongs { get; } = new();
    }
}