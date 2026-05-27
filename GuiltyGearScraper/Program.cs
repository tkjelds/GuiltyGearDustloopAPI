using System.Dynamic;
using System.Security.Principal;
using System.Text.Json;

class Program
{


    static async Task Main(string[] args)
    {
        Scraper scraper = new();
        List<Character> testCharacters = [Character.SinKiske];
        IEnumerable<Character> allCharacter = Character.GetAllCharacters();
        // var LucyFrameData = await scraper.GetCharacterFrameDataAsync(Character.Lucy.Slug);
        // var fisk = JsonSerializer.Deserialize<Move[]>(LucyFrameData.JsonContent);
        // var scrapedLucy = await scraper.GetCharacterCombosAsync(Character.Lucy.Slug);
        // var combosJson = scrapedLucy.JsonContent;
        // var attempt = JsonSerializer.Deserialize<List<IDictionary<string,string>>>(combosJson);
        // System.Console.WriteLine(attempt.Count());
        foreach (var character in allCharacter)
        {
            var scrapedData = await scraper.GetCharacterCombosAsync(character.Slug);
            try
            {   
                var combos = JsonSerializer.Deserialize<List<Combo>>(scrapedData.JsonContent);  
                System.Console.WriteLine($"Character {character.Slug}. First Combo: {combos[0].Notation?? "Failed to find"}");
                await Task.Delay(500);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine($"Failed to convert into combos, for character {character.Slug}");

            }         
        }
    }
}

