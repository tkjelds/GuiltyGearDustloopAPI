


using System.Reflection.PortableExecutable;
using System.Text.Json;
using AngleSharp;
using AngleSharp.Dom;

public class Scraper
{
    // Targets
    FrameData FrameData = new();
    IBrowsingContext context;
    string BASEURL = "https://www.dustloop.com/w/GGST";

    public Scraper()
    {
        var config = Configuration.Default.WithDefaultLoader();
        context = BrowsingContext.New(config);
    }

    private string BuildURL(string character)
    {
        return $"{BASEURL}/{character}/Frame_Data";
    }

    private async Task<IDocument> LoadDocumentAsync(string character)
    {
        var url = BuildURL(character);
        return await context.OpenAsync(url);
    }

    public async Task<FrameDataResult> GetCharacterFrameDataAsync(string character)
    {
        var document = await LoadDocumentAsync(character);

        // Frame data tables given the class name cargoDynamicTable
        var moveTables = document.QuerySelectorAll(".cargoDynamicTable");

        var jsonTables = new List<string?>();
        foreach (var table in moveTables)
        {
            var head = table.QuerySelector("thead")!;
            var body = table.QuerySelector("tbody")!;

            var jsonTable = FrameData.frameDataTableToJson(body,head);
            jsonTables.Add(jsonTable);
        }

        var json = JsonSerializer.Serialize(jsonTables);
        return new FrameDataResult(character,json);
    }

    public async Task<FrameDataResult> GetCharacterCombos(string character)
    {
        return new FrameDataResult("","");
    }

}