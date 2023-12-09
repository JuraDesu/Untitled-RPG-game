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
            while(StartGameCheck.isRunning)
            {
                Commands commands = new Commands();
                try
                {
                    commands.command = Console.ReadLine();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                if (commands.command.StartsWith("/"))
                {
                    commands.CommandPrompt();
                }
                LevelSystem.LevelUP();
                Character.HealthLoop();
            }
        }
    }
}
