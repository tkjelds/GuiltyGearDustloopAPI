// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
using System.Text.Json;
using System.Text.Json.Serialization;

public class Move
    {
        [JsonPropertyName("Input")]
        public string? Input { get; set; }

        [JsonPropertyName("Damage")]
        public string? Damage { get; set; }

        [JsonPropertyName("Guard")]
        public string? Guard { get; set; }

        [JsonPropertyName("Startup")]
        public string? Startup { get; set; }

        [JsonPropertyName("Active")]
        public string? Active { get; set; }

        [JsonPropertyName("Recovery")]
        public string? Recovery { get; set; }

        [JsonPropertyName("On-Block")]
        public string? OnBlock { get; set; }

        [JsonPropertyName("On-Hit")]
        public string? OnHit { get; set; }

        [JsonPropertyName("Level")]
        public string? Level { get; set; }

        [JsonPropertyName("Counter Type")]
        public string? CounterType { get; set; }

        [JsonPropertyName("Invuln")]
        public string? Invuln { get; set; }

        [JsonPropertyName("Proration")]
        public string? Proration { get; set; }

        [JsonPropertyName("R․I․S․C․ Gain")]
        public string? RISCGain { get; set; }

        [JsonPropertyName("R․I․S․C․ Loss")]
        public string? RISCLoss { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JsonElement> UnmatchedFields {get; set;} 
    }

