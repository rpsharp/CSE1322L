using System;
using System.Collections.Generic;

namespace rsharp8_CSE1322L_Assignment2
{
    class MainClass
    {
        static void Main(string[] args)
        {
            English list = new English();
            
            Console.WriteLine("How many letters are in the word?");
            string rawLength = Console.ReadLine();
            int length = Int32.Parse(rawLength);

            Console.WriteLine("Do you want me to look for letters or a pattern?");
            Console.WriteLine("1. Letters");
            Console.WriteLine("2. Pattern");
            string rawChoice = Console.ReadLine();
            int choice = Int32.Parse(rawChoice);

            if (choice == 1)
            {
                Console.WriteLine("What letters are in the word?");
                string query = Console.ReadLine();

                Console.WriteLine("It might be any of these...");
                guessWordWithLetters(list, length, query);
            }
            else if (choice == 2)
            {
                Console.WriteLine("What pattern is in the word?");
                string pattern = Console.ReadLine();

                Console.WriteLine("It might be any of these...");
                guessWordWithPattern(list, length, pattern);
            }
        }

        public static bool wordContainsLetter(string word, char letter)
        {
            bool status = false;

            foreach (char c in word.ToCharArray())
            {
                if (letter == c){
                    status = true;
                    break;
                }
            }

            return status;
        }

        public static bool wordContainsString(string word, string query)
        {
            bool status = false;

            if (word.Contains(query))
            {
                status = true;
            }

            return status;
        }

        public static void guessWordWithLetters(English list, int len, string query)
        {
            //bool status = false;
           foreach (string entry in list.words)
            {
                if (entry.Length == len)
                {
                    char[] tempEntry = entry.ToCharArray();
                    int count = 0;

                    for (int i = 0; i < query.Length; i++)
                    {
                        for (int j = 0; j < entry.Length; j++)
                        {
                            if (query[i] == tempEntry[j])
                            {
                                tempEntry[j] = '!';
                                count++;
                                continue;
                            }
                        }
                    }
                    if (count == query.Length)
                    {
                        Console.WriteLine(entry);
                    }
                        /*if (wordContainsLetter(str, query[i]))
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                            break;
                        }
                    }
                    if (status)
                    {
                        Console.WriteLine(str);
                    }*/
                }
            }       
        }

        public static void guessWordWithPattern(English list, int len, string pattern)
        {
            foreach (string str in list.words)
            {
                if (str.Length == len && wordContainsString(str, pattern))
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
