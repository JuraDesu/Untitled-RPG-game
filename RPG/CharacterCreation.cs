using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG
{
    public static class CharacterCreation
    {
        static CharacterClass.currentClass currentClass;
        static ProgressTracking progressbar = new ProgressTracking();
        public static void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("Welcome fellow adventurer to this fantasy world, first tell me your name: ");
            string? name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You have 3 classes you can choose from: \nWarrior\nArcher\nMage");
            string? className = Console.ReadLine();
            Character.Name = name;
            Character.Level = 1;
            Character.XP = 0;
            Character.ToNextLevel = 100;
            CharacterClass.ClassName = className;
            switch (className.ToLower())
            {
                case "warrior":
                    currentClass = CharacterClass.currentClass.Warrior;
                    Character.HP = 150;
                    Character.Strength= 25;
                    Character.Dexterity = 15;
                    Character.Intelligence = 10;
                    Character.Constitution = 20;
                    Character.Luck = 12;
                    Character.Charisma = 15;
                    CharacterClass.MainWeapon = "Sword4Noobs";
                    CharacterClass.DmgAtribute = "Strength";
                    break;
                case "archer":
                    currentClass = CharacterClass.currentClass.Archer;
                    Character.HP = 100;
                    Character.Strength = 12;
                    Character.Dexterity = 22;
                    Character.Intelligence = 16;
                    Character.Constitution = 15;
                    Character.Luck = 15;
                    Character.Charisma = 17;
                    CharacterClass.MainWeapon = "Bow4Noobs";
                    CharacterClass.DmgAtribute = "Dexterity";
                    break;
                case "mage":
                    {
                        currentClass = CharacterClass.currentClass.Mage;
                        Character.HP = 90;
                        Mage.Mana = 100;
                        Character.Strength = 5;
                        Character.Dexterity = 12;
                        Character.Intelligence = 30;
                        Character.Constitution = 12;
                        Character.Luck = 17;
                        Character.Charisma = 10;
                        CharacterClass.MainWeapon = "Staff4Noobs";
                        CharacterClass.DmgAtribute = "Intelligence";
                        Console.Clear();
                        Console.WriteLine("Choose your element, you have 4 elements you can choose from\nFire\nWater\nEarth\nAir");
                        string? element = Console.ReadLine();
                        switch (element.ToLower())
                        {
                            case "fire":
                                Mage.Element = element;
                                break;
                            case "water":
                                Mage.Element = element;
                                break;
                            case "earth":
                                Mage.Element = element;
                                break;
                            case "air":
                                Mage.Element = element;
                                break;
                        };
                        break;
                    }
                
            }
        }
        public static void CharacterPage()
        {
            int progressBarWidth = 20;
            Console.Clear();
            Console.WriteLine("<[==========Character==========]>\n" +
                $"\nName: {Character.Name}\n" +
                $"Level: {Character.Level}\n" +
                $"Current XP: {Character.XP} {progressbar.ProgressBar(progressBarWidth)} To Next: {Character.ToNextLevel}\n" +
                $"Class: {CharacterClass.ClassName} {Element()}\n" +
                $"Weapon: {CharacterClass.MainWeapon}\n" +
                "\n<[==========Atributes==========]>\n" +
                $"\nHP: {Character.HP}\n" +
                $"{Mana()}" +
                $"Strength: {Character.Strength}\n" +
                $"Dexterity: {Character.Dexterity}\n" +
                $"Intelligence: {Character.Intelligence}\n" +
                $"Constitution: {Character.Constitution}\n" +
                $"Luck: {Character.Luck}\n" +
                $"Charisma: {Character.Charisma}\n" +
                "\n<[=============================]>"); ;
        }

        private static string? Element()
        {
            if (currentClass == CharacterClass.currentClass.Mage)
            {
                return $"({Mage.Element})";
            }
            return null;
        }
        private static string? Mana()
        {
            if (currentClass == CharacterClass.currentClass.Mage)
            {
                return $"Mana: {Mage.Mana.ToString()}\n";
            }
            return null;
        }
    }
}
