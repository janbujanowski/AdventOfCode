using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2024
{
    public class Day1 : Day66
    {
        string[] _lines;
        int[] _leftNumbers;
        int[] _rightNumbers;
        public override void ParseInput(string input)
        {
            _lines = input.Split("\r\n");
            _leftNumbers = _lines.Select(line => int.Parse(line.Split(" ")[0])).OrderBy(x => x).ToArray();
            _rightNumbers = _lines.Select(line => int.Parse(line.Split(" ")[3])).OrderBy(x => x).ToArray();
        }

        public override object StarOne()
        {
            //229169 too low
            //30329945 to high
            int sumDistance = 0;
            for (int i = 0; i < _leftNumbers.Length; i++)
            {
                sumDistance += Math.Abs(_rightNumbers[i] - _leftNumbers[i]);
            }
            return Math.Abs(sumDistance);
        }

        public override object StarTwo()
        {
            Dictionary<int, int> rightCounts = new Dictionary<int, int>();
            foreach (var rightNumber in _rightNumbers)
            {
                if (rightCounts.ContainsKey(rightNumber))
                {
                    rightCounts[rightNumber]++;
                }
                else
                {
                    rightCounts[rightNumber] = 1;
                }
            }
            int similarityScore = 0;
            foreach ( var rightNumber in rightCounts)
            {
                if(_leftNumbers.Contains(rightNumber.Key))
                {
                    similarityScore += rightNumber.Value * rightNumber.Key;
                }
            }
            return similarityScore;
        }
    }
}
