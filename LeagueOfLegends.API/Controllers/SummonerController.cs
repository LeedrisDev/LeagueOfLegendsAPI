using LeagueOfLegends.API.Business.SummonerMatchBusiness;

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
    private readonly ILogger _logger;
    private readonly ISummonerBusiness _summonerBusiness;
    private readonly ISummonerMatchBusiness _summonerMatchBusiness;

    /// <summary>
    /// This is the constructor (for dependency injection).
    /// </summary>
    public SummonerController(ISummonerBusiness summonerBusiness, ILogger<SummonerController> logger, ISummonerMatchBusiness summonerMatchBusiness)
    {
        _logger = logger;
        _summonerBusiness = summonerBusiness;
        _summonerMatchBusiness = summonerMatchBusiness;
    }
    

    /// <summary>Get basic information on a summoner.</summary>
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

    /// <summary>Get matchs history of a summoner.</summary>
    /// <returns>Historic of matchs that summoner played recently</returns>
    /// <param name="summonerName">Name of the summoner wanted.</param>
    /// <response code="200">Returns matchs history.</response>
    /// <response code="404">Summoner not found.</response>
    [HttpGet("{summonerName}/matchs")]
    public async Task<IActionResult> GetSummonerMatchHistory(string summonerName)
    {
        await _summonerMatchBusiness.Tmp(summonerName, 0, 10);
        return Ok("Not implemented yet");
    }

}