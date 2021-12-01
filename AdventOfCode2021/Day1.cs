using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day1 : Day66
    {
        int defaultArrayValue = 0;
        int increaseEnumValue = 1;
        string[] lines;
        int[] pings;
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            pings = lines.Select(line => int.Parse(line)).ToArray();
        }

        public override object StarOne()
        {
            int timesIncreased = 0;
            //int[] increaseDecreaseEvaluate = new int[pings.Length];
            //increaseDecreaseEvaluate[0] = defaultArrayValue;
            for (int i = 1; i < pings.Length; i++)
            {
                if (pings[i] > pings[i - 1])
                {
                    timesIncreased++;
                    //increaseDecreaseEvaluate[i] = increaseEnumValue;
                }
            }
            return timesIncreased;
        }
        public override object StarTwo()
        {
            int timesIncreased = 0;
            for (int i = 3; i < pings.Length; i++)
            {
                int sumA = pings[i] + pings[i - 1] + pings[i - 2];
                int sumB = pings[i - 3] + pings[i - 1] + pings[i - 2];
                if (sumA > sumB)
                {
                    timesIncreased++;
                }
            }
            return timesIncreased;
        }
    }
}
