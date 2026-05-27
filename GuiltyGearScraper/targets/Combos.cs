using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using AngleSharp.Dom;

class Combos
{

    public static List<Dictionary<string,string>> ParseWikiTable(IHtmlCollection<IElement>? tables)
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

                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        break;

                    case 6:
                        {
                            var tableCombos = ComboCardParser(table, headTags);
                            combos = [.. combos, .. tableCombos];
                            break;
                        }

                    default:
                        {
                            var tableCombos = DefaultTableParse(table,headTags);
                            combos =[.. combos, .. tableCombos];
                            break;
                        }
                }

            }

        }
        return combos;
    }

    private static List<Dictionary<string, string>> DefaultTableParse(IElement table, string[] headTags)
    {
        if (headTags.Length == 10)
        {
            headTags = headTags.Skip(1).ToArray();
        }
        List<Dictionary<string,string>> tableCombos = new();

        var rowBody = table.QuerySelectorAll("td").ToArray();

        for (int i = 0; i < (rowBody.Length / headTags.Length); i++)
        {
            Dictionary<string, string> combo = new();
            for (int n = 0; n < headTags.Length; n++)
            {
                combo[headTags[n]] = rowBody[(headTags.Length * i) + n].TextContent;
            }
            tableCombos.Add(combo);
        }

        return tableCombos;
    }

    private static List<Dictionary<string, string>> ComboCardParser(IElement table, string[] headTags)
    {
        var comboRow = table.QuerySelectorAll(".combo_card_tr").ToArray();
        List<Dictionary<string,string>> tableCombos = new();
        foreach (var row in comboRow)
        {
            // remove the first td of every row
            row.QuerySelector("td")?.Remove();
            Dictionary<string, string> combo = new();
            var comboCells = row.QuerySelectorAll("td");
            for (int i = 0; i < comboCells.Length; i++)
            {
                combo[headTags[i]] = comboCells[i].TextContent;
            }
            tableCombos.Add(combo);
        }
        return tableCombos;
    }

    public static List<Dictionary<string,string>> ParseComboTable(IHtmlCollection<IElement>? tables)
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