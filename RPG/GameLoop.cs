using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class GameLoop
    {
        public void StartGameLoop()
        {
            StartGameCheck.StartCommand();
            while(StartGameCheck.IsRunning())
            {
                Commands commands = new Commands();
                commands.command = Console.ReadLine();
                if (commands.command == null)
                {
                    return;
                }
                else if (commands.command.StartsWith("/"))
                {
                    commands.CommandPrompt();
                }
            }
        }
    }
}
