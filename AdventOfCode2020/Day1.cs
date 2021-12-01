using AdventOfCode.Shared;
using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day1 : IDayX
    {
        public int DayNumber()
        {
            return 1;
        }

        public object StarOne(string strInput)
        {
            string[] separators = new string[] { "\n" };
            string[] lines = strInput.Split(separators, StringSplitOptions.None);
            var numbersList = lines.Select(row => Int32.Parse(row)).ToList();
            Tuple<int, int> resultTuple = new Tuple<int, int>(0, 0);
            for (int i = 0; i < numbersList.Count; i++)
            {
                for (int j = 0; j < numbersList.Count; j++)
                {
                    if ((numbersList[i] + numbersList[j]) % 2020 == 0)
                    {
                        resultTuple = new Tuple<int, int>(numbersList[i], numbersList[j]);
                    }
                }
            }

            return resultTuple.Item1 * resultTuple.Item2;
        }

        public object StarTwo(string strInput)
        {
            string[] separators = new string[] { "\n" };
            string[] lines = strInput.Split(separators, StringSplitOptions.None);
            var numbersList = lines.Select(row => Int32.Parse(row)).ToList();
            int[] resultints = new int[3];
            for (int i = 0; i < numbersList.Count; i++)
            {
                for (int j = 0; j < numbersList.Count; j++)
                {

                    for (int k = 0; k < numbersList.Count; k++)
                    {

                        if (numbersList[i] + numbersList[j] + numbersList[k] == 2020)
                        {
                            resultints[0] = numbersList[i];
                            resultints[1] = numbersList[j];
                            resultints[2] = numbersList[k];
                        }
                    }
                }
            }

            return resultints[0] * resultints[1] * resultints[2];
        }
    }
}
