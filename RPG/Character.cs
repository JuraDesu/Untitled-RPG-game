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
        protected string? name;
        protected int level;
        protected int xp;
        protected int toNextLevel;
        protected int hp;
        protected int strength;
        protected int dexterity;
        protected int intelligence;
        protected int constitution;
        protected int luck;
        protected int charisma;

        public string? Name
        {
            set { name = value; }
            get { return name; }
        }
        public int Level
        {
            set {  level = value; }
            get { return level; }
        }
        public int XP
        {
            set {  xp = value; }
            get { return xp; }
        }
        public int ToNextLevel
        {
            set {  toNextLevel = value; }
            get { return toNextLevel; }
        }
        public int HP
        {
            set {  hp = value; }
            get { return hp; }
        }
        public int Strength
        {
            set {  strength = value; }
            get { return strength; }
        }
        public int Dexterity
        {
            set {  dexterity = value; }
            get { return dexterity; }
        }
        public int Intelligence
        {
            set { intelligence = value; }
            get { return intelligence; }
        }
        public int Constitution
        {
            set { constitution = value; }
            get { return constitution; }
        }
        public int Luck
        {
            set {  luck = value; }
            get { return luck; }
        }
        public int Charisma
        {
            set { charisma = value; }
            get { return charisma; }
        }

        public Character(string? name,
            int level,
            int xp,
            int toNextLevel,
            int hp,
            int strength,
            int dexterity,
            int intelligence,
            int constitution,
            int luck,
            int charisma)
        {
            this.name = name;
            this.level = level;
            this.xp = xp;
            this.toNextLevel = toNextLevel;
            this.hp = hp;
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.constitution = constitution;
            this.luck = luck;
            this.charisma = charisma;
        }
    }
}
