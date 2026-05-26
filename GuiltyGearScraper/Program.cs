using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AngleSharp;
using AngleSharp.Dom;
using System.Text.Json;
using System.Numerics;
class Program
{


    static async Task Main(string[] args)
    {
        Scraper scraper = new();

        var fisk = await scraper.GetCharacterCombosAsync("Sol_Badguy");
        System.Console.WriteLine(fisk.JsonContent);
        // var document = await scraper.LoadDocumentAsync("Combos","Lucy");
        // var document = await scraper.LoadDocumentAsync("Combos","Jam_Kuradoberi");
        // // var document = await scraper.LoadDocumentAsync("Combos","Sol_Badguy");
        // var tables = document.QuerySelectorAll(".wikitable");
        // var combos = new List<Dictionary<string,string>>();

        // foreach (var table in tables)
        // {
        //     var headTags = table.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).Where(th => th != "").ToArray();
        //     if (headTags.Count() != 0)
        //     {
        //         if(headTags.Count() == 10)
        //         {
        //             headTags = headTags.Skip(1).ToArray();
        //         }

        //         var rowBody = table.QuerySelectorAll("td").ToArray();
        //         for (int i = 0; i < (rowBody.Count()/headTags.Count()); i++)
        //         {
        //             Dictionary<string,string> combo = new();
        //             for (int n = 0; n < headTags.Count(); n++)
        //             {
        //                 // System.Console.WriteLine((headTags.Count() * i) + n);
        //                 combo[headTags[n]] = rowBody[(headTags.Count() * i) + n].TextContent;
        //             }
        //             combos.Add(combo);
        //         }
        //     }

        // }
    }
}


