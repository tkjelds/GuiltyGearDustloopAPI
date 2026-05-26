public class FrameDataResult
{
    public string Character { get; set; }
    public DateTime ScrapedAt { get; set; }
    public string JsonContent { get; set; }

    public FrameDataResult(string character, string jsonContent)
    {
        this.ScrapedAt = DateTime.Now;
        this.Character = character;
        this.JsonContent = jsonContent;
    }
}