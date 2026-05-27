using System.Dynamic;
using System.Security.Principal;
using System.Text.Json;

class Program
{


    static async Task Main(string[] args)
    {
        Scraper scraper = new();
        List<Character> testCharacters = [Character.ElpheltValentine];
        IEnumerable<Character> allCharaters = Character.GetAllCharacters();
        foreach (var character in allCharaters)
        {
            var scrapedData = await scraper.GetCharacterCombosAsync(character.Slug);
            try
            {   
                var combos = JsonSerializer.Deserialize<List<Combo>>(scrapedData.JsonContent);  
                // System.Console.WriteLine(scrapedData.JsonContent);
                System.Console.WriteLine($"Character {character.Slug}. First Combo: {combos[0].Notation?? "Failed to find"}. Amount of combos: {combos.Count}");
                // System.Console.WriteLine($"Character {character.Slug}. First Combo: {combos[0].Notation?? "Failed to find"}");
                await Task.Delay(500);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine($"Failed to convert into combos, for character {character.Slug}");

            }         
        }
    }
}

