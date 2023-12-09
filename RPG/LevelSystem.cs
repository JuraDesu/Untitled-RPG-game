using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class LevelSystem
    {
        private static int ToNextLevelI()
        {
            Character.ToNextLevel += ((int)Math.Ceiling((double)Character.ToNextLevel) / 10) + (int)Math.Pow(Character.Level / 3, 2);
            return Character.ToNextLevel;
        }
        public static void LevelUP()
        {
            while(Character.XP > Character.ToNextLevel) 
            {
                Character.Level++;
                Console.WriteLine(LevelUPText());
                Character.XP -= Character.ToNextLevel;
                ToNextLevelI();
            }
        }
        private static string LevelUPText()
        {
            return $"Congratulations you leveled up you are now level {Character.Level}";
        }
    }
}
