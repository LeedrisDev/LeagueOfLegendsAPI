namespace LeagueOfLegends.Scrapper.Model;

[Serializable]
public class PatchNoteModel
{
    public int Id { get; init; }
    public string Version { get; init; }
    public string ImageUrl { get; init; }
    public string PatchNoteUrl { get; init; }

    public PatchNoteModel(string version, string imageUrl, string patchNoteUrl)
    {
        this.Version = version;
        this.ImageUrl = imageUrl;
        this.PatchNoteUrl = patchNoteUrl;
    }
}