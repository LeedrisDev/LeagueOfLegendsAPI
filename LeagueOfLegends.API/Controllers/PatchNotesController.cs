using LeagueOfLegends.API.Business;
using LeagueOfLegends.API.Business.PatchNoteBusiness;

namespace LeagueOfLegends.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Scrapper.Model;
using Scrapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// This is the controller for the Patch notes.
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PatchNoteModel>))]
public class PatchNotesController: ControllerBase
{
    private readonly IPatchNoteBusiness _patchNoteBusiness;
    private readonly DatabaseContext _ctx;
    
    /// <summary>
    /// Constructor (for dependency injection)
    /// </summary>
    /// <param name="patchNoteBusiness"></param>
    /// <param name="ctx"></param>
    public PatchNotesController(IPatchNoteBusiness patchNoteBusiness, DatabaseContext ctx)
    {
        _patchNoteBusiness = patchNoteBusiness;
        _ctx = ctx;
    }

    /// <summary>Get the last 6 League Of Legends patch notes.</summary>
    /// <returns>Last 6 League Of Legends patch notes</returns>
    /// <response code="200">Returns the last 6 League Of Legends patch notes</response>
    [HttpGet("LeagueOfLegends")]
    public async Task<IActionResult> GetLeagueOfLegendsPatchNotes()
    {
        var patchNotes = await _patchNoteBusiness.GetPatchNotes();
        // await _ctx.PatchNoteModels.AddRangeAsync(patchNotes);
        // await _ctx.SaveChangesAsync();
        return Ok(patchNotes);
    }

    [HttpGet("GetAllPatchnotesFromDatabase")]
    public async Task<IActionResult> GetAll()
    {
        var patchNote = await _ctx.PatchNoteModels.ToListAsync();
        return Ok(patchNote);
    }
}