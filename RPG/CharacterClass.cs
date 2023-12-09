using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class CharacterClass
    {
        private static string? className;
        private static string? mainWeapon;
        private static string? dmgAtribute;
        public enum currentClass
        {
            None = 0,
            Warrior,
            Archer,
            Mage,
        }

        public static string? ClassName
        {
            set { className = value; }
            get { return className; }
        }

        public static string? MainWeapon
        {
            set {  mainWeapon = value; }
            get { return mainWeapon; }
        }
        public static string? DmgAtribute
        {
            set {  dmgAtribute = value; }
            get { return dmgAtribute; }
        }
        
    }
    public class Mage : CharacterClass
    {
        static string? element;
        static int mana;
        public static string? Element
        {
            set { element = value; }
            get { return element; }
        }
        public static int Mana
        {
            set {  mana = value; }
            get { return mana; }
        }
        
    }
}
