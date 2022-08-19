using LeagueOfLegends.API.Models.Response;

namespace LeagueOfLegends.API.Business.DTO;

/// <summary>
/// This class is used to transfer data between the business layer and the presentation layer.
/// </summary>
public class SummonerDto
{
    /// <summary>
    /// Summoner name.
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// ID of the summoner icon associated with the summoner.
    /// </summary>
    public long ProfileIconId { get; init; }
    
    /// <summary>
    /// Level associated with the summoner.
    /// </summary>
    public int SummonerLevel { get; init; }

    /// <summary>
    /// Constructor for the SummonerDto class.
    /// </summary>
    /// <param name="summoner">The SummonerModel.</param>
    public SummonerDto(SummonerResponse summoner)
    {
        Name = summoner.Name;
        ProfileIconId = summoner.ProfileIconId;
        SummonerLevel = summoner.SummonerLevel;
    }
}