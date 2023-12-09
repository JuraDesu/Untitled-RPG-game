using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public static class StartGameCheck
    {
        public enum gameState
        {
            Running,
            Stopped,
        }
        public static bool IsRunning()
        {
            gameState state = gameState.Stopped;
            if (state == gameState.Running)
            {
                return true;
            }
            return false;
        }
        static string command = Console.ReadLine();
        public static void StartCommand()
        {
            gameState state = gameState.Stopped;
            if (command.ToLower() == "/start" && !IsRunning())
            {
                state = gameState.Running;
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
