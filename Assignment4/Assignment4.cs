using System;
using static System.Console;
using System.Collections.Generic;

namespace rsharp8_CSE1322L_Assignment4
{
    class Driver
    {
        static void Main()
        {
            Pokedex myDex = new Pokedex();
            float cpm = 0.49985844f;
            string choice;
            do
            {
                Pokemon encounter = spawn();
                
                do
                {
                    float multiplier = throwBall();
                    float catchProb = 1 - (float)Math.Pow(1 - (encounter.getBaseCatchRate() / (2 * cpm)), multiplier);
                    Random rnd = new Random();
                    float catchThreshold = (float)rnd.NextDouble();

                    if (catchThreshold < catchProb)
                    {
                        WriteLine($"{encounter} Caught!");
                        myDex.addToDex(encounter);
                        break;
                    }
                    else { WriteLine($"Oops, {encounter} jumped out, try again!"); }
                } while (true);

                WriteLine("Continue catching Pokemon? (Y or N)");
                choice = ReadLine();

            } while (choice != "N");

            Write(myDex.ToString());
        }

        static Pokemon spawn()
        {
            Random rnd = new Random();
            int level = rnd.Next(0, 20);
            int poke = rnd.Next(0, 3);
            Pokemon encounter;

            if (poke == 1)
            {
                encounter = new Bulbasaur(level);
                WriteLine($"You encounter {(Bulbasaur)encounter}");
            }
            else if (poke == 2)
            {
                encounter = new Charmander(level);
                WriteLine($"You encounter {(Charmander)encounter}");
            }
            else
            {
                encounter = new Caterpie(level);
                WriteLine($"You encounter {(Caterpie)encounter}");
            }

            return encounter;
        }

        static float throwBall()
        {
            WriteLine("Which type of ball do you wish to use? (Poke, Great, Ultra)");
            string ball = ReadLine();
            float ballMultiplier = 0;

            if (ball == "Poke") { ballMultiplier = 1f; }
            else if (ball == "Great") { ballMultiplier = 1.5f; }
            else if (ball == "Ultra") { ballMultiplier = 2f; }

            WriteLine("Which berry do you wish to use? (Razz, SilverPinap, GoldenRazz)");
            string berry = ReadLine();
            float berryMultiplier= 0;

            if (berry == "Razz") { berryMultiplier = 1.5f; }
            else if (berry == "SilverPinap") { berryMultiplier = 1.8f; }
            else if (berry == "GoldenRazz") { berryMultiplier = 2.5f; }
            else { berryMultiplier = 1f; }

            WriteLine("Is this a curveball? (Yes or No)");
            string curve = ReadLine();
            float curveMultiplier= 0;

            if (curve == "Yes") { curveMultiplier = 1.7f; }
            else { curveMultiplier = 1f; }

            return ballMultiplier * berryMultiplier * curveMultiplier;
        }
    }

    class Pokemon
    {
        private int level;
        private double baseCatchRate;

        public Pokemon(int level, double baseCatchRate)
        {
            this.level = level;
            this.baseCatchRate = baseCatchRate;
        }

        public int getLevel() { return level; }
        public double getBaseCatchRate() { return baseCatchRate; }

    }

    class Bulbasaur : Pokemon
    {
        public Bulbasaur(int level) : base(level, 0.2) { }

        public override string ToString()
        {
            return $"A level {this.getLevel()} Bulbasaur";
        }
    }

    class Caterpie : Pokemon
    {
        public Caterpie(int level) : base(level, 0.5) { }

        public override string ToString()
        {
            return $"A level {getLevel()} Caterpie";
        }
    }

    class Charmander : Pokemon
    { 
        public Charmander(int level) : base(level, 0.2) { }

        public override string ToString()
        {
            return $"A level {getLevel()} Charmander";
        }
    }

    class Pokedex
    {
        private List<Pokemon> myPokedex = new List<Pokemon>();

        public void addToDex(Pokemon pokemon) { myPokedex.Add(pokemon); }

        public override string ToString()
        {
            string output = "You have the following Pokemon:\n";

            foreach (Pokemon mon in myPokedex)
            {
                if (mon is Bulbasaur)
                {
                    output += $"{(Bulbasaur)mon}\n";
                }
                else if (mon is Charmander)
                {
                    output += $"{(Charmander)mon}\n";
                }
                else if (mon is Caterpie)
                {
                    output += $"{(Caterpie)mon}\n";
                }
                else
                {
                    output += "Pokemon added incorrectly.\n";
                }
            }

            return output;
        }
    }
}
