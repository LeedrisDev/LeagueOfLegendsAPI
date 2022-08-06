namespace LeagueOfLegends.API.Business.PatchNoteBusiness;

using Scrapper.Model;

/// <summary>
/// Interface for patch note business.
/// </summary>
public interface IPatchNoteBusiness
{
    /// <summary>
    /// Get League of Legends patch notes.
    /// </summary>
    /// <returns>League of Legends patch notes</returns>
    public Task<IEnumerable<PatchNoteModel>> GetPatchNotes();
}