using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day10 : IDayX
    {
        int[] inputNumbers;

        public int DayNumber()
        {
            return 10;
        }
        public Day10(string strInput)
        {
            strInput += "\r\n0";//add output 0 voltage
            inputNumbers = strInput.Split("\n").Select(number => int.Parse(number)).ToArray();
        }

        public object StarOne(string strInput)
        {
            //1124361034
            int[] joltDifferencesCount = new int[4];
            Array.Sort(inputNumbers);
            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                var difference = inputNumbers[i + 1] - inputNumbers[i];
                joltDifferencesCount[difference]++;
            }
            joltDifferencesCount[3]++;
            
            return joltDifferencesCount[1] * joltDifferencesCount[3];
        }

        public object StarTwo(string strInput)
        {
            //129444555
            int startingIndex = 25;

            return startingIndex;
        }


    }
}
