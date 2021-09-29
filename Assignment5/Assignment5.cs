using System;
using static System.Console;

namespace rsharp8_CSE1322L_Assignment5
{
    class Driver
    {
        static void Main()
        {
            WriteLine("What size board do you want? (Small or Big)");
            string size = ReadLine();
            BasicGame game = new BasicGame(size);
            WriteLine(game);

            char choice = new char();
            bool move = new bool();

            do
            {
                WriteLine("Q to quit, or move by pressing:\n  8\n4   6\n  2");
                choice = Char.Parse(ReadLine());
                
                if (choice == '8') { move = game.moveUp(); }
                else if (choice == '2') { move = game.moveDown(); }
                else if (choice == '4') { move = game.moveLeft(); }
                else if (choice == '6') { move = game.moveRight(); }
                else if (choice == 'Q') { break; }
                else { WriteLine("Please try again.\n" + game); continue; }

                if (!move) { WriteLine("You can't go there!"); }

                WriteLine(game);
            } while (choice != 'Q');
        }
    }

    abstract class Board
    {
        private int rows;
        private int columns;
        char[,] theBoard;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            theBoard = new char[rows, columns];
        }

        public char getCell(int x, int y) => theBoard[x, y];

        public void setCell(int x, int y, char value) => theBoard[x, y] = value;

        public int getWidth() => theBoard.GetLength(1);

        public int getHeight() => theBoard.GetLength(0);

        public void initializeBoard(char value)
        {
            for (int i = 0; i < getHeight(); i++)
            {
                for (int j = 0; j < getWidth(); j++)
                {
                    theBoard[i, j] = value;
                }
            }
        }

        public override string ToString()
        {
            string thisBoard = String.Empty;
            string horizontalFrame = new string('-', 2 * getWidth() + 1);

            thisBoard += horizontalFrame + "\n";

            for (int i = 0; i < getHeight(); i++)
            {
                thisBoard += "|";

                for (int j = 0; j < getWidth(); j++)
                {
                    thisBoard += theBoard[i, j] + "|";
                }

                thisBoard += "\n" + horizontalFrame + "\n";
            }

            return thisBoard;
        }
    }

    class Board4x4 : Board
    {
        public Board4x4() : base(4, 4)
        {
            initializeBoard(' ');
        }
    }

    class Board8x8 : Board
    {
        public Board8x8() : base(8, 8)
        {
            initializeBoard(' ');
        }
    }

    interface IMove
    {
        public bool moveUp();
        public bool moveDown();
        public bool moveLeft();
        public bool moveRight();
    }

    class BasicGame : IMove
    {
        private int x;
        private int y;
        Board myBoard;

        public BasicGame()
        {
            myBoard = new Board4x4();
        }

        public BasicGame(string size)
        {
            if (size == "Small")
            {
                myBoard = new Board4x4();
                x = 2; y = 2;
                myBoard.setCell(y, x, 'P');
            }
            else if (size == "Big")
            {
                myBoard = new Board8x8();
                x = 4; y = 4;
                myBoard.setCell(y, x, 'P');
            }
            else { WriteLine("Error!"); }
        }

        public bool moveUp()
        {
            if (x - 1 >= 0)
            {
                myBoard.setCell(x, y, ' ');
                x--;

                myBoard.setCell(x, y, 'P');
                return true;
            }
            else { return false; }
        }

        public bool moveDown()
        {
            if (x + 1 < myBoard.getHeight())
            {
                myBoard.setCell(x, y, ' ');
                x++;

                myBoard.setCell(x, y, 'P');
                return true;
            }
            else { return false; }
        }

        public bool moveLeft()
        {
            if (y - 1 >= 0)
            {
                myBoard.setCell(x, y, ' ');
                y--;

                myBoard.setCell(x, y, 'P');
                return true;
            }
            else { return false; }
        }

        public bool moveRight()
        {
            if (y + 1 < myBoard.getWidth())
            {
                myBoard.setCell(x, y, ' ');
                y++;

                myBoard.setCell(x, y, 'P');
                return true;
            }
            else { return false; }
        }

        public override string ToString()
        {
            return myBoard.ToString();
        }
    }
}
