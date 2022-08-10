using System.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LeagueOfLegends.API.Utils;

/// <summary>
/// Class that contains all the constants of the API
/// </summary>
public class AppConstants
{
    public static readonly string ApiKey = Environment.GetEnvironmentVariable("API_KEY");

    public static class RiotUrls
    {
        public static readonly string Summoner = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";
    }
}