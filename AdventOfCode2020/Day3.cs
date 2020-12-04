using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day3 : IDayX
    {
        public int DayNumber()
        {
            return 3;
        }

        public object StarOne(string strInput)
        {
            //right 3 down 1
            var stepLengthX = 3;
            var stepLengthY = 1;
            string[] separators = new string[] { "\r\n" };
            string[] lines = strInput.Split(separators, StringSplitOptions.None);
            var slopeHeight = lines.Length;
            var slopeWidth = lines[0].Length;
            char[,] pattern = new char[slopeHeight, slopeWidth];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < slopeWidth; j++)
                {
                    pattern[i, j] = lines[i][j];
                }
            }

            int treesOnWay = 0;
            int currentX = 0;
            int currentY = 0;
            while (currentY < slopeHeight)
            {
                if (pattern[currentY,currentX] == '#')
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
            string[] separators = new string[] { "\n" };
            string[] lines = strInput.Split(separators, StringSplitOptions.None);

            int validPasswords = 0;
            foreach (var line in lines)
            {
                var variables = line.Split(' ');
                var positions = variables[0].Split('-');
                int positionA = Int32.Parse(positions[0]);
                int positionB = Int32.Parse(positions[1]);
                var letter = variables[1][0];
                var password = variables[2];
                var letterAtPositionA = password[positionA - 1];
                var letterAtPositionB = password[positionB - 1];
                if (letterAtPositionA == letter ^ letterAtPositionB == letter)
                {
                    validPasswords++;
                }

            }

            return validPasswords;
        }
    }
}
