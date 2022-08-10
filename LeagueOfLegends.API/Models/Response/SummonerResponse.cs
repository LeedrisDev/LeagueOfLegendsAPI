namespace LeagueOfLegends.API.Models.Response;

using System.Text.Json.Serialization;

public class SummonerResponse
{
    [JsonPropertyName("id")]
    public string Id { get; init; }
    
    [JsonPropertyName("accountId")]
    public string AccountId { get; init; }
    
    [JsonPropertyName("puuid")]
    public string  Puuid { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("profileIconId")]
    public long ProfileIconId { get; init; }
    
    [JsonPropertyName("revisionDate")]
    public long RevisionDate { get; init; }
    
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