namespace DesktopClearArchitecture.Application.Profiles
{
    using AutoMapper;
    using Domain.Models;
    using Dtos;

    /// <summary>
    /// Song profile.
    /// </summary>
    public class SongProfile : Profile
    {
        /// <inheritdoc />
        public SongProfile()
        {
            CreateMap<Song, SongDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(scr => $"{scr.Name} - {scr.Duration.ToString()}"));
        }
    }
}