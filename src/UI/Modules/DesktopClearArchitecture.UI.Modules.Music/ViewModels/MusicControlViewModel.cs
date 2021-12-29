namespace DesktopClearArchitecture.UI.Modules.Music.ViewModels
{
    using System.Linq;
    using System.Reactive.Linq;
    using Application.Dtos;
    using AutoMapper;
    using DesktopClearArchitecture.Shared.ViewModels;
    using Domain.Abstractions;
    using Reactive.Bindings;
    using Reactive.Bindings.Extensions;
    using Views;

    /// <summary>
    /// View model for <see cref="MusicControl"/>.
    /// </summary>
    public class MusicControlViewModel : NavigationViewModelBase
    {
        /// <inheritdoc />
        public MusicControlViewModel(IMapper mapper, IMusicPlayer musicPlayer)
        {
            SongDtos = GetAllSongs
                .Select(_ => mapper.Map<SongDto[]>(musicPlayer.GetSongs().ToArray()))
                .ObserveOnUIDispatcher()
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