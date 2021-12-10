using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day10 : Day66
    {
        int[] inputNumbers;
       
        public override void ParseInput(string strInput)
        {
            strInput += "\r\n0";//add output 0 voltage
            inputNumbers = strInput.Split("\n").Select(number => int.Parse(number)).ToArray();
        }
        public override object StarOne()
        {
            //2059
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

        public override object StarTwo()
        {
            
            int startingIndex = 25;

            return startingIndex;
        }
    }
}
