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
        }
        private void CharacterCommand()
        {
            if (command == "/char")
            {
                CharacterCreation.CharacterPage();
            }
        }
        private void ExitCommand() 
        {
            if (command.ToLower() == "/exit")
            {
                StartGameCheck.gameState state = StartGameCheck.gameState.Stopped;
            }
        }
    }
}
