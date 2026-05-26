using System.Net.Http.Json;
using System.Text.Json.Nodes;

public class ComboResult
{   
    private string Character {get;}
    DateTime ScrapedAt {get;}
    string jsonContent {get;}

    public ComboResult(string character, string jsonContent)
    {
        this.ScrapedAt = DateTime.Now;
        this.Character = character;
        this.jsonContent = jsonContent;
    }
    
}