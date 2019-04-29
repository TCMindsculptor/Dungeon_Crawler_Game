using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public enum Race
    {
        //There is no direct way to create an enum through the visual studio interface,
        //so to make one you create a a class, make it public, and replace the class
        //keyword with enum. The values contain no spaces and are comma seperated
        Elf,
        Dwarf,
        Drow,
        Human,
        Dragonborn,
        Halfling
    }//end Race class
}//end namespace
