public class FrameDataResult
{
    public string Character { get;}
    public DateTime ScrapedAt { get;}
    public string JsonContent { get;}

    public FrameDataResult(string character, string jsonContent)
    {
        this.ScrapedAt = DateTime.Now;
        this.Character = character;
        this.JsonContent = jsonContent;
    }
}