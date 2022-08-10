using System.Net;

namespace LeagueOfLegends.API.Business.PlayerDetailBusiness;

using System.Text.Json;
using Models.Response;
using Utils;

/// <summary>
/// Business class for PlayerDetail
/// </summary>
public class PlayerDetailBusiness: IPlayerDetailBusiness
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;
    
    public PlayerDetailBusiness(HttpClient httpClient, ILogger<PlayerDetailBusiness> logger)
    {
        httpClient.DefaultRequestHeaders.Add("X-Riot-Token", AppConstants.ApiKey);
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<SummonerResponse> GetSummonerInformations(string summonerName)
    {
        var task = await _httpClient.GetAsync(AppConstants.RiotUrls.Summoner + summonerName);
        if (task.StatusCode == HttpStatusCode.NotFound)
            throw new ApplicationException("Player '" + summonerName + "' not found");
        
        var summoner = await JsonSerializer.DeserializeAsync<SummonerResponse>(task.Content.ReadAsStream());
        _logger.LogWarning(summoner!.ToString());

        return summoner;
    }

    public async Task TmpFunction(string summonerName)
    {
        var summonerInformations = await GetSummonerInformations(summonerName);
    }
}