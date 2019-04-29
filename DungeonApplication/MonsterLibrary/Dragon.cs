using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Dragon : Monster
    {
        public bool IsAncient { get; set; }

        public Dragon(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isAncient)
            :base(name,life,maxLife,hitChance,block,minDamage,maxDamage,description)
        {
            IsAncient = isAncient;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + (IsAncient ? "It is ancient and terrifying." : "It is an adult dragon.");
        }//end ToString()

        public override int CalcBlock()
        {
            return IsAncient ? Block * 2 : Block;
        }//end CalcBlock()

    }//end class
}//end namespace
