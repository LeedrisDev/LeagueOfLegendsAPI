namespace LeagueOfLegends.API.Business.PlayerDetailBusiness;

using Models.Response;

public interface IPlayerDetailBusiness
{
    public Task<SummonerResponse> GetSummonerInformations(string summonerName);
    public Task TmpFunction(string summonerName);
}