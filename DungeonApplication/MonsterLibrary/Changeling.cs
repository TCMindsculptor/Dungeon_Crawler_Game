using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Changeling : Monster
    {
        public Changeling(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {

        }//end FQCTOR

        public override string ToString()
        {
            return string.Format("It's changing form hides it's stats.");
        }//end ToString()
    }

}
