namespace LeagueOfLegends.API.DataAccess.PatchNoteData;

using Scrapper.Model;

/// <summary>
/// This class is used to get / save the League Of Legends patch notes from the databasw.
/// </summary>
public interface IPatchNoteData
{
    /// <summary>
    /// Get all patch notes from database.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<PatchNoteModel>> GetPatchNotesFromDatabase();
    
    /// <summary>
    /// Save patchNotes to database.
    /// </summary>
    /// <param name="patchNotes"></param>
    public void SavePatchNotesToDatabase(IEnumerable<PatchNoteModel> patchNotes);
}