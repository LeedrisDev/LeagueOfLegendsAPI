namespace LeagueOfLegends.API.Business.SummonerBusiness;

using System.Text.Json;
using System.Net;
using DTO;
using Models.Response;
using Utils;
using DataAccess.SummonerData;

/// <summary>
/// Business class for PlayerDetail
/// </summary>
public class SummonerBusiness: ISummonerBusiness
{
    private readonly HttpClient _httpClient;
    private readonly ISummonerData _summonerData;
    private readonly ILogger _logger;

    /// <summary>
    /// Constructor for dependencies injections
    /// </summary>
    /// <param name="httpClient">An HttpClient object</param>
    /// <param name="summonerData">A SummonerData object</param>
    /// <param name="logger">A Logger object</param>
    public SummonerBusiness(HttpClient httpClient, ISummonerData summonerData, ILogger<SummonerBusiness> logger)
    {
        httpClient.DefaultRequestHeaders.Add("X-Riot-Token", AppConstants.ApiKey);
        _httpClient = httpClient;
        _summonerData = summonerData;
        _logger = logger;
    }

    /// <summary>
    /// Get Name, id of profile icon and level of a summoner.
    /// </summary>
    /// <param name="summonerName"></param>
    /// <returns>The created SummonerDTO for the response.</returns>
    public async Task<SummonerDto> GetSummonerInformation(string summonerName)
    {
        var task = await _httpClient.GetAsync(AppConstants.RiotUrls.Summoner + summonerName);
        if (task.StatusCode == HttpStatusCode.NotFound)
            throw new ApplicationException("Summoner '" + summonerName + "' not found");
        
        var summoner = await JsonSerializer.DeserializeAsync<SummonerResponse>(task.Content.ReadAsStream());
        _summonerData.SaveSummonerToDatabase(summoner!);
        _logger.LogWarning(summoner!.ToString());

        return new SummonerDto(summoner);
    }
}