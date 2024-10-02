using ConsoleRPGV3;
using RPG.Game;
namespace RPG.Cmd;

public class Commands
{
    public static Dictionary<int, string> commands = new Dictionary<int, string>();
    private static char prefix = '/';
    public static async Task ProcessCommand(string command)
    {
        if (command.StartsWith(prefix))
        {
            ExitCommand(command);
            HelpCommand(command);
            StatsCommand(command);
            SettingsCommand(command);
            Save(command);
            #if DEBUG
            XPCommand(command);
            #endif
        }
    }
    public static void InitCommands()
    {
        commands.Add(0, "exit");
        commands.Add(1, "help");
        commands.Add(2, "stats");
        commands.Add(3, "settings");
        commands.Add(4, "save");
        #if DEBUG
        commands.Add(103, "xp");
        #endif
    }
    private static void ExitCommand(string command)
    {
        if(commands.ContainsValue("exit") && command.Equals("/exit"))
            Loop.isRunning = false;
    }

    private static void HelpCommand(string command)
    {
        if (commands.ContainsValue("help") && command.Equals("/help"))
        {
            Console.WriteLine("Available commands:");
            foreach (var cmd in commands)
            {
                Console.WriteLine(prefix + "{0}", cmd.Value);
            }
        }
    }
    private static void StatsCommand(string command)
    {
        if (commands.ContainsValue("stats") && command.Equals("/stats"))
        {
            Console.Clear();
            Console.WriteLine(Character.GetInstance().ToString());
        }
    }

    private static void XPCommand(string command)
    {
        if (commands.ContainsValue("xp") && command.Equals($"/xp"))
        {
            Character.GetInstance().AddXP();
        }
    }

    private static void SettingsCommand(string command)
    {
        if (commands.ContainsValue("settings") && command.Equals("/settings"))
        {
            Settings.ShowSettings();
        }
    }

    private static void Save(string command)
    {
        if(commands.ContainsValue("save") && command.Equals("/save"))
        {
            CharacterFactory.GetInstance().SaveCharacter();
        }
    }
}