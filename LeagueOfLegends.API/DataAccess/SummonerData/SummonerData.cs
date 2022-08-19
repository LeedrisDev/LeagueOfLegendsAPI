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
    public async Task SaveSummonerToDatabase(SummonerResponse summoner)
    {
        try
        {
            var summonerEntity = _ctx.SummonerResponses.First(elt => summoner.Id == elt.Id);
            summonerEntity.Name = summoner.Name;
            summonerEntity.Puuid = summoner.Puuid;
            summonerEntity.AccountId = summoner.AccountId;
            summonerEntity.RevisionDate = summoner.RevisionDate;
            summonerEntity.SummonerLevel = summoner.SummonerLevel;
            summonerEntity.ProfileIconId = summoner.ProfileIconId;
        }
        catch (InvalidOperationException)
        {
            _ctx.SummonerResponses.Add(summoner);
        }

        await _ctx.SaveChangesAsync();
    }

    /// <summary>
    /// Get Summoner from database.
    /// </summary>
    /// <param name="summonerName">Name of the summoner wanted</param>
    /// <returns>The summoner wanted or raise an exception.</returns>
    public SummonerResponse? GetSummonerFromDatabase(string summonerName)
    {
        try
        {
            return _ctx.SummonerResponses.First(summoner => summonerName.ToLower() == summoner.Name.ToLower());
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}