namespace LeagueOfLegends.API.Utils;

/// <summary>
/// Class that contains all the constants of the API
/// </summary>
public class AppConstants
{
    public static readonly string ApiKey = Environment.GetEnvironmentVariable("API_KEY")!;

    public static class RiotUrls
    {
        public static readonly string Summoner = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";
        
        public static string MatchIds(string summonerPuuid, int start, int count)
        {
            return "https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/" + summonerPuuid + "/ids"
                   + "?start=" + start
                   + "&count=" + count;
        }
    }
}