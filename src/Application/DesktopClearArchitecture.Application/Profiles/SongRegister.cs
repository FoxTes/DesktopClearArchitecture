namespace DesktopClearArchitecture.Application.Profiles
{
    using Domain.Entities;
    using Dtos;
    using Mapster;

    /// <summary>
    /// Song register.
    /// </summary>
    public class SongRegister : IRegister
    {
        /// <inheritdoc />
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Song, SongDto>()
                .Map(dest => dest.FullName, scr => $"{scr.Name} - {scr.Duration.ToString()}");
        }
    }
}