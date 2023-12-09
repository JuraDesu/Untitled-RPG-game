using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Commands
    {
        public string? command;
        public void CommandPrompt()
        { 
            CharacterCommand();
            ExitCommand();
            GiveXPCommand();
        }
        private void CharacterCommand()
        {
            if (command == "/char") CharacterCreation.CharacterPage();
        }
        private void ExitCommand()
        {
            if (command.ToLower() == "/exit") StartGameCheck.isRunning = false;
        }
        private void GiveXPCommand()
        {
            if (command.ToLower() == "/give xp")
            {
                Console.Clear();
                Console.Write("Enter an amount: ");
                float amount = float.Parse(Console.ReadLine());
                Character.XP += (int)amount;
            }
        }
    }
}
