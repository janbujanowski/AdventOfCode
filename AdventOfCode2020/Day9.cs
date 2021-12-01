using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Linq;

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
            int startingIndex = 25;
            return inputNumbers[FindIndexOfFirstInvalidSum(startingIndex)];
        }

        private int FindIndexOfFirstInvalidSum(int startingIndex)
        {
            int i = startingIndex;
            int preambleLength = startingIndex;
            while (CheckPreviousNSums(preambleLength, inputNumbers, i))
            {
                i++;
            };
            return i;
        }

        private bool CheckPreviousNSums(int preambleLength, long[] inputNumbers, int index)
        {
            int i = index - preambleLength;
            var isValidSum = false;
            do
            {
                int j = index - preambleLength;
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
            //129444555
            int startingIndex = 25;
            int invalidSumIndex = FindIndexOfFirstInvalidSum(startingIndex);
            long encryptionWeakness = FindEncryptionWeaknessValue(invalidSumIndex);
            return encryptionWeakness;
        }

        private long FindEncryptionWeaknessValue(int invalidSumIndex)
        {
            int i = -1; int j;
            long sum;
            var isValidSum = false;
            do
            {
                i++;
                sum = 0;
                j = i;
                do
                {
                    sum += inputNumbers[j];
                    if (sum == inputNumbers[invalidSumIndex])
                    {
                        isValidSum = true;
                    }
                    j++;
                } while (!isValidSum && j < invalidSumIndex && sum < inputNumbers[invalidSumIndex]);
            } while (!isValidSum && i < invalidSumIndex);

            var lol = inputNumbers.Skip(i).Take(j - i);
            return lol.Min() + lol.Max();
        }
    }
}
