// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using TestApp.Models;
using TestApp.Utils;

namespace TestApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Riot-Token", AppConstants.RiotApiKey);

            Console.WriteLine(await client.GetStringAsync(AppConstants.RiotApiUrl));
            var stringTask = await client.GetStringAsync(AppConstants.RiotApiUrl);

            var summoner = JsonSerializer.Deserialize<SummonerModel>(stringTask);
            Console.WriteLine(summoner.Id);
            Console.WriteLine(summoner.AccountId);
            Console.WriteLine(summoner.Puuid);
            Console.WriteLine(summoner.Name);
            Console.WriteLine(summoner.ProfileIconId);
            Console.WriteLine(summoner.RevisionDate);
            Console.WriteLine(summoner.SummonerLevel);
        }
    }
}

// {
//     "id": "RCPyKTILsPEpuxz5-ts7y9nBk1N5P9ytD7eafsJ5zsJACx0",
//     "accountId": "PxeHIlhj1lI0hw70_6XSFb3hEiLm_Ebld6yYuB1EGN3I5kc",
//     "puuid": "fRvGDNo9KVzag9nsHdOOztjK-6Hcy5lxqZiOPVwfA_TnDgDmUQAI3YeCFdsowsSj-oAr05ob24xEUw",
//     "name": "Leedris",
//     "profileIconId": 3539,
//     "revisionDate": 1659737698000,
//     "summonerLevel": 91
// }