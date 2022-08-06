namespace LeagueOfLegends.API.DataAccess.PatchNoteData;

using Scrapper.Model;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc />
public class PatchNoteData: IPatchNoteData
{
    private readonly DatabaseContext _ctx;
    
    /// <summary>
    /// Constructor for dependency injection.
    /// </summary>
    /// <param name="ctx"></param>
    public PatchNoteData(DatabaseContext ctx)
    {
        _ctx = ctx;
    }
    
    /// <summary>
    /// Get all patch notes from database.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<PatchNoteModel>> GetPatchNotesFromDatabase()
    {
        return await _ctx.PatchNoteModels.ToListAsync();
    }
    
    /// <summary>
    /// Save patchNotes to database.
    /// </summary>
    /// <param name="patchNotes"></param>
    public void SavePatchNotesToDatabase(IEnumerable<PatchNoteModel> patchNotes)
    {
        _ctx.PatchNoteModels.AddRange(patchNotes);
        _ctx.SaveChanges();
    }
}