using System.Text.Json;
using AngleSharp.Dom;

class Combos
{

    public string ComboTableToJson(IHtmlCollection<IElement>? tables)
    {
        if(tables == null) return "";

        var combos = new List<Dictionary<string,string>>();

        foreach (var table in tables)
        {
            var headTags = table.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).Where(th => th != "").ToArray();
            if (headTags.Count() != 0)
            {
                if(headTags.Count() == 10)
                {
                    headTags = headTags.Skip(1).ToArray();
                }

                var rowBody = table.QuerySelectorAll("td").ToArray();
                for (int i = 0; i < (rowBody.Count()/headTags.Count()); i++)
                {
                    Dictionary<string,string> combo = new();
                    for (int n = 0; n < headTags.Count(); n++)
                    {
                        // System.Console.WriteLine((headTags.Count() * i) + n);
                        combo[headTags[n]] = rowBody[(headTags.Count() * i) + n].TextContent;
                    }
                    combos.Add(combo);
                }
            }

        }

        return JsonSerializer.Serialize(combos);
    }
    
}