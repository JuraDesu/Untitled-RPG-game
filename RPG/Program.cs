using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ANSIConsole;
using ConsoleRPGV3;
using RPG.Backend;
using RPG.Items;

namespace RPG.Game
{
    class Program
    {
        public static List<Weapon> warriorWeapons;
        public static async Task Main(string[] args)
        {
            Console.Clear();
            Init();
            #if DEBUG
            Console.WriteLine(FileLoader.GetDirectoryContents("saves/"));
            Console.Title = "Console RPG Game DEBUG";
            Console.WriteLine(Decorations.Titlebar("Prdel", 40, ConsoleColor.Magenta));
            Console.WriteLine();
            #endif
            #if RELEASE
            Console.Title = "Console RPG Game ver. 0.0.2";
            #endif
            await Loop.GameLoop();
        }

        private static async Task Init()
        {
            warriorWeapons = new List<Weapon>()
            {
                new Weapon("Prdel", 10, 15, CharacterClass.Warrior, Rarity.Common),
                new Weapon("Wooden sword", 5, 10, CharacterClass.Warrior, Rarity.Common),
            };
            #if DEBUG
            foreach (var weapon in warriorWeapons)
            {
                Console.WriteLine($"Successfully initialized weapon: {weapon.Name.Color(ConsoleColor.Cyan)} with rarity: {weapon.Rarity.ToString().Color(ConsoleColor.Red)}");
            }
            #endif
        }
    }
}