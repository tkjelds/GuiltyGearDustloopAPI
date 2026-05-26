using System.Text.Json;
using AngleSharp.Dom;

class Combos
{

    public List<Dictionary<string,string>> WikiTableToJson(IHtmlCollection<IElement>? tables)
    {
        if(tables == null) return [];

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
        return combos;
    }

    public List<Dictionary<string,string>> ComboTableToJson(IHtmlCollection<IElement>? tables)
    {
        if(tables == null) return [];


        var combos = new List<Dictionary<string,string>>();

        foreach (var table in tables)
        {
            var headTags = tables.First().QuerySelector(".comboTableHeader")!.QuerySelectorAll("div").ToArray();
            var rows = table.QuerySelectorAll(".comboTableRow");
            foreach (var row in rows)
            {
                Dictionary<string,string> combo = new();
                for (int i = 0; i < headTags.Take(7).Count(); i++)
                {
                    combo[headTags[i].TextContent] = row.QuerySelectorAll("div")[i].QuerySelector("span")?.TextContent;
                }
                combos.Add(combo);
                
            }
        

        }
        return combos;
    }
    
}