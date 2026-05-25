class SpecialMove : Move
{
    public string? name;

    public SpecialMove(Move move, string name)
    {
        this.name = name; 
        this.Input = move.Input;
        this.Damage = move.Damage;
        this.Guard = move.Guard;
        this.Startup = move.Startup;
        this.Active = move.Active;
        this.Recovery = move.Recovery;
        this.OnBlock = move.OnBlock;
        this.OnHit = move.OnHit;
        this.Level = move.Level;
        this.CounterType = move.CounterType;
        this.Invuln = move.Invuln;
        this.Proration = move.Proration;
        this.RISC_Gain = move.RISC_Gain;
        this.RISC_Loss = move.RISC_Loss;
    }
}