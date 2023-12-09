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
        static Mage mage = new Mage(null, null, null, null, 0);
        static CharacterClass.currentClass currentClass;
        public static int currentLevel;
        public static int currentXP;
        public static int currentToNextLevel;
        public static int currentHP;
        public static int currentStrength;
        public static int currentDexterity;
        public static int currentIntelligence;
        public static int currentMana;
        public static int currentConstitution;
        public static int currentLuck;
        public static int currentCharisma;
        public static string currentWeapon;
        public static void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("Welcome fellow adventurer to this fantasy world, first tell me your name: ");
            string? name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You have 3 classes you can choose from: \nWarrior\nArcher\nMage");
            string? className = Console.ReadLine();
            currentXP = 0;
            currentLevel = 1;
            currentToNextLevel = 100;
            switch (className.ToLower())
            {
                case "warrior":
                    currentClass = CharacterClass.currentClass.Warrior;
                    currentHP = 150;
                    currentStrength = 25;
                    currentDexterity = 15;
                    currentIntelligence = 10;
                    currentConstitution = 20;
                    currentLuck = 12;
                    currentCharisma = 15;
                    currentWeapon = "Sword4Noobs";
                    character = new Character(name, 
                        currentLevel, 
                        currentXP, 
                        currentToNextLevel, 
                        currentHP, 
                        currentStrength, 
                        currentDexterity, 
                        currentIntelligence,
                        currentConstitution,
                        currentLuck,
                        currentCharisma);
                    characterClass = new CharacterClass(className, currentWeapon, "Strength");
                    character.Name = name;
                    characterClass.ClassName = className;
                    character.Level = currentLevel;
                    character.XP = currentXP;
                    character.HP = currentHP;
                    character.Strength = currentStrength;
                    character.Dexterity = currentDexterity;
                    character.Intelligence = currentIntelligence;
                    character.Constitution = currentConstitution;
                    character.Luck = currentLuck;
                    character.Charisma = currentCharisma;
                    characterClass.MainWeapon = currentWeapon;
                    break;
                case "archer":
                    currentClass = CharacterClass.currentClass.Archer;
                    currentHP = 100;
                    currentStrength = 12;
                    currentDexterity = 22;
                    currentIntelligence = 16;
                    currentConstitution = 15;
                    currentLuck = 15;
                    currentCharisma = 17;
                    currentWeapon = "Bow4Noobs";
                    character = new Character(name,
                        currentLevel,
                        currentXP,
                        currentToNextLevel,
                        currentHP,
                        currentStrength,
                        currentDexterity,
                        currentIntelligence,
                        currentConstitution,
                        currentLuck,
                        currentCharisma);
                    characterClass = new CharacterClass(className, currentWeapon, "Dexterity");
                    character.Name = name;
                    characterClass.ClassName = className;
                    character.Level = currentLevel;
                    character.XP = currentXP;
                    character.HP = currentHP;
                    character.Strength = currentStrength;
                    character.Dexterity = currentDexterity;
                    character.Intelligence = currentIntelligence;
                    character.Constitution = currentConstitution;
                    character.Luck = currentLuck;
                    character.Charisma = currentCharisma;
                    break;
                case "mage":
                    {
                        currentClass = CharacterClass.currentClass.Mage;
                        currentHP = 90;
                        currentMana = 100;
                        currentStrength = 5;
                        currentDexterity = 12;
                        currentIntelligence = 30;
                        currentConstitution = 12;
                        currentLuck = 17;
                        currentCharisma = 10;
                        currentWeapon = "Staff4Noobs";
                        character = new Character(name,
                            currentLevel,
                            currentXP,
                            currentToNextLevel,
                            currentHP,
                            currentStrength,
                            currentDexterity,
                            currentIntelligence,
                            currentConstitution,
                            currentLuck,
                            currentCharisma);
                        character.Name = name;
                        characterClass.ClassName = className;
                        character.Level = currentLevel;
                        character.XP = currentXP;
                        character.HP = currentHP;
                        character.Strength = currentStrength;
                        character.Dexterity = currentDexterity;
                        character.Intelligence = currentIntelligence;
                        character.Constitution = currentConstitution;
                        character.Luck = currentLuck;
                        character.Charisma = currentCharisma;
                        Console.Clear();
                        Console.WriteLine("Choose your element, you have 4 elements you can choose from\nFire\nWater\nEarth\nAir");
                        string? element = Console.ReadLine();
                        switch (element.ToLower())
                        {
                            case "fire":
                                characterClass = new Mage(className, currentWeapon, "Intelligence", element, currentMana);
                                characterClass.ClassName = className;
                                mage.Element = element;
                                mage.Mana = currentMana;
                                break;
                            case "water":
                                characterClass = new Mage(className, currentWeapon, "Intelligence", element, currentMana);
                                characterClass.ClassName = className;
                                mage.Element = element;
                                mage.Mana = currentMana;
                                break;
                            case "earth":
                                characterClass = new Mage(className, currentWeapon, "Intelligence", element, currentMana);
                                characterClass.ClassName = className;
                                mage.Element = element;
                                mage.Mana = currentMana;
                                break;
                            case "air":
                                characterClass = new Mage(className, currentWeapon, "Intelligence", element, currentMana);
                                characterClass.ClassName = className;
                                mage.Element = element;
                                mage.Mana = currentMana;
                                break;
                        };
                        break;
                    }
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
                $"{Mana()}" +
                $"Strength: {character.Strength}\n" +
                $"Dexterity: {character.Dexterity}\n" +
                $"Intelligence: {character.Intelligence}\n" +
                $"Constitution: {character.Constitution}\n" +
                $"Luck: {character.Luck}\n" +
                $"Charisma: {character.Charisma}\n" +
                "\n<[=============================]>"); ;
        }
        private static bool IsMage()
        {
            return currentClass == CharacterClass.currentClass.Mage;
        }
        private static string? Element()
        {
            if (IsMage())
            {
                return $"({mage.Element})";
            }
            return null;
        }
        private static string? Mana()
        {
            if (IsMage())
            {
                return $"Mana: {mage.Mana.ToString()}\n";
            }
            return null;
        }
    }
}
