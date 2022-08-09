using LeagueOfLegends.API.Utils;

namespace LeagueOfLegends.API.Business.PlayerDetailBusiness;

public class PlayerDetailBusiness: IPlayerDetailBusiness
{
    private readonly HttpClient _httpClient;
    
    public PlayerDetailBusiness(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("X-Riot-Token", AppConstants.ApiKey);
        _httpClient = httpClient;
    }
}