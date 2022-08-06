using LeagueOfLegends.API.DataAccess.PatchNoteData;

namespace LeagueOfLegends.API.Business.PatchNoteBusiness;

using Scrapper;
using Scrapper.Model;

/// <summary>
/// The patch note business.
/// </summary>
public class PatchNotesBusiness: IPatchNoteBusiness
{
    private readonly IPatchNotesScrapper _patchNotesScrapper;
    private readonly IPatchNoteData _patchNoteData;

    /// <summary>
    /// Constructor of the class (for dependency injection).
    /// </summary>
    /// <param name="scrapper"></param>
    /// <param name="patchNoteData"></param>
    public PatchNotesBusiness(IPatchNotesScrapper scrapper, IPatchNoteData patchNoteData)
    {
        _patchNotesScrapper = scrapper;
        _patchNoteData = patchNoteData;
    }
    
    /// <summary>
    /// Get League of Legends patch notes.
    /// </summary>
    /// <returns>League of Legends patch notes</returns>
    public async Task<IEnumerable<PatchNoteModel>> GetPatchNotes()
    {
        var patchNotes = (await _patchNotesScrapper.LeagueOfLegendsPatchNotes()).ToList();
        patchNotes.Reverse();
        _patchNoteData.SavePatchNotesToDatabase((patchNotes));
        return patchNotes;
    }
}