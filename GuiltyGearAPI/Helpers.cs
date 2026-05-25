using AngleSharp.Dom;
using System.Globalization;
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

    public string tableToJson(IElement tableBody, IElement tableHead)
    {
        var moves = new List<Dictionary<string,string>>();
        var headTags = tableHead.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).Where(th => th != "").ToArray();
        // If headtags is == 14 then its a normal move, if not its a specialMove/other

        var rows = tableBody.QuerySelectorAll("tr");
        // System.Console.WriteLine(headTags.Count());
        // System.Console.WriteLine(rows.Count());
        foreach (var row in rows)
        {
            var move = new Dictionary<string, string>();
            var moveData = row.QuerySelectorAll("td").Select(td => td.TextContent.Trim()).Skip(1).ToArray();


                for (int i = 0; i < headTags.Count(); i++)
    {
                    move[headTags[i]] = moveData[i];
                }

                moves.Add(move);
        }
        return JsonSerializer.Serialize(moves);
    }

}