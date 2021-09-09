using System;

namespace rsharp8_CSE1322L_Lab4
{
    class Driver
    {
        static void Main(string[] args)
        {
            int userChoice = 0;
            Checking c = new Checking();
            Savings s = new Savings();

            do
            {
                Console.WriteLine("1. Withdraw from Checking");
                Console.WriteLine("2. Withdraw from Savings");
                Console.WriteLine("3. Deposit to Checking");
                Console.WriteLine("4. Deposit to Savings");
                Console.WriteLine("5. Balance of Checking");
                Console.WriteLine("6. Balance of Savings");
                Console.WriteLine("7. Award Interest to Savings Now");
                Console.WriteLine("8. Quit");

                userChoice = Int32.Parse(Console.ReadLine());

                if (userChoice == 1)
                {
                    Console.WriteLine("How much would you like to withdraw from Checking?");
                    float cWith = float.Parse(Console.ReadLine());
                    c.withdrawal(cWith);
                }
                else if (userChoice == 2)
                {
                    Console.WriteLine("How much would you like to withdraw from Savings?");
                    float sWith = float.Parse(Console.ReadLine());
                    s.withdrawal(sWith);
                }
                else if (userChoice == 3)
                {
                    Console.WriteLine("How much would you like to deposit into Checking?");
                    float cDep = float.Parse(Console.ReadLine());
                    c.deposit(cDep);
                }
                else if (userChoice == 4)
                {
                    Console.WriteLine("How much would you like to deposit into Savings?");
                    float sDep = float.Parse(Console.ReadLine());
                    s.deposit(sDep);
                }
                else if (userChoice == 5)
                {
                    Console.WriteLine($"Your balance for checking {c.getAccountNumber()} is ${c.getAccountBalance()}");
                }
                else if (userChoice == 6)
                {
                    Console.WriteLine($"Your balance for savings {s.getAccountNumber()} is ${s.getAccountBalance()}");
                }
                else if (userChoice == 7)
                {
                    s.interest();
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

            } while (userChoice != 8);
        }
    }
    
    abstract class Account
    {
        static int account_counter = 10001;
        private int account_number;
        private float account_balance;

        public Account()
        {
            account_number = account_counter++;
            account_balance = 0f;
        }

        public Account(float bal)
        {
            account_number = account_counter++;
            account_balance = bal;
        }

        public int getAccountNumber()
        {
            return account_number;
        }

        public float getAccountBalance()
        {
            return account_balance;
        }

        public void setAccountBalance(float bal)
        {
            account_balance = bal;
        }

        public virtual void withdrawal(float amt)
        {
            account_balance -= amt;
        }

        public virtual void deposit(float amt)
        {
            account_balance += amt;
            if (this is Checking) { Console.WriteLine("Doing default deposit."); }
        }
    }

    class Checking : Account
    {
        public Checking() : base() { }
        public Checking(float bal) : base(bal){ }

        public override void withdrawal(float amt)
        {
            if (amt > getAccountBalance())
            {
                Console.WriteLine("Charging an overdraft fee of $20 because account is below $0");
                base.withdrawal(20f);
            }

            base.withdrawal(amt);
        }
    }

    class Savings : Account
    {
        private int deposit_counter = 0;

        public Savings() : base() { }
        public Savings(float bal) : base(bal) { }

        public override void withdrawal(float amt)
        {
            if ((getAccountBalance() - amt) < 500)
            {
                Console.WriteLine("Charging a fee of $10 because you are below $500");
                base.withdrawal(10f);
            }

            base.withdrawal(amt);
        }

        public override void deposit(float amt)
        {
            deposit_counter++;
            Console.WriteLine($"This is deposit number {deposit_counter} to this account.");
            base.deposit(amt);
            
            if (deposit_counter >= 6)
            {
                Console.WriteLine("Charging a fee of $10");
                base.withdrawal(10f);
            }
        }

        public void interest()
        {
            float interestEarned = getAccountBalance() * 0.015f;
            Console.WriteLine($"Customer earned ${interestEarned} in interest");
            base.deposit(interestEarned);
        }

    }
}