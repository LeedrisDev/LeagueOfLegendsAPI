namespace LeagueOfLegends.Scrapper;

using Model;

public interface IPatchNotesScrapper
{
    public Task<IEnumerable<PatchNoteModel>> ParseLeagueOfLegendsPatchNotes();
}