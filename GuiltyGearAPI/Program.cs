using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AngleSharp;
using AngleSharp.Dom;
class Program
{


    static async Task Main(string[] args)
    {
        Helpers helper = new Helpers();

        string BASEURL = "https://www.dustloop.com/w/GGST";
        string character = "Unika";
        string tempURL = $"{BASEURL}/{character}/Frame_Data";

        var config = Configuration.Default.WithDefaultLoader();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(tempURL);



        var moveTables = document.QuerySelectorAll(".cargoDynamicTable");
        var jsonTables = new List<string?>();
        foreach (var table in moveTables)
        {
            var head = table.QuerySelector("thead")!;
            var body = table.QuerySelector("tbody")!;

            var jsonTable = helper.tableToJson(body,head);
            System.Console.WriteLine(jsonTable);
            jsonTables.Append(jsonTable);

        }



        // var normalMovesHead = moveTables.First().QuerySelector("thead")!;
        // var normalMovesBody = moveTables.First().QuerySelector("tbody")!;

        
        // var json = helper.tableToJson(normalMovesBody,normalMovesHead);
        // System.Console.WriteLine(json);
        // System.Console.WriteLine(normalMovesHead!.QuerySelectorAll("th"));
        // helper.printTable(normalMovesBody!);



        // System.Console.WriteLine(normalMovesBody.First().InnerHtml);
        // helper.printTable(normalMovesBody);

    }
}


