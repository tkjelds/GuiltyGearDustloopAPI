public class ScrapeResult
{
    public string Character { get;}
    public DateTime ScrapedAt { get;}
    public string JsonContent { get;}

    public ScrapeResult(string character, string jsonContent)
    {
        this.ScrapedAt = DateTime.Now;
        this.Character = character;
        this.JsonContent = jsonContent;
    }
}