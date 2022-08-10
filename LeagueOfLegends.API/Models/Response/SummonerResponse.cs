namespace LeagueOfLegends.API.Models.Response;

using System.Text.Json.Serialization;

public class SummonerResponse
{
    /// <summary>
    /// Encrypted summoner ID. Max length 63 characters.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }
    
    /// <summary>
    /// Encrypted account ID. Max length 56 characters.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string AccountId { get; init; }
    
    /// <summary>
    /// Encrypted PUUID. Exact length of 78 characters.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string  Puuid { get; init; }
    
    /// <summary>
    /// Summoner name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    /// <summary>
    /// ID of the summoner icon associated with the summoner.
    /// </summary>
    [JsonPropertyName("profileIconId")]
    public long ProfileIconId { get; init; }
    
    /// <summary>
    /// Date summoner was last modified specified as epoch milliseconds.
    /// The following events will update this timestamp: summoner name change, summoner level change,
    /// or profile icon change.
    /// </summary>
    [JsonPropertyName("revisionDate")]
    public long RevisionDate { get; init; }
    
    /// <summary>
    /// Summoner level associated with the summoner.
    /// </summary>
    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; init; }

    public override string ToString()
    {
        return "Id: " + Id + '\n' +
               "AccountId: " + AccountId + '\n' +
               "Puuid: " + Puuid + '\n' +
               "Name: " + Name + '\n' +
               "ProfileIconId: " + ProfileIconId + '\n' +
               "RevisionDate: " + RevisionDate + '\n' +
               "SummonerLevel: " + SummonerLevel;
    }
}