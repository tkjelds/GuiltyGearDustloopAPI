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

        foreach (var character in Character.GetAllCharacters())
        {
            var fisk = await scraper.GetCharacterCombosAsync(character.Slug);
            await Task.Delay(2000);
            System.Console.WriteLine($"Character: {fisk.Character} Length of payload {fisk.JsonContent.Length}");
        }
    }
}

