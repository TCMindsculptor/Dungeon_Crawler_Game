using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //fields
       // private string _name;
       // private int _hitChance;
       // private int _block;
        //private int _life;
        // private int _maxLife;
        //private Race _characterRace;
        //private Weapon _equippedWeapon;

        /*
         * Automatic properties were introduced with .NET 3.5. They are a shortcut
         * syntax that allows you to quickly build a property without a field. Instead the
         * field gets build by the compiler at runtime and automatically tied
         * to the property. You cannot use automatic properties for any property with a business
         * rule, so we have  a field for Life, as it is going to have a rule that
         * it cannot be more than MaxLife.
         */

        //properties
        //public string Name { get; set; } //prop + tab + tab
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        _life = value <= MaxLife ? value : MaxLife;
        //    }//set
        //}//end Life

        //ctors
        public Player(string name, int hitChance, int block, int maxLife, Race characterRace, Weapon equippedWeapon, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }//end FQCTOR

        //methods
        public override string ToString()
        {
            string description = "";
            switch (CharacterRace)
            {
                case Race.Elf:
                    description = "You're an elf. I bet you fit the stereotype.";
                    HitChance += 10;
                    Life -= 5;
                    MaxLife -= 5;//can change stats based on raceChoice from main();
                    break;
                case Race.Dwarf:
                    description = "You're a short, grumpy dwarf.";
                    break;
                case Race.Drow:
                    description = "You're a dark, stealthy drow.";
                    break;
                case Race.Human:
                    description = "You suck! who chooses human?";
                    break;
                case Race.Dragonborn:
                    description = "You're a dragonborn. Basically a lizardman. Not cool.";
                    break;
                case Race.Halfling:
                    description = "You're a halfling. I bet you only play thief classes too.";
                    break;
            }//end switch

            return string.Format("-=-=- {0} -=-=-\nLife: {1} of {2}\nHit Chance: {3}%\nWeapon:\n{4}\n"
                + "Block/Dodge: {5}%\nDesription: {6}", Name, Life, MaxLife, HitChance, EquippedWeapon,
                Block, description);
        }//end ToString()

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }


    }//end Player class
}//end namespace
