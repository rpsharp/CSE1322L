using System;
using System.Collections.Generic;
using static System.Console;

namespace rsharp8_CSE1322L_Lab5
{
    class Driver
    {
        static void Main()
        {
            List<Item> myCollection = new List<Item>();

            for (int i = 0; i < 5; i++)
            {
                WriteLine("Please enter B for Book or P for Periodical");
                string type = ReadLine();

                if (type == "B" || type == "b")
                {
                    WriteLine("Please enter the name of the Book");
                    string title = ReadLine();

                    WriteLine("Please enter the author of the Book");
                    string author = ReadLine();

                    WriteLine("Please enter the ISBN of the Book");
                    int isbn_number = Int32.Parse(ReadLine());

                    myCollection.Add(new Book(title, isbn_number, author));
                }
                else if (type == "P" || type == "p")
                {
                    WriteLine("Please enter the name of the Periodical");
                    string title = ReadLine();

                    WriteLine("Please enter the issue number of the Periodical");
                    int issueNum = Int32.Parse(ReadLine());

                    myCollection.Add(new Periodical(title, issueNum));
                }
                else { WriteLine("Invalid Entry!"); i--; }
            }

            WriteLine("\nYour Items:");

            foreach (Item entry in myCollection)
            {
                WriteLine(entry.getListing());
            }
        }
    }

    abstract class Item
    {
        private string title;

        public void setTitle(string title) => this.title = title;
        public string getTitle => this.title;

        public abstract string getListing();

        public Item()
        {
            title = String.Empty;
        }

        public Item(string title)
        {
            this.title = title;
        }

        public override string ToString()
        {
            return title;
        }
    }

    class Book : Item
    {
        private int isbn_number;
        private string author;

        public void setISBN(int isbn_number) => this.isbn_number = isbn_number;
        public int getISBN => isbn_number;

        public void setAuthor(string author) => this.author = author;
        public string getAuthor => author;

        public Book()
        {
            isbn_number = 0;
            author = String.Empty;
        }

        public Book(string title, int isbn_number, string author)
        {
            setTitle(title);
            setISBN(isbn_number);
            setAuthor(author);
        }

        public override string getListing()
        {
            return $"Book Name - {getTitle}\nAuthor - {author}\nISBN # - {isbn_number}\n";
        }
    }

    class Periodical : Item
    {
        private int issueNum;

        public void setIssueNum(int issueNum) => this.issueNum = issueNum;
        public int getIssueNum => issueNum;

        public Periodical()
        {
            issueNum = 0;
        }

        public Periodical(string title, int issueNum)
        {
            setTitle(title);
            setIssueNum(issueNum);
        }

        public override string getListing()
        {
            return $"Periodical Title - {getTitle}\nIssue # - {issueNum}\n";
        }
    }
}
