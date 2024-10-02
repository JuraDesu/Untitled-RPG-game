using RPG.Game;
using RPG;
using RPG.Items;
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
    public float strength;
    public float speed;
    public float intelligence;
    public float constitution;
    public float charisma;
    public float luck;
}

public abstract class Character
{
    protected Attributes attributes;
    

    public string name;
    protected int id;
    public int level;
    protected float xp;
    protected float toNext;
    
    protected float hp;
    protected float maxHP;
    protected float dmg;
    
    protected float hpAmplifier;
    
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
    public float AddXP()
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
            CalculateHP();
            CalculateDMG();
            Console.WriteLine(
                $"Congratulations {name.Color(color)} you leveled up you are now level {level.ToString().Color(ConsoleColor.Cyan)}");
        }
    }
    
    public virtual void CalculateDMG()
    {
        dmg = weapon.MinDamage * ((int)Math.Round(Math.Log2(level)) + weapon.MaxDamage * (int)Math.Round(Math.Log2(level))) / 2;  
    }

    public void CalculateHP()
    {
        maxHP += (attributes.constitution + level) * hpAmplifier;
        hp = maxHP;
    }
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

    public float Xp
    {
        get => xp;
        set => xp = value;
    }

    public float ToNext
    {
        get => toNext;
        set => toNext = value;
    }

    public float Hp
    {
        get => hp;
        set => hp = value;
    }

    public float MaxHp
    {
        get => maxHP;
        set => maxHP = value;
    }

    public float Dmg
    {
        get => dmg;
        set => dmg = value;
    }

    public float Strength
    {
        get => attributes.strength;
        set => attributes.strength = value;
    }

    public float Speed
    {
        get => attributes.speed;
        set => attributes.speed = value;
    }

    public float Intelligence
    {
        get => attributes.intelligence;
        set => attributes.intelligence = value;
    }

    public float Constitution
    {
        get => attributes.constitution;
        set => attributes.constitution = value;
    }

    public float Charisma
    {
        get => attributes.charisma;
        set => attributes.charisma = value;
    }

    public float Luck
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
}