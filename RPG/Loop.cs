
using ANSIConsole;
using RPG.Backend;
using RPG.Cmd;

namespace RPG.Game;
public class Loop
{
    public static bool isRunning = false;
    private static string text;

    public static async Task GameLoop()
    {
    do
    {
        Console.WriteLine("Hello there, type start to get started");
        Console.Write("[" + "Game".Color(ConsoleColor.Cyan) + "]$: ");
        text = Console.ReadLine();
        Console.Clear();
    } while(!text.ToLower().Equals("start"));

        string start;
        Console.WriteLine("New Game\nLoad Game");
        Console.Write("[" + "Start Game".Color(ConsoleColor.Cyan)+ "]$: ");
        start = Console.ReadLine();
        if (start.ToLower().Equals("new game"))
        {
            CharacterFactory.GetInstance().CreateCharacter();
            isRunning = true;
        }
        else if (start.ToLower().Equals("load game"))
        {
            Console.Clear();
            Console.WriteLine("Select the character to load: \n" + FileLoader.GetDirectoryContents("saves"));
            Console.Write($"["+ "Character".Color(ConsoleColor.Cyan) + "]$: ");
            CharacterFactory.GetInstance().LoadCharacter(Console.ReadLine());
            Console.WriteLine($"Successfully loaded character {Character.GetInstance().name}");
            isRunning = true;
        }
        Commands.InitCommands();
        while (isRunning)
        {
            
            Console.Write($"[{Character.GetInstance().charClass.ToString().Color(Character.GetInstance().color)} " +
                          $"{Character.GetInstance().name.Color(Character.GetInstance().color)}" +
                          $" LV: {Character.GetInstance().level}".Color(ConsoleColor.Cyan) + "]$: ");
            await Commands.ProcessCommand(Console.ReadLine());
            
            //Running in the background
            await Character.GetInstance().CalculateStats();
        }
    }
}