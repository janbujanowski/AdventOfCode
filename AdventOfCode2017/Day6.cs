using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day6 : Day66
    {
        string _strInput;
        public override void ParseInput(string strInput)
        {
            this._strInput = strInput;
        }

        public override object StarOne()
        {
            var blocks = _strInput.Split('\t').Select(b=> int.Parse(b)).ToArray();
            var combinations = new List<List<int>>();

            int indexout = blocks.Length;
            int i = 0;
            bool nextCycle = true;
            while (nextCycle)
            {
                int currMax = FindFirstMax(blocks);
                i = currMax;
                var load = blocks[i];
                blocks[i] = 0;
                i++;
                while (load > 0)
                {
                    blocks[i % indexout]++;
                    load--;
                    i++;
                }
                var nextCombination = new List<int>(blocks);
                foreach (var combination in combinations)
                {
                    if (combination.SequenceEqual(nextCombination))
                    {
                        nextCycle = false;
                    }
                }
                combinations.Add(nextCombination);
            }

            return combinations.Count();
        }

        private int FindFirstMax(int[] blocks)
        {
            var max = blocks.Max();
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == max)
                {
                    return i;
                }
            }
            return -1;
        }

        public override object StarTwo()
        {
            return "lol";
        }
    }
}
