using RPG.Game;

namespace ConsoleRPGV3;

public class Weapon
{
    public string name;
    protected int minDamage;
    protected int maxDamage;
    protected CharacterClass reqClass;

    public override string ToString()
    {
        return $"Weapon: \t{name} ({minDamage}-{maxDamage}) ~{(minDamage + maxDamage) / 2}\n";
    }
    
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int MinDamage
    {
        get => minDamage;
        set => minDamage = value;
    }

    public int MaxDamage
    {
        get => maxDamage;
        set => maxDamage = value;
    }

    public CharacterClass ReqClass
    {
        get => reqClass;
        set => reqClass = value;
    }
}