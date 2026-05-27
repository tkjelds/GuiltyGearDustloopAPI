using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using AngleSharp.Dom;

class Combos
{

    public List<Dictionary<string,string>> ParseWikiTable(IHtmlCollection<IElement>? tables)
    {
        if(tables == null) return [];

        var combos = new List<Dictionary<string,string>>();

        foreach (var table in tables)
        {
            var headTags = table.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).Where(th => th != "").ToArray();
            if (headTags.Length != 0)
            {

                switch (headTags.Length)
                {

                    case 6:
                    {
                        var comboRow = table.QuerySelectorAll(".combo_card_tr").ToArray();

                        foreach (var row in comboRow)
                        {
                            // remove the first td of every row
                            row.QuerySelector("td")?.Remove();
                            Dictionary<string,string> combo = new();
                            var comboCells = row.QuerySelectorAll("td");
                            for (int i = 0; i < comboCells.Length; i++)
                            {
                                combo[headTags[i]] = comboCells[i].TextContent;
                            }
                            combos.Add(combo);
                        }

                        break;
                    }
                    
                    default:
                    {
                        if(headTags.Length == 10)
                        {
                            headTags = headTags.Skip(1).ToArray();
                        }
                        foreach (var element in table.QuerySelectorAll(".mw-collapsible"))
                        { 
                            element.Remove(); 
                        } 
                        var rowBody = table.QuerySelectorAll("td").ToArray();
                        
                        for (int i = 0; i < (rowBody.Length /  headTags.Length); i++)
                        {
                            Dictionary<string,string> combo = new();
                            for (int n = 0; n < headTags.Length; n++)
                            {
                                // System.Console.WriteLine((headTags.Count() * i) + n);
                                combo[headTags[n]] = rowBody[(headTags.Length * i) + n].TextContent;
                            }
                            combos.Add(combo);
                        }
                        break;  
                    }
                }

            }

        }
        return combos;
    }

    public List<Dictionary<string,string>> ParseComboTable(IHtmlCollection<IElement>? tables)
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
                    var cellContent = row.QuerySelectorAll("div")[i].QuerySelector("span")?.TextContent;
                    combo[headTags[i].TextContent] = cellContent ?? "";
                }
                combos.Add(combo);
            }
        }
        return combos;
    }
    
}