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
    public class Day9 : IDayX
    {
        long[] inputNumbers;

        public int DayNumber()
        {
            return 9;
        }
        public Day9(string strInput)
        {
            inputNumbers = strInput.Split("\n").Select(number => long.Parse(number)).ToArray();
        }

        

        public object StarOne(string strInput)
        {
            //1124361034
            int i = 25;
            int preambleLength = 25;
            while (CheckPreviousNSums(preambleLength, inputNumbers, i))
            {
                i++;
            };
            return inputNumbers[i];
        }
        private bool CheckPreviousNSums(int amountOfNumbers, long[] inputNumbers, int index)
        {
            int i = index - amountOfNumbers;
            var isValidSum = false;
            do
            {
                int j = index - amountOfNumbers;
                do
                {
                    if (i != j)
                    {
                        if (inputNumbers[i] + inputNumbers[j] == inputNumbers[index])
                        {
                            isValidSum = true;
                        }
                    }
                    j++;
                } while (!isValidSum && j < index);
                i++;
            } while (!isValidSum && i < index);
            return isValidSum;
        }

        public object StarTwo(string strInput)
        {

            int accumulator = 0;

            return accumulator;
        }
    }
}
