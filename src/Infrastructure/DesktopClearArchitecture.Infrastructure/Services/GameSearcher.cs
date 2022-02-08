namespace DesktopClearArchitecture.Infrastructure.Services;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DesktopClearArchitecture.Domain.Models;
using Domain.Abstractions;
using Models;
using Scrutor.AspNetCore;
using LazyCache;

/// <inheritdoc cref="DesktopClearArchitecture.Domain.Abstractions.IGameSearcher" />
public class GameSearcher : IGameSearcher, ISingletonLifetime
{
    private readonly HttpClient _httpClient;
    private readonly IAppCache _cache;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSearcher"/> class.
    /// </summary>
    /// <param name="httpClient"><see cref="HttpClient"/>.</param>
    /// <param name="cache"><see cref="IAppCache"/>.</param>
    public GameSearcher(HttpClient httpClient, IAppCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Game>> GetGames() =>
        await _cache.GetOrAdd("GetGames", GetGamesList, TimeSpan.FromSeconds(10));

    private async Task<IEnumerable<Game>> GetGamesList()
    {
        var response = await _httpClient.GetAsync("https://api.steampowered.com/ISteamApps/GetAppList/v0002/?format=json");
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();
        return Utf8Json.JsonSerializer.Deserialize<Root>(stream).GameList.Games;
    }
}