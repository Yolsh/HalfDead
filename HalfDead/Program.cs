using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace HalfDead
{
    internal class Program
    {
        static int player_health = 10;
        static int boss_health = 10;
        static Random rnd = new Random();

        static void ascii_art(string File_path)
        {
            StreamReader sr = new StreamReader(File_path);
            string line = sr.ReadLine();

            while(line != null)
            {
                Console.CursorLeft = (Console.WindowWidth - line.Length) / 2;
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        static bool battle(string[] boss_attacks, string[] player_options, int[] weapon_damages, string boss_name)
        {
            int boss_attack;
            do
            {
                do
                {
                    boss_attack = rnd.Next(0, boss_attacks.Length);
                } while (boss_attacks[boss_attack] == "");

                Display_text(boss_name + " uses " + boss_attacks[boss_attack]);
                player_health -= boss_attack;

                if(player_health <= 0)
                {
                    break;
                }

                for (int i = 0; i < player_options.Length; i++)
                {
                    if (player_options[i] != "")
                    {
                        Display_text(player_options[i]);
                    }
                }
                Display_text("Health = " + player_health);

                int choice;

                do
                {
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            break;

                        case 2:
                            player_health += 2;
                            Display_text("your charecter regains two health");
                            break;

                        case 3:
                            boss_health -= weapon_damages[0];
                            Display_text("The " + boss_name + " is damaged.");
                            break;
                        case 4:
                            boss_health -= weapon_damages[1];
                            Display_text("The "+ boss_name + " is heavily damaged!");
                            break;
                    }
                    Display_text("The " + boss_name + "s" + " health is now " + boss_health);

                    Console.ReadKey();
                    Console.Clear();

                } while(choice < 1 | choice > 4);

            } while (boss_health != 0);

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
            ascii_art(@"empty"); // make some title art with an ascii art generator

            Console.WriteLine(""); // first introduction text.
        }

        static void Main(string[] args)
        {
            Title_screen();

            // test stuff to make the functions i needed
            ascii_art(@"C:\Users\josha\OneDrive\Documents\Barton Peveril\Computer Science\HalfDead\krogg.txt");
            string[] boss_attacks = {"", "", "", "fireball", "beard of strangulation"};
            string[] player_options = {"1 - block next attack", "2 - Heal", "3 - light attack", "4 - heavy attack" };
            int[] weapon_damage = { 3, 5 };

            battle(boss_attacks, player_options, weapon_damage, "Daemon");
            Console.ReadKey();
        }
    }
}
