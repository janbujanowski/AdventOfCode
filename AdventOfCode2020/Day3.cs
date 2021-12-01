using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day3 : IDayX
    {
        char[,] pattern;
        int slopeHeight;
        int slopeWidth;
        public int DayNumber()
        {
            return 3;
        }
        public Day3(string strInput)
        {
            //216
            //6708199680
            string[] separators = new string[] { "\r\n" };
            string[] lines = strInput.Split(separators, StringSplitOptions.None);
            slopeHeight = lines.Length;
            slopeWidth = lines[0].Length;
            pattern = new char[slopeHeight, slopeWidth];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < slopeWidth; j++)
                {
                    pattern[i, j] = lines[i][j];
                }
            }
        }
        public object StarOne(string strInput)
        {
            //right 3 down 1
            var stepLengthX = 3;
            var stepLengthY = 1;

            int treesOnWay = CheckTreesInWay(stepLengthX, stepLengthY);
            return treesOnWay;
        }

        private int CheckTreesInWay(int stepLengthX, int stepLengthY)
        {
            int treesOnWay = 0;
            int currentX = 0;
            int currentY = 0;
            while (currentY < slopeHeight)
            {
                if (pattern[currentY, currentX] == '#')
                {
                    treesOnWay += 1;
                }
                currentX += stepLengthX;
                currentX %= slopeWidth;
                currentY += stepLengthY;
            }

            return treesOnWay;
        }

        public object StarTwo(string strInput)
        {
            int[,] stepsVariants = { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };
            List<long> treesResults = new List<long>();
            for (int i = 0; i < stepsVariants.Length / 2; i++)
            {
                treesResults.Add(CheckTreesInWay(stepsVariants[i, 0], stepsVariants[i, 1]));
            }
            return treesResults.Aggregate(1l, (a, b) => a * b);
        }
    }
}
