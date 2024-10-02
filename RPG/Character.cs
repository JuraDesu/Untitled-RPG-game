using RPG.Game;
using RPG;
using ANSIConsole;
using ConsoleRPGV3;

namespace RPG.Game;
public enum CharacterClass
{
    None = 0,
    Warrior,
    Archer,
    Mage,
    Rogue,
    Ninja,
    Assasin,
    Brawler,
}

public struct Attributes
{
    public int strength;
    public int speed;
    public int intelligence;
    public int constitution;
    public int charisma;
    public int luck;
}

public abstract class Character
{
    protected Attributes attributes;
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Id
    {
        get => id;
        set => id = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public int Xp
    {
        get => xp;
        set => xp = value;
    }

    public int ToNext
    {
        get => toNext;
        set => toNext = value;
    }

    public int Hp
    {
        get => hp;
        set => hp = value;
    }

    public int MaxHp
    {
        get => maxHP;
        set => maxHP = value;
    }

    public int Dmg
    {
        get => dmg;
        set => dmg = value;
    }

    public int Strength
    {
        get => attributes.strength;
        set => attributes.strength = value;
    }

    public int Speed
    {
        get => attributes.speed;
        set => attributes.speed = value;
    }

    public int Intelligence
    {
        get => attributes.intelligence;
        set => attributes.intelligence = value;
    }

    public int Constitution
    {
        get => attributes.constitution;
        set => attributes.constitution = value;
    }

    public int Charisma
    {
        get => attributes.charisma;
        set => attributes.charisma = value;
    }

    public int Luck
    {
        get => attributes.luck;
        set => attributes.luck = value;
    }

    public CharacterClass CharClass
    {
        get => charClass;
        set => charClass = value;
    }

    public static Character Character1
    {
        get => character;
        set => character = value ?? throw new ArgumentNullException(nameof(value));
    }

    public ConsoleColor Color
    {
        get => color;
        set => color = value;
    }

    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    public string name;
    protected int id;
    public int level;
    protected int xp;
    protected int toNext;
    
    protected int hp;
    protected int maxHP;
    protected int dmg;
    
    
    
    //Equipment
    
    
    protected Weapon weapon;
    /*
    protected Armor helmet;
    protected Armor chestplate;
    protected Armor pants;
    protected Armor boots;
    */
    
    public CharacterClass charClass;

    protected static Character character;
    //Misc.
    public ConsoleColor color;

    public static Character GetInstance()
    {
        if(character != null)
            return character;
        return null;
    }
    protected Character()
    {
        color = ConsoleColor.Red;
        Id = 0;
        level = 1;
        toNext = 100;
        xp = 0;
    }
    
    //Basic functions
    public int AddXP()
    {
        Console.Write("Add amount of XP: ");
        int amount = int.Parse(Console.ReadLine());
        return xp += amount;
    }
    public async Task CalculateStats()
    {
        double amplifier = 2.5;
        while (xp >= toNext)
        {
            level++;
            xp -= toNext;
            toNext += (int)Math.Round(Math.Log(toNext) * level + amplifier);
            CalculateDMG();
            Console.WriteLine(
                $"Congratulations {name.Color(color)} you leveled up you are now level {level.ToString().Color(ConsoleColor.Cyan)}");
        }
    }
    
    public virtual void CalculateDMG()
    {
        dmg = 0;
    }
}