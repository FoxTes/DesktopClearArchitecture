namespace DesktopClearArchitecture.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Abstractions;
    using Domain.Entities;

    /// <inheritdoc />
    public class MusicPlayer : IMusicPlayer
    {
        private static readonly string[] NameSongs =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <inheritdoc />
        public IEnumerable<Song> GetSongs()
        {
            var random = new Random();
            return Enumerable
                .Range(0, 5)
                .Select(_ => new Song
                {
                    Name = NameSongs[random.Next(NameSongs.Length)],
                    Duration = random.Next(0, 360)
                });
        }
    }
}