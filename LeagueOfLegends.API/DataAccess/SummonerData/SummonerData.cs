using System.Data.Entity;

namespace LeagueOfLegends.API.DataAccess.SummonerData;

using Models.Response;

/// <summary>
/// Summoner Data Access Layer
/// </summary>
public class SummonerData: ISummonerData
{
    private readonly DatabaseContext _ctx;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ctx"></param>
    public SummonerData(DatabaseContext ctx)
    {
        _ctx = ctx;
    }
    
    /// <summary>
    /// Save Summoner to database.
    /// </summary>
    /// <param name="summoner"></param>
    public void SaveSummonerToDatabase(SummonerResponse summoner)
    {
        _ctx.Add(summoner);
        _ctx.SaveChanges();
    }

    /// <summary>
    /// Get Summoner from database.
    /// </summary>
    /// <param name="summonerName">Name of the summoner wanted</param>
    /// <returns>The summoner wanted or raise an exception.</returns>
    public async Task<SummonerResponse> GetSummonerFromDatabase(string summonerName)
    {
        return await _ctx.SummonerResponses
            .FirstAsync(elt => elt.Name == summonerName);
    }
}