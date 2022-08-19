namespace LeagueOfLegends.API.DataAccess.SummonerData;

using Models.Response;

/// <summary>
/// Summoner data access interface.
/// </summary>
public interface ISummonerData
{
    /// <summary>
    /// Save the summoner to the database.
    /// </summary>
    /// <param name="summoner">Summoner wanted to be saved.</param>
    public void SaveSummonerToDatabase(SummonerResponse summoner);
    
    /// <summary>
    /// Get the summoner from the database.
    /// </summary>
    /// <param name="summonerName">Name of the summoner wanted.</param>
    /// <returns>The summoner founded in database, otherwise raise an exception.</returns>
    public SummonerResponse? GetSummonerFromDatabase(string summonerName);
}