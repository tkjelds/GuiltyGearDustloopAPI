using AngleSharp.Dom;
using System.Globalization;
using System.Text.Json;

class FrameData
{
    // Input CharacterName
    // Output json frame data
    public string frameDataTableToJson(IElement tableBody, IElement tableHead)
    {
        var moves = new List<Dictionary<string,string>>();
        var headTags = tableHead.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).Where(th => th != "").ToArray();

        var rows = tableBody.QuerySelectorAll("tr");
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