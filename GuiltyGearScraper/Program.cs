using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AngleSharp;
using AngleSharp.Dom;
using System.Text.Json;
class Program
{


    static async Task Main(string[] args)
    {
        Scraper scraper = new();
        var frameDataLucy = await scraper.GetCharacterFrameDataAsync("Lucy");
        System.Console.WriteLine(frameDataLucy);
    }
}


