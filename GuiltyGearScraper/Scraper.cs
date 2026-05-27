


using System.Reflection.PortableExecutable;
using System.Text.Json;
using AngleSharp;
using AngleSharp.Dom;

public class Scraper
{
    // Targets
    FrameData FrameData = new();
    Combos Combos = new();
    IBrowsingContext context;
    string BASEURL = "https://www.dustloop.com/w/GGST";



    public Scraper()
    {
        var config = Configuration.Default.WithDefaultLoader();
        context = BrowsingContext.New(config);
    }


    public async Task<IDocument> LoadDocumentAsync(string endpoint, string character)
    {
        var url = $"{BASEURL}/{character}/{endpoint}";

        return await context.OpenAsync(url);
    }

    public async Task<ScrapeResult> GetCharacterFrameDataAsync(string character)
    {
        var document = await LoadDocumentAsync(Target.FrameData.slug,character);

        // Frame data tables given the class name cargoDynamicTable
        var framedataTables = document.QuerySelectorAll(".cargoDynamicTable");

        var frameData = FrameData.ParseFrameDataTable(framedataTables);
        // var jsonTables = new List<string?>();
        // foreach (var table in framedataTables)
        // {
        //     var head = table.QuerySelector("thead")!;
        //     var body = table.QuerySelector("tbody")!;

        //     var jsonTable = FrameData.frameDataTableToJson(body,head);
        //     jsonTables.Add(jsonTable);
        // }

        // var json = JsonSerializer.Serialize(jsonTables);


        return new ScrapeResult(character,JsonSerializer.Serialize(frameData));
    }

    public async Task<ScrapeResult> GetCharacterCombosAsync(string character)
    {

        var document = await LoadDocumentAsync(Target.Combos.slug,character);

        var wikiTables = document.QuerySelectorAll(".wikitable");

        var comboTables = document.QuerySelectorAll(".comboTable");

        var wikiTableCombos = Combos.ParseWikiTable(wikiTables);

        var comboTableCombos = Combos.ParseComboTable(comboTables);

        var allCombos = wikiTableCombos.Concat(comboTableCombos);

        return new ScrapeResult(character,JsonSerializer.Serialize(allCombos));
    }

}