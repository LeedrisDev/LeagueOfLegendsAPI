namespace LeagueOfLegends.Scrapper.Model;

public class PatchNoteModel
{
    public string Version { get; }
    public string ImageUrl { get; }
    public string PatchNoteUrl { get; }

    public PatchNoteModel(string version, string imageUrl, string patchNoteUrl)
    {
        this.Version = version;
        this.ImageUrl = imageUrl;
        this.PatchNoteUrl = patchNoteUrl;
    }
}