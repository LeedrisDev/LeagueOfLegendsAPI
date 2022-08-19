namespace LeagueOfLegends.API.Business.SummonerMatchBusiness;

using System.Text.Json;
using DataAccess.SummonerData;
using Utils;

public class SummonerMatchBusiness: ISummonerMatchBusiness
{
    private readonly ILogger _logger;
    private readonly HttpClient _httpClient;
    private readonly ISummonerData _summonerData;
    
    public SummonerMatchBusiness(ILogger<SummonerMatchBusiness> logger, HttpClient httpClient, ISummonerData summonerData)
    {
        _logger = logger;
        httpClient.DefaultRequestHeaders.Add("X-Riot-Token", AppConstants.ApiKey);
        _httpClient = httpClient;
        _summonerData = summonerData;
    }

    private async Task<List<string>> GetMatchIds(string summonerName, int start, int count)
    {
        var summoner = _summonerData.GetSummonerFromDatabase(summonerName);
        if (summoner == null) 
            throw new InvalidOperationException("Not implemented yet, need to call Riot Api if summoner is not in database");

        var task = await _httpClient.GetAsync(AppConstants.RiotUrls.MatchIds(summoner.Puuid, start, count));
        if (!task.IsSuccessStatusCode)
            throw new ApplicationException("Error getting match ids");

        var matchIds = await JsonSerializer.DeserializeAsync<List<string>>(await task.Content.ReadAsStreamAsync());
        return matchIds ?? throw new InvalidOperationException("MatchIds is null");
    }

    public async Task Tmp(string summonerName, int start, int count)
    {
        var matchIds = await GetMatchIds(summonerName, start, count);
        matchIds.ForEach(match => _logger.LogWarning(match));
    }
}