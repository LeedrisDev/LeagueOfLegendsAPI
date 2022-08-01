namespace LeagueOfLegends.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Scrapper.Model;
using Scrapper;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PatchNoteModel>))]
public class PatchNotesController: ControllerBase
{
    private readonly IPatchNotesScrapper _patchNotesScrapper;
    
    public PatchNotesController(IPatchNotesScrapper scrapper)
    {
        _patchNotesScrapper = scrapper;
    }
    
    /// <summary>Get the last 6 patch notes.</summary>
    /// <returns>Last 6 patch notes</returns>
    /// <response code="200">Returns the last 6 patch notes</response>
    [HttpGet(Name = "GetPatchNotes")]
    public async Task<IActionResult> Get()
    {
        var patchNotes = await _patchNotesScrapper.ParseRiotPageNotesPage();
        return Ok(patchNotes);
    }
}