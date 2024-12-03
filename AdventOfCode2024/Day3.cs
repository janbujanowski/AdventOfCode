using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public class Day3 : Day66
    {
        string[] _lines;
        int[][] _reactorReport;
        int _width;
        MatchCollection _matches;
        public override void ParseInput(string input)
        {
            string regex = @"mul\((?'firstNumber'\d+),(?'secondNumber'\d+)\)";
            _matches = Regex.Matches(input, regex);
            
            //_lines = input.Split("\r\n");
            //_width = _lines[0].Split(" ").Length;
            //_reactorReport = _lines.Select(line => line.Split(" ").Select(x => int.Parse(x)).ToArray()).ToArray();
        }

        public override object StarOne()
        {
            int sum = 0;
            foreach (Match match in _matches)
            {
                sum += int.Parse(match.Groups["firstNumber"].Value) * int.Parse(match.Groups["secondNumber"].Value);
            }
            return sum;
        }

        public override object StarTwo()
        {
           
            return 1;
        }

        private int[] SkipElement(int[] array, int index)
        {
            return array.Take(index).Concat(array.Skip(index + 1)).ToArray();
        }
    }
}
