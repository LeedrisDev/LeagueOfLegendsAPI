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
    /// This is the cndtructor (for dependency injection).
    /// </summary>
    public PlayerDetailController()
    {
    }
    
    [HttpGet("{PlayerName}")]
    public IActionResult GetPlayerDetail(string PlayerName)
    {
        return Ok("Hello World " + PlayerName);
    }
}