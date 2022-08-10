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
    private readonly ILogger _logger;
    
    /// <summary>
    /// This is the constructor (for dependency injection).
    /// </summary>
    public PlayerDetailController(IPlayerDetailBusiness playerDetailBusiness, ILogger<PlayerDetailController> logger)
    {
        _playerDetailBusiness = playerDetailBusiness;
        _logger = logger;
    }

    [HttpGet("{summonerName}")]
    public async Task<IActionResult> GetPlayerDetail(string summonerName)
    {
        try
        {
            await _playerDetailBusiness.TmpFunction(summonerName);
        }
        catch (ApplicationException ex)
        {
            _logger.LogError(ex.Message);
            return NotFound(ex.Message);
        }

        return Ok("Hello World " + summonerName);
    }
}