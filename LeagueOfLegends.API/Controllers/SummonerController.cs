namespace LeagueOfLegends.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Business.SummonerBusiness;
using Business.DTO;

/// <summary>
/// This is the controller for player details.
/// </summary>
[ApiController]
[Route("summoner")]
[Produces("application/json")]
public class SummonerController: ControllerBase
{
    private readonly ISummonerBusiness _summonerBusiness;
    private readonly ILogger _logger;
    
    /// <summary>
    /// This is the constructor (for dependency injection).
    /// </summary>
    public SummonerController(ISummonerBusiness summonerBusiness, ILogger logger)
    {
        _summonerBusiness = summonerBusiness;
        _logger = logger;
    }
    

    /// <summary>Get basic information on a summoner</summary>
    /// <returns>Last 6 League Of Legends patch notes</returns>
    /// <param name="summonerName">Name of the summoner wanted.</param>
    /// <response code="200">Returns basic information on a summoner.</response>
    /// <response code="404">Summoner not found.</response>
    [HttpGet("{summonerName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SummonerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundObject))]
    public async Task<IActionResult> GetSummonerInformation(string summonerName)
    {
        try
        {
            var summonerInformation = await _summonerBusiness.GetSummonerInformation(summonerName);
            return Ok(summonerInformation);
        }
        catch (ApplicationException ex)
        {
            var notFound = new NotFoundObject(ex.Message);
            return NotFound(notFound);
        }
    }
}