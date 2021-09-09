using System;
using System.Collections.Generic;

namespace rsharp8_CSE1322L_Lab3
{
    class Driver
    {
        static void Main(string[] args)
        {
            Quiz my_quiz = new Quiz();
            int choice;

            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a question to the quiz");
                Console.WriteLine("2. Remove a question from the quiz");
                Console.WriteLine("3. Modify a question in the quiz");
                Console.WriteLine("4. Take the quiz");
                Console.WriteLine("5. Quit");

                string rawInput = Console.ReadLine();
                choice = Int32.Parse(rawInput);

                if (choice == 1)
                {
                    my_quiz.add_question();
                }
                else if (choice == 2)
                {
                    my_quiz.remove_question();
                }
                else if (choice == 3)
                {
                    my_quiz.modify_question();
                }
                else if (choice == 4)
                {
                    my_quiz.give_quiz();
                }

            } while (choice != 5);
        }
    }

    class Question
    {
        private string text;
        private string answer;
        private int diff;

        //Constructor
        public Question(string text, string answer, int diff)
        {
            this.text = text;
            this.answer = answer;
            this.diff = diff;
        }

        //Getters
        public string getQuestionText()
        {
            return text;
        }

        public string getQuestionAnswer()
        {
            return answer;
        }

        public int getQuestionDifficulty()
        {
            return diff;
        }

        //Setters
        public void setQuestionText(string text)
        {
            this.text = text;
        }

        public void setQuestionAnswer(string answer)
        {
            this.answer = answer;
        }

        public void setQuestionDifficulty(int diff)
        {
            this.diff = diff;
        }
    }

    class Quiz
    {
        private List<Question> quiz = new List<Question>();

        public void add_question()
        {
            Console.WriteLine("What is the Question Text?");
            string text = Console.ReadLine();
            Console.WriteLine("What is the Answer?");
            string answer = Console.ReadLine();
            Console.WriteLine("How Difficult (1-3)?");
            string rawDiff = Console.ReadLine();
            int diff = Int32.Parse(rawDiff);

            Question q = new Question(text, answer, diff);
            quiz.Add(q);
        }

        public void remove_question()
        {
            Console.WriteLine("Choose the question to remove:");

            for (int i = 0; i < quiz.Count; i++)
            {
                Console.WriteLine(i + ". " + quiz[i].getQuestionText());
            }
            string rawInput = Console.ReadLine();
            int choice = Int32.Parse(rawInput);
            

            quiz.Remove(quiz[choice]);
        }

        public void modify_question()
        {
            Console.WriteLine("Choose the question to modify:");

            for (int i = 0; i < quiz.Count; i++)
            {
                Console.WriteLine(i + ". " + quiz[i].getQuestionText());
            }
            string rawInput = Console.ReadLine();
            int choice = Int32.Parse(rawInput);

            Console.WriteLine("What is the Question Text?");
            string text = Console.ReadLine();
            Console.WriteLine("What is the Answer?");
            string answer = Console.ReadLine();
            Console.WriteLine("How Difficult (1-3)?");
            string rawDiff = Console.ReadLine();
            int diff = Int32.Parse(rawDiff);

            quiz[choice].setQuestionText(text);
            quiz[choice].setQuestionAnswer(answer);
            quiz[choice].setQuestionDifficulty(diff);
        }

        public void give_quiz()
        {
            int score = 0;

            foreach (Question q in quiz)
            {
                Console.WriteLine(q.getQuestionText());
                string response = Console.ReadLine();
                if (response.Equals(q.getQuestionAnswer()))
                {
                    Console.WriteLine("Correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
            }

            Console.WriteLine("You got " + score + " out of " + quiz.Count);
        }
    } 
}