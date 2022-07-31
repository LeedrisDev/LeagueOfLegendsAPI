namespace LeagueOfLegends.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Scrapper;

[ApiController]
[Route("[controller]")]
public class PatchNotesController: ControllerBase
{
    private readonly IPatchNotesScrapper _patchNotesScrapper;
    
    public PatchNotesController(IPatchNotesScrapper scrapper)
    {
        _patchNotesScrapper = scrapper;
    }
    
    [HttpGet(Name = "GetPatchNotes")]
    public async Task<IActionResult> Get()
    {
        var patchNotes = await _patchNotesScrapper.ParseRiotPageNotesPage();
        return Ok(patchNotes);
    }
}