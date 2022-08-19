namespace LeagueOfLegends.API.Business.SummonerBusiness;

using DTO;

/// <summary>
/// Interface for Summoner Business
/// </summary>
public interface ISummonerBusiness
{
    /// <summary>
    /// Get Name, id of profile icon and level of a summoner.
    /// </summary>
    /// <param name="summonerName">Name of summoner.</param>
    /// <returns>The created SummonerDTO for the response.</returns>
    public Task<SummonerDto> GetSummonerInformation(string summonerName);
}