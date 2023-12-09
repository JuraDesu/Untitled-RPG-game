using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Character
    {
        private static string? name;
        private static int level;
        private static int xp;
        private static int toNextLevel;
        private static int hp;
        private static int strength;
        private static int dexterity;
        private static int intelligence;
        private static int constitution;
        private static int luck;
        private static int charisma;

        public static string? Name
        {
            set { name = value; }
            get { return name; }
        }
        public static int Level
        {
            set {  level = value; }
            get { return level; }
        }
        public static int XP
        {
            set {  xp = value; }
            get { return xp; }
        }
        public static int ToNextLevel
        {
            set {  toNextLevel = value; }
            get { return toNextLevel; }
        }
        public static int HP
        {
            set {  hp = value; }
            get { return hp; }
        }
        public static int Strength
        {
            set {  strength = value; }
            get { return strength; }
        }
        public static int Dexterity
        {
            set {  dexterity = value; }
            get { return dexterity; }
        }
        public static int Intelligence
        {
            set { intelligence = value; }
            get { return intelligence; }
        }
        public static int Constitution
        {
            set { constitution = value; }
            get { return constitution; }
        }
        public static int Luck
        {
            set {  luck = value; }
            get { return luck; }
        }
        public static int Charisma
        {
            set { charisma = value; }
            get { return charisma; }
        }

    }
}
