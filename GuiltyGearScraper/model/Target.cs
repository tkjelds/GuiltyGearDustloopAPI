using System.Diagnostics;

public sealed class Target{
    public string slug;

    private Target(string slug)
    {
        this.slug = slug;
    }

    public readonly static Target Combos = new("Combos");
    public readonly static Target FrameData = new("Frame_Data");
}