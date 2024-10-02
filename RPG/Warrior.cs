using RPG;
using RPG.Game;

namespace ConsoleRPGV3;

public class Warrior : Character
{
    private int damage;
    public int AP;
    
    public Warrior(string name) : base()
    {
        base.name = name;
        id++;
        hp = 200;
        maxHP = hp;
        
        attributes.strength = 20;
        attributes.speed = 10;
        attributes.intelligence = 7;
        attributes.constitution = 15;
        attributes.charisma = 30;
        attributes.luck = 14;

        weapon = new TestWeapon();
        
        charClass = CharacterClass.Warrior;
        character = this;
    }
    
    public override void CalculateDMG()
    {
        damage = /*weapon.DMG*/ +(int)Math.Round(Math.Log2(base.attributes.strength));
    }

    public override string ToString()
    {
        return $"{Decorations.Titlebar($"{charClass}", 60, ConsoleColor.Cyan)}\n\n" +
               $"Name: \t\t{name}\n" +
               $"HP: \t\t{hp} / {maxHP} \t{Decorations.ProgressBar(hp, maxHP, ConsoleColor.Red)}\n" +
               $"Level: \t\t{level} \t\t{Decorations.ProgressBar(xp, toNext, ConsoleColor.Cyan)}\n" +
               $"Xp: \t\t{xp}\n" +
               $"To Next: \t{toNext}\n" +
               $"Class: \t\t{charClass.ToString()}\n\n" +
               $"{Decorations.Titlebar("Equipment", 60, ConsoleColor.Cyan)}\n" +
               $"{weapon.ToString()}" +
               $"{Decorations.Titlebar("Attributes", 60, ConsoleColor.Cyan)}\n\n" +
               $"Strength: \t{attributes.strength}\n" +
               $"Speed: \t\t{attributes.speed}\n" +
               $"Intelligence: \t{attributes.intelligence}\n" +
               $"Constitution: \t{attributes.constitution}\n" +
               $"Charisma: \t{attributes.charisma}\n" +
               $"Luck: \t\t{attributes.luck}\n" +

               $"{Decorations.Separator(60)}";
    }
}