class Program
{


    static async Task Main(string[] args)
    {
        System.Console.WriteLine("Hello World");
        Scraper scraper = new();
        System.Console.WriteLine(scraper);
        // Character[] badCharacters = [Character.May, Character.Baiken, Character.ABA];
        // foreach (var character in Character.GetAllCharacters())
        // {
        //     var scrapedData = await scraper.GetCharacterCombosAsync(character.Slug);
        //     System.Console.WriteLine($"Current character {character.Slug} payload length: {scrapedData.JsonContent.Length}");
        //     await Task.Delay(1000);            
        // }
    }
}

