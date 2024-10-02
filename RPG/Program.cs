using System;
using RPG.Backend;

namespace RPG.Game
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Clear();
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
    }
}