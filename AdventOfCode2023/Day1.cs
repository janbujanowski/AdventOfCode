using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day1 : Day66
    {
        string[] lines;
        int[] pings;
        List<int> sums;
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            //pings = lines.Select(line => int.Parse(line)).ToArray();
        }

        public override object StarOne()
        {
            sums = new List<int>();
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                int value = 0;
                if (int.TryParse(lines[i], out value))
                {
                    sum += value;
                }
                else
                {
                    sums.Add(sum);
                    sum = 0;
                };

            }
            return sums.Max();
        }
        public override object StarTwo()
        {
            var sorted = sums.OrderByDescending(x => x);

            return sorted.ElementAt(0) + sorted.ElementAt(1) + sorted.ElementAt(2);

        }
    }
}
