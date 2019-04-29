using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private int _bonustHitChance;
        private bool _isTwoHanded;

        //properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int BonusHitChance
        {
            get { return _bonustHitChance; }
            set { _bonustHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }
        }

        //constructors
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
        {
            /*
             * THey order that the paremeters are placed in a doesn't matter at all. The order
             * they are assigned in is critical if we have properties whose business rules rely
             * on the value of other properties. In that case it's best to set the dependant values : first
             */
            MaxDamage = maxDamage;
            Name = name;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//end FQCTOR

        //methods
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} damage\nBonus Hit Chance: {3}%\t{4}", Name, MinDamage,
                MaxDamage, BonusHitChance, IsTwoHanded ? "Two Handed" : "One Handed");

        }

    }
}
