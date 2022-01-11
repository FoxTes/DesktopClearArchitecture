namespace DesktopClearArchitecture.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using DesktopClearArchitecture.Domain.Models;
    using Domain.Abstractions;
    using Models;

    /// <inheritdoc />
    public class GameSearcher : IGameSearcher
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameSearcher"/> class.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/>.</param>
        public GameSearcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Game>> GetGames()
        {
            var response = await _httpClient.GetAsync("https://api.steampowered.com/ISteamApps/GetAppList/v0002/?format=json");
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            return Utf8Json.JsonSerializer.Deserialize<Root>(stream).GameList.Games;
        }
    }
}