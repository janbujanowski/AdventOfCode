using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day1 : IDayX
    {
        public int DayNumber()
        {
            return 1;
        }

        public object StarOne(string strInput)
        {
            string[] separators = new string[] { "\r\n" };
            var lines = strInput.Split(separators, StringSplitOptions.None).ToList();
            int sum = 0;
            foreach (var line in lines)
            {
                int value = int.Parse(line.Substring(1));
                if (line[0] == '+')
                {
                    sum += value;
                }
                else
                {
                    sum -= value;
                }
            }

            return sum;
        }

        public object StarTwo(string strInput)
        {
            string[] separators = new string[] { "\r\n" };
            var lines = strInput.Split(separators, StringSplitOptions.None).ToArray();
            List<int> freqValues = new List<int>();
            int sum = 0;
            freqValues.Add(sum);
            var i = 0;
            do
            {
                var line = lines[i];
                i++;
                int value = int.Parse(line.Substring(1));
                if (line[0] == '+')
                {
                    sum += value;
                }
                else
                {
                    sum -= value;
                }

                if (!freqValues.Contains(sum))
                {
                    freqValues.Add(sum);
                }
                else
                {
                    return sum;
                }

                i = i % lines.Length;
            } while (true);
        }
    }
}
