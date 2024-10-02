using ANSIConsole;
using RPG;

namespace ConsoleRPGV3;

public class Settings
{
        public static void ShowSettings()
        {
                bool debug;
                Console.Clear();
                #if RELEASE
                debug = false;
                Console.WriteLine("---------------[" + "Settings".Color(ConsoleColor.Cyan) + "]---------------");
                Console.WriteLine("Settings is WIP");
                Console.WriteLine();
                Console.WriteLine("Version: v0.0.2 release");
                Console.WriteLine("Licence: GNU GPL");
                Console.WriteLine(Decorations.Separator(40));
                #endif
                #if DEBUG
                debug = true;
                Console.WriteLine("---------------[" + "Settings".Color(ConsoleColor.Cyan) + "]---------------");
                Console.WriteLine("Debug mode: " + debug.ToString());
                Console.WriteLine(Decorations.Separator(40));
                Console.WriteLine("Version: v0.0.2 dev");
                Console.WriteLine("Licence: GNU GPL");
                Console.WriteLine(Decorations.Separator(40));
                #endif
        }
}