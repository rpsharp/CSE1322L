using System;

namespace rsharp8_CSE1322L_Assignment1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Notes twenties = new Notes(20);
            Notes tens = new Notes(10);
            Notes fives = new Notes(5);
            Notes ones = new Notes(1);

            Coins quarters = new Coins(0.25f, 0.2f);
            Coins dimes = new Coins(0.10f, 0.08f);
            Coins nickels = new Coins(0.05f, 0.176f);
            Coins pennies = new Coins(0.01f, 0.088f);

            dimes.increaseQuantity(41);
            nickels.increaseQuantity(17);
            pennies.increaseQuantity(132);
            ones.increaseQuantity(33);
            fives.increaseQuantity(12);
            tens.increaseQuantity(2);
            twenties.increaseQuantity(5);

            //Console.Write($"{twenties}{tens}{fives}{ones}{quarters}{dimes}{nickels}{pennies}");
            Console.WriteLine(twenties.ToString());
            Console.WriteLine(tens.ToString());
            Console.WriteLine(fives.ToString());
            Console.WriteLine(ones.ToString());

            Console.WriteLine(quarters.ToString());
            Console.WriteLine(dimes.ToString());
            Console.WriteLine(nickels.ToString());
            Console.WriteLine(pennies.ToString());

            //find Total Money
            float getTotalValue()
            {
                float totalValue = twenties.getTotalValue() + tens.getTotalValue() + fives.getTotalValue() + ones.getTotalValue() + quarters.getTotalValue() + dimes.getTotalValue() + nickels.getTotalValue() + pennies.getTotalValue();
                return totalValue;
            }
            float getTotalCoinWeight()
            {
                float totalCoinWeight = quarters.getTotalWeight() + dimes.getTotalWeight() + nickels.getTotalWeight() + pennies.getTotalWeight();
                return totalCoinWeight;
            }
        
            Console.WriteLine("Total Money is $" + getTotalValue().ToString("F2") + " Total Weight is " + getTotalCoinWeight().ToString() + "oz");

            //Take User Input
            float userInput = 0.0f;
            Console.WriteLine("How much do you need?");
            userInput = float.Parse(Console.ReadLine());

            void getChange(float change)
            {
                while (change > 0.001 && getTotalValue() > 0.001)
                {
                    if (change > 20 && twenties.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a $20 note");
                        twenties.decreaseQuantity(1);
                        change -= 20;
                    }
                    else if (change > 10 && tens.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a $10 note");
                        tens.decreaseQuantity(1);
                        change -= 10;
                    }
                    else if (change > 5 && fives.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a $5 note");
                        fives.decreaseQuantity(1);
                        change -= 5;
                    }
                    else if (change > 1 && ones.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a $1 note");
                        ones.decreaseQuantity(1);
                        change -= 1;
                    }
                    else if (change > 0.25 && quarters.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a quarter");
                        quarters.decreaseQuantity(1);
                        change -= 0.25f;
                    }
                    else if (change > 0.10 && dimes.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a dime");
                        dimes.decreaseQuantity(1);
                        change -= 0.10f;
                    }
                    else if (change > 0.05 && nickels.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a nickel");
                        nickels.decreaseQuantity(1);
                        change -= 0.05f;
                    }
                    else if (change > 0.01 && pennies.getQuantityOnHand() > 0)
                    {
                        Console.WriteLine("Give them a penny");
                        pennies.decreaseQuantity(1);
                        change -= 0.01f;
                    }
                    else
                    {
                        break;
                    }
                } 

                if (change > 0.001 && pennies.getQuantityOnHand() == 0)
                {
                    Console.WriteLine("I don't have enough money. I still owe you $" + change.ToString("F2"));
                }
            }

            getChange(userInput);
            Console.WriteLine("I have $" + getTotalValue().ToString("F2") + " left, its total weight is " + getTotalCoinWeight().ToString() + "oz");
        }
    }

    class Coins
    {
        private int quantityOnHand;
        private float denomination;
        private float weight;

        public Coins(float denomination, float weight)
        {
            quantityOnHand = 0;
            this.denomination = denomination;
            this.weight = weight;
        }

        public float getTotalWeight()
        {
            return weight * quantityOnHand;
        }

        public float getTotalValue()
        {
            return denomination * quantityOnHand;
        }

        public void increaseQuantity(int q)
        {
            quantityOnHand += q;
        }

        public void decreaseQuantity(int q)
        {
            quantityOnHand -= q;
            if (quantityOnHand < 0)
            {
                quantityOnHand = 0;
            }
        }

        public int getQuantityOnHand()
        {
            return quantityOnHand;
        }

        public string printPretty(float amount)
        {
            return ("$" + amount.ToString("F2"));
        }

        public override string ToString()
        {
            return printPretty(getTotalValue()) + " in " + printPretty(denomination) + " coins.";
        }
    }

    class Notes
    {
        private int quantityOnHand;
        private int denomination;

        public Notes(int denomination)
        {
            quantityOnHand = 0;
            this.denomination = denomination;
        }

        public int getTotalValue()
        {
            return denomination * quantityOnHand;
        }

        public void increaseQuantity(int q)
        {
            quantityOnHand += q;
        }

        public void decreaseQuantity(int q)
        {
            quantityOnHand -= q;
            if (quantityOnHand < 0)
            {
                quantityOnHand = 0;
            }
        }

        public int getQuantityOnHand()
        {
            return quantityOnHand;
        }

        public string printPretty(float amount)
        {
            return ("$" + amount.ToString("F2"));
        }

        public override string ToString()
        {
            return printPretty(getTotalValue()) + " in " + printPretty(denomination) + " notes.";
        }
    }
}
