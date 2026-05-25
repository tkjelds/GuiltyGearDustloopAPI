using AngleSharp.Dom;
using System.Text.Json;

class Helpers
{
    public void printTable(IElement table)
    {   
        var rows = table.QuerySelectorAll("tr");

        foreach (var row in rows)
        {
            Console.WriteLine(row.TextContent.Trim());
        }
    }

    public void tableToJson(IElement tableBody, IElement tableHead)
    {
        var headTags = tableHead.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).Where(th => th != "");


        var rows = tableBody.QuerySelectorAll("tr");
        System.Console.WriteLine(headTags.Count());
        foreach (var row in rows)
        {
            System.Console.WriteLine(row.QuerySelectorAll("td").Select(td => td.TextContent).Skip(1).First());
        }

    }
}