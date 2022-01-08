using System.Linq;
using AutoMapper;
using DesktopClearArchitecture.Application.Dtos;
using DesktopClearArchitecture.Domain.Entities;
using FastExpressionCompiler;
using Mapster;

namespace DesktopClearArchitecture.Infrastructure.Bench
{
    using BenchmarkDotNet.Attributes;
    using Services;

    /// <summary>
    /// Bench for <see cref="Services"/>.
    /// </summary>
    [MemoryDiagnoser]
    public class ServicesBench
    {
        private readonly Mapper _mapper;
        private readonly MusicPlayer _musicPlayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesBench"/> class.
        /// </summary>
        public ServicesBench()
        {
            _musicPlayer = new MusicPlayer();
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Song, SongDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(scr => $"{scr.Name} - {scr.Duration.ToString()}")));
            _mapper = new Mapper(config);
            
            TypeAdapterConfig<Song, SongDto>
                .ForType()
                .Map(dest => dest.FullName, scr => $"{scr.Name} - {scr.Duration.ToString()}");
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
        }

        /// <summary>
        /// Get songs.
        /// </summary>
        [Benchmark]
        public void GetSongs()
        {
            _ = _musicPlayer
                .GetSongs()
                .ToArray();
        }

        /// <summary>
        /// Get songs.
        /// </summary>
        [Benchmark]
        public void GetAutomaper()
        {
            var songs = _musicPlayer
                .GetSongs()
                .ToArray();
            _ = _mapper.Map<SongDto[]>(songs);
        }

        /// <summary>
        /// Get songs.
        /// </summary>
        [Benchmark]
        public void GetSongsMapster()
        {
            var songs = _musicPlayer
                .GetSongs()
                .ToArray();
            var t1 = songs.Adapt<SongDto[]>();
        }
    }
}