using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day3
    {
        static int input = 312051;
        static int[,] square;
        const int squareSize = 561;
        private static int Init()
        {
            square = new int[squareSize, squareSize];
            int X = squareSize / 2;
            int Y = squareSize / 2;
            int it = 1;
            square[X, Y] = it;
            it++;
            X++;

            while (it < input)
            {
                do
                {
                    square[X, Y] = it;
                    it++;
                    Y--;
                } while (square[X - 1, Y] != 0);
                do
                {
                    square[X, Y] = it;
                    X--;
                    it++;

                } while (square[X,Y+1] != 0);
                do
                {
                    square[X, Y] = it;
                    Y++;
                    it++;
                } while (square[X +1,Y] != 0);
                do
                {
                    square[X, Y] = it;
                    X++;
                    it++;
                } while (square[X , Y-1] != 0);
            }
            
            
            return 1;
        }
        public static int StarOne()
        {
            Init();
            int X1 = squareSize / 2;
            int Y1 = squareSize / 2;
            int X2 = -1;
            int Y2 = -1;

            for (int i = 0; i < squareSize; i++)
            {
                for (int j = 0; j < squareSize; j++)
                {
                    if (square[j,i] == input)
                    {
                        X2 = j;
                        Y2 = i;
                    }
                }
            }
            int steps = 0;
            while (X1 < X2 || Y1 < Y2)
            {
                if (X1 < X2)
                {
                    steps++;
                    X1++;
                }
                if (X1 > X2)
                {
                    X1--;
                    steps++;
                }
                if (Y1 < Y2)
                {
                    steps++;
                    Y1++;
                }
                //Console.WriteLine("X1 = " + X1 + " ,Y1 = " + Y1); //for debuging
            }
            return steps;
        }
    }
}
