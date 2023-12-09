using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public static class StartGameCheck
    {
        public static bool isRunning = false;
        public static void StartCommand()
        {
            string command = Console.ReadLine();
            if (command.ToLower() == "/start" && !isRunning)
            {
                isRunning = true;
                Console.Clear();
                Console.WriteLine("<[==========Start Game==========]>\n" +
                    "New Game\n" +
                    "Load Game (WIP)\n" +
                    "<[==============================]>");

                string? newGame = Console.ReadLine();

                if (newGame.ToLower() == "new game")
                {
                    CharacterCreation.CreateCharacter();
                }
            }
        }
    }
}
