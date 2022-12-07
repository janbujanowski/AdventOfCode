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
        List<List<int>> _combinations;
        string _strInput;
        public override void ParseInput(string strInput)
        {
            this._strInput = strInput;
        }

        public override object StarOne()
        {
            var blocks = _strInput.Split('\t').Select(b=> int.Parse(b)).ToArray();
            _combinations = new List<List<int>>();

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
                foreach (var combination in _combinations)
                {
                    if (combination.SequenceEqual(nextCombination))
                    {
                        nextCycle = false;
                    }
                }
                _combinations.Add(nextCombination);
            }

            return _combinations.Count();
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
            var last = _combinations.Last();
            var firstOccurence = 0;
            for (int i = 0; i < _combinations.Count; i++)
            {
                if (_combinations.ElementAt(i).SequenceEqual(last))
                {
                    firstOccurence = i;
                    break;
                }
            }
            return _combinations.Count - 1 - firstOccurence;
        }
    }
}
