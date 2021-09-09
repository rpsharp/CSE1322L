using System;

namespace rsharp8_CSE1322L_Lab2
{
    class Driver
    {
        static void Main(string[] args)
        {
            StockItem milk = new StockItem("1 Gallon of Milk", 3.60f, 15);
            StockItem bread = new StockItem("1 Loaf of Bread", 1.98f, 30);

            int userChoice;
            do
            {
                Console.WriteLine("1. Sold One Milk");
                Console.WriteLine("2. Sold One Bread");
                Console.WriteLine("3. Change Price of Milk");
                Console.WriteLine("4. Change Price of Bread");
                Console.WriteLine("5. Add Milk to Inventory");
                Console.WriteLine("6. Add Bread to Inventory");
                Console.WriteLine("7. See Inventory");
                Console.WriteLine("8. Quit");

                string rawInput = Console.ReadLine();
                userChoice = Int32.Parse(rawInput);

                if (userChoice == 1)
                {
                    milk.lowerQuantity(1);
                }
                else if (userChoice == 2)
                {
                    bread.lowerQuantity(1);
                }
                else if (userChoice == 3)
                {
                    Console.WriteLine("What is the new price for milk?");
                    rawInput = Console.ReadLine();
                    float newPrice = float.Parse(rawInput);

                    milk.setPrice(newPrice);
                }
                else if (userChoice == 4)
                {
                    Console.WriteLine("What is the new price for bread?");
                    rawInput = Console.ReadLine();
                    float newPrice = float.Parse(rawInput);

                    bread.setPrice(newPrice);
                }
                else if (userChoice == 5)
                {
                    Console.WriteLine("How many milk did we get?");
                    rawInput = Console.ReadLine();
                    int newQuantity = Int32.Parse(rawInput);

                    milk.raiseQuantity(newQuantity);
                }
                else if (userChoice == 6)
                {
                    Console.WriteLine("How many bread did we get?");
                    rawInput = Console.ReadLine();
                    int newQuantity = Int32.Parse(rawInput);

                    bread.raiseQuantity(newQuantity);
                }
                else if (userChoice == 7)
                {
                    Console.WriteLine("Milk: " + milk.ToString());
                    Console.WriteLine("Bread: " + bread.ToString());
                }

            } while (userChoice != 8);
        }
    }

    class StockItem
    {
        static int idCounter = 0;

        private String description;
        private int id;
        private float price;
        private int quantity;

        //Constructors
        public StockItem()
        {
            id = idCounter++;
            description = "(blank)";
            price = 0.00f;
            quantity = 0;
        }

        public StockItem(String description, float price, int quantity)
        {
            id = idCounter++;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return "\n Description: " + description + "\n ID: " + id + "\n Price: $" + price.ToString("F2") + "\n Quantity: " + quantity;
        }

        //Getter Methods
        public string getDescription()
        {
            return description;
        }

        public int getID()
        {
            return id;
        }

        public float getPrice()
        {
            return price;
        }

        public int getQuantity()
        {
            return quantity;
        }

        //Setter Methods
        public void setPrice(float price)
        {
            if (price < 0)
            {
                Console.WriteLine("Price cannot be below $0");
            }
            else
            {
                this.price = price;
            }
        }

        public void lowerQuantity(int quantity)
        {
            if (this.quantity < quantity)
            {
                Console.WriteLine("Not enough items available");
            }
            else
            {
                this.quantity -= quantity;
            }
        }

        public void raiseQuantity(int quantity)
        {
            this.quantity += quantity;
        }
    }
}
