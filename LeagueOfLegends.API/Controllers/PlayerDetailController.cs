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
    /// <summary>
    /// This is the constructor (for dependency injection).
    /// </summary>
    public PlayerDetailController()
    {
    }
    
    [HttpGet("{SummonerName}")]
    public IActionResult GetPlayerDetail(string SummonerName)
    {
        return Ok("Hello World " + SummonerName);
    }
}