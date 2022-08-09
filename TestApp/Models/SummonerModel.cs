using System.Text.Json.Serialization;

namespace TestApp.Models;

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

// {
// "id": "RCPyKTILsPEpuxz5-ts7y9nBk1N5P9ytD7eafsJ5zsJACx0",
// "accountId": "PxeHIlhj1lI0hw70_6XSFb3hEiLm_Ebld6yYuB1EGN3I5kc",
// "puuid": "fRvGDNo9KVzag9nsHdOOztjK-6Hcy5lxqZiOPVwfA_TnDgDmUQAI3YeCFdsowsSj-oAr05ob24xEUw",
// "name": "Leedris",
// "profileIconId": 3539,
// "revisionDate": 1659737698000,
// "summonerLevel": 91
// }