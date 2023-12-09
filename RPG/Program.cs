using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace RPG
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameLoop loop = new GameLoop();
            Console.WriteLine("Enter a command: ");
            loop.StartGameLoop();
        }
    }

}
