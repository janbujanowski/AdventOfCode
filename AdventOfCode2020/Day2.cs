using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day2 : IDayX
    {
        public int DayNumber()
        {
            return 2;
        }

        public object StarOne(string strInput)
        {
            //620
            string[] separators = new string[] { "\n" };
            string[] lines = strInput.Split(separators, StringSplitOptions.None);

            int validPasswords = 0;
            foreach (var line in lines)
            {
                var variables = line.Split(' ');
                var limits = variables[0].Split('-');
                int minCountOfLetter = Int32.Parse(limits[0]);
                int maxCountOfLetter = Int32.Parse(limits[1]);
                var letter = variables[1][0];
                var password = variables[2];
                var actualCountOfLetter = password.Count(c => c == letter);
                if (minCountOfLetter <= actualCountOfLetter && actualCountOfLetter <= maxCountOfLetter)
                {
                    validPasswords++;
                }

            }

            return validPasswords;
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
