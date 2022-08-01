namespace LeagueOfLegends.Scrapper;

using HtmlAgilityPack;
using System.Net.Http;
using Model;

public class PatchNoteScrapper: IPatchNotesScrapper
{
    private static async Task<string> GetUrl(string fullUrl)
    {
        var client = new HttpClient();
        var response = await client.GetStringAsync(fullUrl);
        return response;
    }

    private static IEnumerable<PatchNoteModel> ParseHtml(string html)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        var patchNoteNames = htmlDoc.DocumentNode.Descendants("h2")
            .Where(node => node.GetAttributeValue("class", "").Equals("style__Title-sc-1h41bzo-8 fEywOQ"))
            .Select(node => node.InnerText)
            .ToList();

        var imageUrls = htmlDoc.DocumentNode.Descendants("img")
            .Where(node =>
                node.GetAttributeValue("class", "")
                    .Equals("style__NoScriptImg-g183su-0 style__Img-g183su-1 cipsic dBitJH"))
            .Select(node => node.GetAttributeValue("src", ""))
            .ToList();

        var patchNotesUrl = htmlDoc.DocumentNode.Descendants("a")
            .Where(node =>
                node.GetAttributeValue("class", "")
                    .Equals(
                        "style__Wrapper-sc-1h41bzo-0 style__ResponsiveWrapper-sc-1h41bzo-13 jyxTUP cayvOp isVisible"))
            .Select(node => node.GetAttributeValue("href", ""))
            .ToList();

        if (patchNoteNames.Count() != imageUrls.Count() || patchNoteNames.Count() != patchNotesUrl.Count())
        {
            throw new ApplicationException(
                "PatchNotesNames, imageUrls and / or patchNotesUrl doesn't have the same length");
        }

        var patchNotes = new List<PatchNoteModel>();
        for (var i = 0; i < patchNoteNames.Count; i++)
        {
            var patchNote = new PatchNoteModel(patchNoteNames[i], imageUrls[i], patchNotesUrl[i]);
            patchNotes.Add(patchNote);
        }

        return patchNotes;
    }

    public async Task<IEnumerable<PatchNoteModel>> ParseRiotPageNotesPage()
    { 
        const string url = "https://www.leagueoflegends.com/fr-fr/news/tags/patch-notes/";
        var response = await GetUrl(url);
        var patchNotes = ParseHtml(response);
        
        return patchNotes;
    }
}