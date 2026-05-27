using System.Text.Json;
using System.Text.Json.Serialization;
using AngleSharp.Attributes;

[JsonConverter(typeof(ComboJsonConverter))]
public class Combo
{
    public string? Name { get; set; }
    public string? Notation { get; set; }
    public string? Position { get; set; }
    public string? Damage { get; set; }
    public string? WorksOn { get; set; }
    public string? Difficulty { get; set; }
    public string? Notes { get; set; }
    public string? Recipe { get; set; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement> UnmatchedFields { get; set; } = new Dictionary<string, JsonElement>();
}

public sealed class ComboJsonConverter : JsonConverter<Combo>
{
    public override Combo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;

        return new Combo
        {
            Name = GetString(root, "Title", "Full Name", "Name"),
            Notation = GetString(root, "Combo Notation", "Combo", "Notation"),
            Position = GetString(root, "Position"),
            Damage = GetString(root, "Damage"),
            WorksOn = GetString(root, "WorksOn", "Works On"),
            Difficulty = GetString(root, "Difficulty"),
            Notes = GetString(root, "Notes"),
            Recipe = GetString(root, "Recipe")
        };
    }

    public override void Write(Utf8JsonWriter writer, Combo value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        WriteStringProperty(writer, "Name", value.Name);
        WriteStringProperty(writer, "Combo/Notation", value.Notation);
        WriteStringProperty(writer, "Position", value.Position);
        WriteStringProperty(writer, "Damage", value.Damage);
        WriteStringProperty(writer, "WorksOn", value.WorksOn);
        WriteStringProperty(writer, "Difficulty", value.Difficulty);
        WriteStringProperty(writer, "Notes", value.Notes);
        WriteStringProperty(writer, "Recipe", value.Recipe);

        writer.WriteEndObject();
    }

    private static string? GetString(JsonElement obj, params string[] names)
    {
        foreach (var name in names)
        {
            if (obj.TryGetProperty(name, out var element))
            {
                if (element.ValueKind == JsonValueKind.String)
                {
                    return element.GetString();
                }

                if (element.ValueKind == JsonValueKind.Number || element.ValueKind == JsonValueKind.True || element.ValueKind == JsonValueKind.False)
                {
                    return element.ToString();
                }
            }
        }

        return null;
    }

    private static void WriteStringProperty(Utf8JsonWriter writer, string name, string? value)
    {
        writer.WritePropertyName(name);
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStringValue(value);
        }
    }
}
