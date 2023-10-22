﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace HalfDead
{
    internal class HalfDead
    {
        static int player_health = 20;
        static string[] player_options = { "1 - Heal", "2 - light attack", "3 - heavy attack"};
        static int[] weapon_damage = new int[2];
        static string Modifier;
        static bool HasHead = false;
        static bool HasWeapon = false;
        static bool Has_pet = false;
        static bool Beat_Daemon = false;
        static int HasBeen_Left = 0;
        static bool HasKeycard = false;
        static Random rnd = new Random();

        static string Random_weapon()
        {
            int choice = rnd.Next();
            switch (choice)
            {
                case 0: weapon_damage[0] = ; weapon_damage[1] = ; return ""; // come up with a list of weapons and damages.
            }
        }
        static void wait()
        {
            Console.ReadKey();
            Console.Clear();
        }

        static void Weapon_Modifier()
        {
            int rand = rnd.Next();

            switch (rand % 30)
            {
                case 0: Modifier = "good"; weapon_damage[0] += 1; break;
                case 1: Modifier = "good"; weapon_damage[0] += 1; break;
                case 2: Modifier = "good"; weapon_damage[0] += 1; break;
                case 3: Modifier = "good"; weapon_damage[0] += 1; break;
                case 4: Modifier = "slippery"; weapon_damage[0] -= 1; break;
                case 5: Modifier = "slippery"; weapon_damage[0] -= 1; break;
                case 6: Modifier = "benjamated"; weapon_damage[0] = 1; weapon_damage[1] = 2; break;
                case 7: Modifier = "higgledy piggledy"; weapon_damage[0] += 6; weapon_damage[1] += 9; break;
                case 8: Modifier = "legendary"; weapon_damage[0] += 3; weapon_damage[1] += 4; break;
                case 9: Modifier = "legendary"; weapon_damage[0] += 3; weapon_damage[1] += 4; break;
                case 10: Modifier = "rabbid"; weapon_damage[0] += 1; weapon_damage[1] += 3; break;
                case 11: Modifier = "rabbid"; weapon_damage[0] += 1; weapon_damage[1] += 3; break;
                case 12: Modifier = "rabbid"; weapon_damage[0] += 1; weapon_damage[1] += 3; break;
                case 13: Modifier = "rabbid"; weapon_damage[0] += 1; weapon_damage[1] += 3; break;
                case 14: Modifier = "epic"; weapon_damage[0] += 2; weapon_damage[1] += 3; break;
                case 15: Modifier = "epic"; weapon_damage[0] += 2; weapon_damage[1] += 3; break;
                case 16: Modifier = "epic"; weapon_damage[0] += 2; weapon_damage[1] += 3; break;
                case 17: Modifier = "enhanced"; weapon_damage[0] += 1; break;
                case 18: Modifier = "enhanced"; weapon_damage[0] += 1; break;
                case 19: Modifier = "golden"; weapon_damage[1] += 1; break;
                case 20: Modifier = "void"; weapon_damage[1] += 3; break;
                case 21: Modifier = "void"; weapon_damage[1] += 3; break;
                case 22: Modifier = "drunken"; weapon_damage[0] -= 2; weapon_damage[1] -= 3; break;
                case 23: Modifier = "drunken"; weapon_damage[0] -= 2; weapon_damage[1] -= 3; break;
                case 24: Modifier = "potent"; weapon_damage[0] += 2; break;
                case 25: Modifier = "potent"; weapon_damage[0] += 2; break;
                case 26: Modifier = "squeaky"; weapon_damage[0] -= 2; weapon_damage[1] -= 3; break;
                case 27: Modifier = "ungodly"; weapon_damage[1] += 5; break;
                case 28: Modifier = "apalling"; weapon_damage[0] -= 3; weapon_damage[1] -= 4; break;
                case 29: Modifier = "apalling"; weapon_damage[0] -= 3; weapon_damage[1] -= 4; break;
            }
        }

        static void ascii_art(string File_path)
        {
            Console.Clear();
            StreamReader sr = new StreamReader(File_path);
            string line = sr.ReadLine();

            while (line != null)
            {
                Console.CursorLeft = (Console.WindowWidth - line.Length) / 2;
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        static bool battle(string[] boss_attacks, string boss_name, int boss_health)
        {
            int boss_attack;
            while (boss_health != 0)
            {
                do
                {
                    boss_attack = rnd.Next(0, boss_attacks.Length);
                } while (boss_attacks[boss_attack] == "");

                Display_text(boss_name + " uses " + boss_attacks[boss_attack]);
                player_health -= boss_attack;

                if (player_health <= 0)
                {
                    break;
                }

                for (int i = 0; i < player_options.Length; i++)
                {
                    Display_text(player_options[i]);
                }
                Display_text("Health = " + player_health);

                string choice;

                do
                {
                    choice = Console.ReadLine();
                    int Choice = int.Parse(choice);
                    switch (Choice)
                    {
                        case 1:
                            player_health += 5;
                            Display_text("your charecter regains two health");
                            break;
                        case 2:
                            boss_health -= weapon_damage[0];
                            Display_text("The " + boss_name + " is damaged.");
                            break;
                        case 3:
                            boss_health -= weapon_damage[1];
                            Display_text("The " + boss_name + " is heavily damaged!");
                            break;
                        default:
                            Display_text("you dont have an attack equipped there!");
                            break;
                    }
                    Display_text("The " + boss_name + "'s" + " health is now " + boss_health);
                    wait();
                } while (choice != "1" | choice != "4" | choice != "2" | choice != "3");

            }

            if (boss_health <= 0)
            {
                Display_text("Congrats you have defeated the " + boss_name);
                return true;
            }
            else
            {
                Display_text("you died.");
                return false;
            }
        }

        static void Display_text(string text)
        {
            Console.CursorLeft = (Console.WindowWidth - text.Length) / 2;
            Console.WriteLine(text);
        }

        static void Title_screen()
        {
            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\krogg.txt"); // make some title art with an ascii art generator

            Display_text("1 - play game");
            Display_text("2 - exit     ");

            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1: Console.Clear(); break;
                case 2: Environment.Exit(0); break;
            }
        }

        static void Left_Corridor()
        {
            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\doom corridor.txt"); //add
            Display_text("you enter a room half destroyed and littered with bodies");
            wait();

            if (HasBeen_Left == 0)
            {
                ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\Dead man.txt"); //add
                Display_text("in front of you lays a body surrounded by a faint glow.");
                wait();
                ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\Dead man.txt"); //add
                Display_text("Do you search his body? [yes/no]");

                string ans;
                do
                {
                    ans = Console.ReadLine();
                    if (ans == "yes")
                    {
                        if (rnd.Next() % 3 == 0)
                        {
                            weapon_damage[0] = 3;
                            weapon_damage[1] = 4;
                            Weapon_Modifier();
                            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\Axe.txt"); //add
                            Display_text("you shuffle his corpse and beneath you find a " + Modifier + " Axe");
                            HasWeapon = true;
                            wait();
                            break;
                        }
                        else
                        {
                            player_health += 5;
                            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\Teddy Bear.txt"); //add
                            Display_text("You found a teddy bear");
                            wait();
                            break;
                        }
                    }
                    else if (ans == "no")
                    {
                        Main_room();
                    }
                } while (ans != "yes" | ans != "no");
            }
            HasBeen_Left += 1;

            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\doom corridor.txt");
            Display_text((HasBeen_Left > 0) ? "Would you like to search around more? [yes/no]" : "Would you like to search around? [yes/no]");
            string choice;

            do
            {
                choice = Console.ReadLine();
                if (choice == "yes")
                {
                    ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\doom corridor.txt");
                    Display_text((!Has_pet) ? "you find a shuffling cabinet and a door" : (!Beat_Daemon) ? "you have found a door" : "there is nothing else for you to find here");
                    Display_text((!HasWeapon | player_health == 20) ? "1 - go back and search body" : "1 - go back");
                    Display_text((!Has_pet) ? "2 - search the cabinet" : "");
                    Display_text((!Beat_Daemon) ? "3 - open the door" : "");

                    int Choice;
                    do
                    {
                        Choice = int.Parse(Console.ReadLine());
                        switch (Choice)
                        {
                            case 1:
                                Left_Corridor();
                                break;

                            case 2:
                                if (!Has_pet)
                                {
                                    ascii_art(@"cabinet");
                                    Display_text("The Cabinet shakes and creaks as you slowly pull it aside and within you find your new best freind");
                                    wait();
                                    Has_pet = true;
                                    ascii_art(@"pet");
                                    Display_text("you finally have someone to care for and who cares for you");
                                    Display_text("you pocket them and continue");
                                }
                                else
                                {
                                    ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\doom corridor.txt");
                                    Display_text("You've already searched here try somewhere else");
                                    wait();
                                }
                                break;

                            case 3:
                                if (!Beat_Daemon)
                                {
                                    string[] Boss_attacks = { "", "", "", "fireball", "beard of strangulation" };
                                    int Player_health = player_health;
                                    //ascii_art(@"door");
                                    Display_text("you slowly open the door");
                                    wait();
                                    //ascii_art(@"daemon");
                                    Display_text("and Behind it is a huge behemoth chaos creature abstract of all common life");
                                    Display_text("he turns, spots you");
                                    wait();
                                    //ascii_art(@"daemon");
                                    Display_text("AND LAUNCHES INTO FULL ATTACK!");
                                    wait();
                                    if (HasWeapon)
                                    {
                                        if (battle(Boss_attacks, "Daemon", 40))
                                        {
                                            Display_text("Congratulations, though wounded you have won and live to fight on to the surface");
                                            player_health = Player_health;
                                            wait();
                                            Display_text("you notice the Daemon's Heart is still beating."); //add the finding of the key card
                                            Display_text("you have the feeling his body wont remain forever");
                                            Display_text("Do you search his body? [yes/no]");
                                            string choice_other;

                                            do
                                            {
                                                choice_other = Console.ReadLine();
                                                switch (choice_other)
                                                {
                                                    case "yes":
                                                        Display_text("you stab deep into the Daemons chest and your weapon hits something");
                                                        Display_text("you begin to peel the layers flesh and at the center of it all");
                                                        Display_text("you find a heart shaped like a fist");
                                                        wait();
                                                        HasKeycard = true;
                                                        Display_text("you slit it open and discover a keycard still grasped in whovers hand this was");
                                                        Display_text("you pocket it and continue heading back to the control room.");
                                                        wait();
                                                        Main_room();
                                                        break;

                                                    case "no":

                                                        break;
                                                    default:
                                                        Display_text("sorrry, thats not a valid answer");
                                                        break;
                                                }
                                            } while (choice != "yes" | choice != "no");
                                        }
                                        else
                                        {
                                            //ascii_art(@"death_image");
                                            Display_text("Ouch!, you have been bested");
                                            Display_text("thankfully due to the strangeness of what is going on you are able");
                                            Display_text("to continue from a previous point in time");
                                            wait();
                                            Main_room();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        //ascii_art(@"death_image");
                                        Display_text("Ouch!, you have been bested");
                                        Display_text("thankfully due to the strangeness of what is going on you are able");
                                        Display_text("to continue from a previous point in time");
                                        wait();
                                        Main_room();
                                        break;
                                    }
                                }
                                else
                                {
                                    ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\doom corridor.txt");
                                    Display_text("You've already Beaten the Daemon try going elsewhere");
                                    wait();
                                }
                                break;
                            default:
                                Display_text("thats not a valid input try something else!");
                                wait();
                                break;
                        }

                    } while (Choice < 1 | Choice > 3);
                }
                else if (choice == "no")
                {
                    Main_room();
                }

            } while (choice != "yes" | choice != "no");
        }

        static void Right_Corridor()
        {

        }

        static void Up_Stairs()
        {
            Display_text("you head up the sludgy stairs and round a corner to find a locked door!");
            wait();
            if (HasHead && HasKeycard)
            {
                Display_text("you place the key card in the slot."); // description for opening door and boss battle.
                Display_text("scan the security guards face");
                Display_text("and type the passkey into the lock");
                wait();
                Display_text("the door finally creeks open slowly");
                wait();
                Display_text("and behind it is a "); // come up with a monster
                string[] attacks = { "", "soul crush", "", "","",""}; //come up with attacks
                if (battle(attacks, "boss_name_here", 80))
                {

                }
            }
        }

        static void Main_room()
        {
            if (!HasWeapon)
            {
                Display_text("as you enter you notice comething glinting by one of the corners.");
                wait();
                Weapon_Modifier();
                Display_text("you go to investigate and find a " + Modifier + Random_weapon());
                wait();
            }
            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\corridors.txt");
            Display_text("Which corridor do you go down?");
            Display_text("1 - go left         ");
            Display_text("2 - go up the stairs");
            Display_text("3 - go right        ");

            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\corridor.txt");
                    Display_text("you go down the left corridor");
                    Left_Corridor();
                    break;

                case 2:
                    ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\stairs.txt");
                    Display_text("you go up the stairs");
                    Up_Stairs();
                    break;

                case 3:
                    ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\corridor.txt");
                    Display_text("you go down the right corridor");
                    Right_Corridor();
                    break;
            }
        }

        static void Main(string[] args)
        {
            Title_screen();
            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\console.txt");  // find a control room picture
            Display_text("You turn around, all contempt and malice flushed as it washes over you.");
            wait();
            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\corridors.txt"); // picture of three corridors
            Display_text("Now to escape");
            wait();
            Main_room();

            // test stuff to make the functions i needed
            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\krogg.txt");
            string[] boss_attacks = { "", "", "", "fireball", "beard of strangulation" };

            Console.ReadKey();
        }
    }
}