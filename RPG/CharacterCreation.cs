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
        static Character character;
        static CharacterClass characterClass;
        static Mage mage = new Mage(null, null, null, null);
        static CharacterClass.currentClass currentClass;

        public static void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("Welcome fellow adventurer to this fantasy world, first tell me your name: ");
            string? name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You have 3 classes you can choose from: \nWarrior\nArcher\nMage");
            string? className = Console.ReadLine();
            if (className.ToLower() == "warrior")
            {
                currentClass = CharacterClass.currentClass.Warrior;
                character = new Character(name, 1, 0, 100, 150, 25, 15, 10, 20, 12, 15);
                characterClass = new CharacterClass(className, "Sword4Noobs", "Strength");
                character.Name = name;
                characterClass.ClassName = className;
            }
            else if (className.ToLower() == "archer")
            {
                currentClass = CharacterClass.currentClass.Archer;
                character = new Character(name, 1, 0, 100, 100, 12, 22, 16, 15, 15, 17);
                characterClass = new CharacterClass(className, "Bow4Noobs", "Dexterity");
                character.Name = name;
                characterClass.ClassName = className;
            }
            else if (className.ToLower() == "mage")
            {
                currentClass = CharacterClass.currentClass.Mage;
                character = new Character(name, 1, 0, 100, 90, 5, 12, 30, 12, 17, 10);
                character.Name = name;
                Console.Clear();
                Console.WriteLine("Choose your element, you have 4 elements you can choose from\nFire\nWater\nEarth\nAir");
                string? element = Console.ReadLine();
                switch(element.ToLower())
                {
                    case "fire":
                        characterClass = new Mage(className, "Staff4Noobs", "Intelligence", element);
                        characterClass.ClassName = className;
                        mage.Element = element;
                        break;
                    case "water":
                        characterClass = new Mage(className, "Staff4Noobs", "Intelligence", element);
                        characterClass.ClassName = className;
                        mage.Element = element;
                        break;
                    case "earth":
                        characterClass = new Mage(className, "Staff4Noobs", "Intelligence", element);
                        characterClass.ClassName = className;
                        mage.Element = element;
                        break;
                    case "air":
                        characterClass = new Mage(className, "Staff4Noobs", "Intelligence", element);
                        characterClass.ClassName = className;
                        mage.Element = element;
                        break;
                };
                
            }
        }
        public static void CharacterPage()
        {
            Console.Clear();
            Console.WriteLine("<[==========Character==========]>\n" +
                $"\nName: {character.Name}\n" +
                $"Level: {character.Level}\n" +
                $"XP: {character.XP}\n" +
                $"Progress: [Insert progressbar here]\n" +
                $"Class: {characterClass.ClassName} {Element()}\n" +
                $"Main weapon: {characterClass.MainWeapon}\n" +
                "\n<[==========Atributes==========]>\n" +
                $"\nHP: {character.HP}\n" +
                $"Strength: {character.Strength}\n" +
                $"Dexterity: {character.Dexterity}\n" +
                $"Intelligence: {character.Intelligence}\n" +
                $"Constitution: {character.Constitution}\n" +
                $"Luck: {character.Luck}\n" +
                $"Charisma: {character.Charisma}\n" +
                "\n<[=============================]>");
        }
        private static bool IsMage()
        {
            if (currentClass == CharacterClass.currentClass.Mage)
            {
                return true;
            }
            return false;
        }
        private static string? Element()
        {
            if (IsMage())
            {
                return $"({mage.Element})";
            }
            return null;
        }
    }
}
