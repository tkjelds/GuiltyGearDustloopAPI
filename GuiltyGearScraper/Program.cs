class Program
{


    static async Task Main(string[] args)
    {

        Scraper scraper = new();
        Character[] badCharacters = [Character.May, Character.Baiken, Character.ABA];
        foreach (var character in Character.GetAllCharacters())
        {
            var scrapedData = await scraper.GetCharacterFrameDataAsync(character.Slug);
            System.Console.WriteLine($"Current character {character.Slug} payload length: {scrapedData.JsonContent.Length}");
            await Task.Delay(1000);            
        }
    }
}

