using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day1 : Day66
    {
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
            for (int i = 1; i < pings.Length; i++)
            {
                if (pings[i] > pings[i - 1])
                {
                    timesIncreased++;
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
