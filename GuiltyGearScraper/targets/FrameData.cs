using AngleSharp.Dom;
using System.Globalization;
using System.Text.Json;

class FrameData
{
    // Input CharacterName
    // Output json frame data
    public List<Dictionary<string,string>> ParseFrameDataTable(IHtmlCollection<IElement>? tables)
    {
        if(tables == null) return [];
        var moves = new List<Dictionary<string,string>>();
        foreach (var table in tables)
        {
            var head = table.QuerySelector("thead")!;
            var body = table.QuerySelector("tbody")!;
            var headTags = head.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).Where(th => th != "").ToArray();

            var rows = body.QuerySelectorAll("tr");
            foreach (var row in rows)
            {
                var move = new Dictionary<string, string>();
                var moveData = row.QuerySelectorAll("td").Select(td => td.TextContent.Trim()).Skip(1).ToArray();

                for (int i = 0; i < headTags.Length; i++)
    {
                    move[headTags[i]] = moveData[i];
                }

                moves.Add(move);
            }

        }

        return moves;
    }

}