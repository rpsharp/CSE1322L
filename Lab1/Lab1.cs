using System;

namespace CSE1322Lab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Print Forward Array
            char[,] outputArray = new char[4, 13];
            outputArray = make_forward();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Console.Write(outputArray[i, j]);
                }
                Console.Write("\n");
            }
            //Print Mirror Array
            char[,] mirrorArray = new char[4, 13];
            mirrorArray = make_mirror(make_forward());
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Console.Write(mirrorArray[i, j]);
                }
                Console.Write("\n");
            }

            //Print Head-On Collision
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Console.Write(outputArray[i, j]);
                }
                for (int k = 0; k < 13; k++)
                {
                    Console.Write(mirrorArray[i, k]);
                }
                Console.Write("\n");
            }
        }
        //Provided Method
        public static char[,] make_forward()
        {
            char[,] pixel = new char[4, 13];
            pixel[0, 0] = ' ';
            pixel[0, 1] = ' ';
            pixel[0, 2] = '_';
            pixel[0, 3] = '_';
            pixel[0, 4] = '_';
            pixel[0, 5] = '_';
            pixel[0, 6] = '_';
            pixel[0, 7] = '_';
            pixel[0, 8] = ' ';
            pixel[0, 9] = ' ';
            pixel[0, 10] = ' ';
            pixel[0, 11] = ' ';
            pixel[0, 12] = ' ';
            pixel[1, 0] = ' ';
            pixel[1, 1] = '/';
            pixel[1, 2] = '|';
            pixel[1, 3] = '_';
            pixel[1, 4] = '|';
            pixel[1, 5] = '|';
            pixel[1, 6] = '_';
            pixel[1, 7] = '\\';
            pixel[1, 8] = '\'';
            pixel[1, 9] = '.';
            pixel[1, 10] = '_';
            pixel[1, 11] = '_';
            pixel[1, 12] = ' ';
            pixel[2, 0] = '(';
            pixel[2, 1] = ' ';
            pixel[2, 2] = ' ';
            pixel[2, 3] = ' ';
            pixel[2, 4] = '_';
            pixel[2, 5] = ' ';
            pixel[2, 6] = ' ';
            pixel[2, 7] = ' ';
            pixel[2, 8] = ' ';
            pixel[2, 9] = '_';
            pixel[2, 10] = ' ';
            pixel[2, 11] = '_';
            pixel[2, 12] = '\\';
            pixel[3, 0] = '=';
            pixel[3, 1] = '\'';
            pixel[3, 2] = '-';
            pixel[3, 3] = '(';
            pixel[3, 4] = '_';
            pixel[3, 5] = ')';
            pixel[3, 6] = '-';
            pixel[3, 7] = '-';
            pixel[3, 8] = '(';
            pixel[3, 9] = '_';
            pixel[3, 10] = ')';
            pixel[3, 11] = '-';
            pixel[3, 12] = '\'';
            return pixel;
        }
        //Mirror Method
        public static char[,] make_mirror(char[,] arr)
        {
            char[,] mirror = arr;
            for (int i = 0; i < 4; i++)
            {
                int startElement = 0; 
                int endElement = 12; 

                while (startElement < endElement)
                {
                    //Flip startElement
                    if (mirror[i, startElement] == '('){
                        mirror[i, startElement] = ')';
                    }
                    else if (mirror[i, startElement] == ')'){
                        mirror[i, startElement] = '(';
                    }
                    else if (mirror[i, startElement] == '/'){
                        mirror[i, startElement] = '\\';
                    }
                    else if (mirror[i, startElement] == '\\'){
                        mirror[i, startElement] = '/';
                    }

                    //Flip and store new value for endElement
                    char temp = mirror[i, endElement];
                    if (temp == '('){
                        temp = ')';
                    } else if (temp == ')'){
                        temp = '(';
                    } else if (temp == '/'){
                        temp = '\\';
                    } else if (temp == '\\'){
                        temp = '/';
                    }

                    mirror[i, endElement] = mirror[i, startElement];
                    mirror[i, startElement] = temp;
                    startElement++;
                    endElement--;
                }
            }
            return mirror;
        }
    }
}
