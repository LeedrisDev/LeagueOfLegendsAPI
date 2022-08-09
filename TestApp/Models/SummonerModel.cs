namespace TestApp.Models;

using System.Text.Json.Serialization;

public class SummonerModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; }
    
    [JsonPropertyName("puuid")]
    public string Puuid { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("profileIconId")]
    public int ProfileIconId { get; set; }
    
    [JsonPropertyName("revisionDate")]
    public long RevisionDate { get; set; }
    
    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; set; }
    
    public SummonerModel()
    {
        Id = "";
        AccountId = "";
        Puuid = "";
        Name = "";
        ProfileIconId = 0;
        RevisionDate = 0;
        SummonerLevel = 0;
    }
}