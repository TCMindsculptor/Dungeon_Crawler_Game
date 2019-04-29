using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = string.Format("Delightful Dungeon");


            short killCount = 0;
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Race playerRace = Race.Human;
            ConsoleKey raceChoice;

            bool raceExit = false;
            do
            {
                Console.WriteLine("Choose your race:\nA) Elf\nB) Dwarf\nC) Human\nD) Drow\nE) Dragonborn\n"
                + "F) Halfling");
                raceChoice = Console.ReadKey(true).Key;
                switch (raceChoice)
                {
                    case ConsoleKey.A:
                        playerRace = Race.Elf;
                        raceExit = true;
                        break;
                    case ConsoleKey.B:
                        playerRace = Race.Dwarf;
                        raceExit = true;
                        break;
                    case ConsoleKey.C:
                        playerRace = Race.Human;
                        raceExit = true;
                        break;
                    case ConsoleKey.D:
                        playerRace = Race.Drow;
                        raceExit = true;
                        break;
                    case ConsoleKey.E:
                        playerRace = Race.Dragonborn;
                        raceExit = true;
                        break;
                    case ConsoleKey.F:
                        playerRace = Race.Halfling;
                        raceExit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid entry. Try again.");
                        break;
                }
            } while (raceExit == false);

            Console.Clear();
            Console.WriteLine($"Welcome {name}, the {playerRace}! Your journey begins...\n");


            Weapon battleAxe = new Weapon("Battle Axe", 1, 6, 5, true);
            Weapon dualScimitars = new Weapon("Dual Scimitars", 2, 8, 0, true);

            Player player = new Player(name, 60, 25, 50, playerRace, dualScimitars, 50);

            Console.WriteLine(player + "\n");

            bool exit = false;

            do
            {
                Console.WriteLine(GetRoom());

                Dragon d1 = new Dragon("Adult Red Dragon", 30, 30, 50, 10, 1, 8, "Angry red dragon!", false);
                Dragon d2 = new Dragon("Alpha Red Dragon", 60, 60, 75, 30, 2, 10, "A terrible, evil wyrm!", true);
                Changeling ch1 = new Changeling("Changeling", 45, 45, 50, 15, 1, 8, "Constantly changing forms.");

                List<Monster> monsters = new List<Monster>() { d1, d1, ch1, ch1, d2 };
                Monster monster = monsters[new Random().Next(monsters.Count)];

                Console.WriteLine("In this room: " + monster.Name);

                bool reload = false;

                do
                {
                    Console.Title = string.Format($"Kills: {killCount}     Life: {player.Life}");
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\nR)Run Away!\nC)Character Stats\nM)Monster Stats\nE) Exit");
                    ConsoleKey choice = Console.ReadKey(true).Key;
                    Console.Clear();  
                    switch (choice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //xp and loot system would go here
                                killCount++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"You killed {monster.Name}!");
                                Console.ResetColor();
                                reload = true;
                            }//end if
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("RUN AWAY!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            break;

                        case ConsoleKey.C:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("You decide to leave the dungeon, knowing you will never "
                                + "know the delights deep within the dungeon...");
                            exit = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid entry. Try again.");
                            break;
                    }//end switch

                    if (player.Life <= 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("You died. Git Gud.");
                            Console.ResetColor();
                        }//end for loop
                        exit = true;
                    }//end if (die)

                } while (reload == false && exit == false);
            } while (exit == false);

            Console.WriteLine($"\nGAME OVER\nYou killed {killCount} monsters.");


        }//end main

        private static string GetRoom()
        {
            string[] rooms =
            {
                "This small chamber is a bloody mess. The corpse of a minotaur lies on the floor, \n"
                + "its belly carved out. The creature's innards are largely missing, and yet you \n"
                + "detect no other wounds. Bloody, froglike footprints track away from the corpse \n"
                + "and out an open door.\n",

                "You open the door and before you is a dragon's hoard of treasure. \n"
                + "Coins cover every inch of the room, and jeweled objects of precious metal jut up \n"
                + "from the money like glittering islands in a sea of gold.\n",

                "You open the door and before you is a dragon's hoard of treasure. Coins cover \n"
                + "every inch of the room, and jeweled objects of precious metal jut up from the \n"
                + "money like glittering islands in a sea of gold.\n",

                "A chill wind blows against you as you open the door. Beyond it, you see \n"
                +"that the floor and ceiling are nothing but iron grates. Above and below \n"
                +"the grates the walls extend up and down with no true ceiling or floor within your \n"
                +"range of vision. It's as though the chamber is a bridge through the shaft of a great \n"
                + "well. Standing on the edge of this shaft, you feel a chill wind pass down it and \n"
                + "over your shoulder into the hall beyond.\n",

                "This room is a tomb. Stone sarcophagi stand in five rows of three, each carved with the \n"
                +"visage of a warrior lying in state. In their center, one sarcophagus stands taller than \n"
                +"the rest. Held up by six squat pillars, its stone bears the carving of a beautiful woman \n"
                +"who seems more asleep than dead. The carving of the warriors is skillful but seems \n"
                +"perfunctory compared to the love a sculptor must have lavished upon the lifelike carving \n"
                +"of the woman.\n",

                "The manacles set into the walls of this room give you the distinct impression \n"
                +"that it was used as a prison and torture chamber, although you can see no evidence \n"
                +"of torture devices. One particularly large set of manacles -- big enough for \n"
                +"an ogre -- have been broken open.\n",

                "You smelled smoke as you moved down the hall, and rounding the corner into this room \n"
                +"you see why. Every surface bears scorch marks and ash piles on the floor. The room \n"
                +"reeks of fire and burnt flesh. Either a great battle happened here or the room \n"
                +"bears some fire danger you cannot see for no flames light the room anymore.\n",

                "A strange ceiling is the focal point of the room before you. It's honeycombed \n"
                +"with hundreds of holes about as wide as your head. They seem to penetrate the \n"
                +"ceiling to some height beyond a couple feet, but you can't be sure from your \n"
                +"vantage point.\n",

                "You open the door to a long narrow room with a high ceiling. Three thick circles of \n"
                +"wood rest on wooden stands. You're not certain what they are because you came into \n"
                +"the room behind them. \n",

                "A cluster of low crates surrounds a barrel in the center of this chamber. Atop \n"
                +"the barrel lies a stack of copper coins and two stacks of cards, one face up. \n"
                +"Meanwhile, atop each crate rests a fan of five face-down playing cards. A thin \n"
                +"layer of dust covers everything. Clearly someone meant to return to their game of cards.\n",

                "Looking into this room, you note four pits in the floor. A wide square is \n"
                +"nearest you, a triangular pit beyond it, and a little farther than both lie \n"
                +"two circular pits. The room is rectangular nearest you but it widens into a \n"
                +"larger rounded chamber starting just beyond the rectangular pit. You note that \n"
                +"many flagstones, ceiling tiles, and wall blocks are carved with a skull emblem of \n"
                +"some kind, whose dark openings emulate the layout of the pits. You've opened a door \n"
                +"in the \"chin\" and are looking up at the face.\n",

                "This room is hung with hundreds of dusty tapestries. All show signs of wear: moth holes,\n"
                +" scorch marks, dark stains, and the damage of years of neglect. They hang on all \n"
                +"the walls and hang from the ceiling to brush against the floor, blocking your \n"
                +"view of the rest of the room.\n",

                "You catch a whiff of the unmistakable metallic tang of blood as you open the door. \n"
                +"The floor is covered with it, and splashes of blood spatter the walls. Some \n"
                +"drops even reach the ceiling. It looks fresh, but you don't see any bodies or \n"
                +"footprints leaving the chamber.\n"
            };//end rooms[]

            return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom()
    }//end class
}//end namespace
