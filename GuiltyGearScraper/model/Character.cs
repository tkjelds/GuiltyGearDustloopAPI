public sealed class Character
{
    public string Slug { get; }

    private Character(string slug)
    {
        Slug = slug;
    }
    public static readonly Character Lucy = new("Lucy");
    public static readonly Character SolBadguy = new("Sol_Badguy");
    public static readonly Character KyKiske = new("Ky_Kiske");
    public static readonly Character May = new("May");
    public static readonly Character AxlLow = new("Axl_Low");
    public static readonly Character ChippZanuff = new("Chipp_Zanuff");
    public static readonly Character Potemkin = new("Potemkin");
    public static readonly Character Faust = new("Faust");
    public static readonly Character MilliaRage = new("Millia_Rage");
    public static readonly Character Zato1 = new("Zato-1");
    public static readonly Character RamlethalValentine = new("Ramlethal_Valentine");
    public static readonly Character LeoWhitefang = new("Leo_Whitefang");
    public static readonly Character Nagoriyuki = new("Nagoriyuki");
    public static readonly Character Giovanna = new("Giovanna");
    public static readonly Character AnjiMito = new("Anji_Mito");
    public static readonly Character INo = new("I-No");
    public static readonly Character GoldlewisDickinson = new("Goldlewis_Dickinson");
    public static readonly Character JackO = new("Jack-O");
    public static readonly Character HappyChaos = new("Happy_Chaos");
    public static readonly Character Baiken = new("Baiken");
    public static readonly Character SinKiske = new("Sin_Kiske");
    public static readonly Character Bridget = new("Bridget");
    public static readonly Character Asuka = new("Asuka_R");
    public static readonly Character Johnny = new("Johnny");
    public static readonly Character ElpheltValentine = new("Elphelt_Valentine");
    public static readonly Character ABA = new("A.B.A");
    public static readonly Character Slayer = new("Slayer");


    public static IEnumerable<Character> GetAllCharacters()
    {   
    return
    [
        Lucy,
        SolBadguy,
        KyKiske,
        May,
        AxlLow,
        ChippZanuff,
        Potemkin,
        Faust,
        MilliaRage,
        Zato1,
        RamlethalValentine,
        LeoWhitefang,
        Nagoriyuki,
        Giovanna,
        AnjiMito,
        INo,
        GoldlewisDickinson,
        JackO,
        HappyChaos,
        Baiken,
        SinKiske,
        Bridget,
        Asuka,
        Johnny,
        ElpheltValentine,
        ABA,
        Slayer
    ];
    }
}