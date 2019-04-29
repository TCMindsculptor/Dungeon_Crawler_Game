using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //The abstract keyword indicates that the thing being modified is an incomplete
    //implementation, meaning it is never intended to be instantiated on its own.
    //When applied to a class it indicates that the class is only intended to be a 
    //parent class for child classes.
    public abstract class Character
    {
        private int _life;

        public string Name { get; set; } //prop + tab + tab
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//set
        }//end Life

        public virtual int CalcBlock()
        {
            //We made this virtual so we can overrid it in child classes
            return Block;
        }//end CalcBlock()

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        //public virtual int CalcDamage()
        //{
        //    return 0;
        //    //player and monster calculate damage differently, so we can't have
        //    //default functionality like we do for  HitChance and Block. Instead, 
        //    //we're just returning 0 and we will override the functionality in 
        //    //the derived classes.
        //}//end CalcDamage()

        public abstract int CalcDamage();
        //The abstract keyword FORCES child classes to overrid this functionality 
        //by providing a method body. This prevents the possible mistake of retunring 
        //zero which could happen with the above version
    }//end class
}//end namespace
