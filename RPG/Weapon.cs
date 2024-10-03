using System.Drawing;
using RPG.Game;
using ANSIConsole;
namespace RPG.Items;

public class Weapon
{
    public string name;
    private int minDamage;
    private int maxDamage;
    private CharacterClass reqClass;
    private Rarity rarity;
    public override string ToString()
    {
        return $"Weapon: \t{name} ({minDamage}-{maxDamage}) ~{(minDamage + maxDamage) / 2}\n";
    }

    public Weapon(string name, int minDamage, int maxDamage, CharacterClass reqClass, Rarity rarity)
    {
        this.name = name;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.reqClass = reqClass;
        this.rarity = rarity;
    }

    protected void SetRarityColor()
    {
        switch (rarity)
        {
            case Rarity.Common:
                name.Color(ConsoleColor.Gray);
                break;
            case Rarity.Uncommon:
                name.Color(ConsoleColor.Green);
                break;
            case Rarity.Rare:
                name.Color(ConsoleColor.Blue);
                break;
            case Rarity.Epic:
                name.Color(ConsoleColor.Magenta);
                break;
            case Rarity.Legendary:
                name.Color(ConsoleColor.Yellow);
                break;
            case Rarity.Mythic:
                name.Color(ConsoleColor.Red);
                break;
            case Rarity.Mystical:
                name.Color(ConsoleColor.DarkMagenta);
                break;
            case Rarity.Demonic:
                name.Color(ConsoleColor.DarkRed);
                break;
            case Rarity.Angelic:
                name.Color(ConsoleColor.Cyan);
                break;
            case Rarity.Ethereal:
                name.Color(ConsoleColor.DarkCyan);
                break;
            case Rarity.Godlike:
                name.Color(ConsoleColor.DarkYellow);
                break;
            default:
                Console.WriteLine($"Unknown rarity: {rarity}");
                break;
        }
        #if DEBUG
        Console.WriteLine($"Created weapon with name: {name}");
        #endif
    }

    public Rarity Rarity
    {
        get => rarity;
        set => rarity = value;
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