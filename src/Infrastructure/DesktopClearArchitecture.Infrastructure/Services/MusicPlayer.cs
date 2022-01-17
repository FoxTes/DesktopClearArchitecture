namespace DesktopClearArchitecture.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DesktopClearArchitecture.Domain.Models;
    using Domain.Abstractions;
    using Scrutor.AspNetCore;

    /// <inheritdoc cref="Scrutor.AspNetCore.ISingletonLifetime" />
    public class MusicPlayer : IMusicPlayer, ISingletonLifetime
    {
        private static readonly string[] NameSongs =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly Random _random = new();

        /// <inheritdoc />
        public IEnumerable<Song> GetSongs()
        {
            return Enumerable
                .Range(0, 10)
                .Select(_ => new Song
                {
                    Name = NameSongs[_random.Next(NameSongs.Length)],
                    Duration = _random.Next(0, 360)
                });
        }
    }
}