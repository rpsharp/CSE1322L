using System;
using static System.Console;

namespace rsharp8_CSE1322L_Lab6
{
    class Driver
    {
        static void Main()
        {
            FibIteration fibI = new FibIteration();
            FibFormula fibF = new FibFormula();

            WriteLine("Enter the number you want to find the Fibonacci Series for:");
            int num = Int32.Parse(ReadLine());

            WriteLine($"Fib of {num} by iteration is: {fibI.calculate_fib(num)}");
            WriteLine($"Fib of {num} by formula is: {fibF.calculate_fib(num)}");
        }
    }

    interface IFindFib
    {
        public int calculate_fib(int value);
    }

    class FibIteration : IFindFib
    {
        public int calculate_fib(int value)
        {
            int n1 = 0; int n2 = 1; int sum;

            if (value == 1 || value == 2)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i < value; i++)
                {
                    sum = n1 + n2;
                    n1 = n2;
                    n2 = sum;
                }

                return n2;
            }
        }
    }

    class FibFormula : IFindFib
    {
        public int calculate_fib(int value)
        {
            double fib = (Math.Pow((1 + Math.Sqrt(5)) / 2, value) - Math.Pow((1 - Math.Sqrt(5)) / 2, value)) / Math.Sqrt(5);

            return (int)fib;
        }
    }
}
