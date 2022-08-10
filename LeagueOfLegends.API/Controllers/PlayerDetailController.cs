using LeagueOfLegends.API.Business.PlayerDetailBusiness;
using Microsoft.AspNetCore.Mvc;

namespace LeagueOfLegends.API.Controllers;

/// <summary>
/// This is the controller for player details.
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PlayerDetailController: ControllerBase
{
    private readonly IPlayerDetailBusiness _playerDetailBusiness;
    
    /// <summary>
    /// This is the constructor (for dependency injection).
    /// </summary>
    public PlayerDetailController(IPlayerDetailBusiness playerDetailBusiness)
    {
        _playerDetailBusiness = playerDetailBusiness;
    }

    [HttpGet("{SummonerName}")]
    public IActionResult GetPlayerDetail(string SummonerName)
    {
        return Ok("Hello World " + SummonerName);
    }
}