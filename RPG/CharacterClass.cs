using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class CharacterClass
    {
        private string? className;
        private string? mainWeapon;
        private string? dmgAtribute;
        public enum currentClass
        {
            None = 0,
            Warrior,
            Archer,
            Mage,
        }

        public string? ClassName
        {
            set { className = value; }
            get { return className; }
        }

        public string? MainWeapon
        {
            set {  mainWeapon = value; }
            get { return mainWeapon; }
        }
        public string? DmgAtribute
        {
            set {  dmgAtribute = value; }
            get { return dmgAtribute; }
        }
        public CharacterClass(string? className, string? mainWeapon, string? dmgAtribute) 
        {
            this.className = className;
            this.mainWeapon = mainWeapon;
            this.dmgAtribute = dmgAtribute;
        }
    }
    public class Mage : CharacterClass
    {
        string? element;
        public string? Element
        {
            set {  element = value; }
            get { return element; }
        }
        public Mage(string? className, string? mainWeapon, string? dmgAtribute, string? element) : base(className, mainWeapon, dmgAtribute)
        {
            this.element = element;
        }
    }
}
