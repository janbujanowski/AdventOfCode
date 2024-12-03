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
        string _input;
        int[][] _reactorReport;
        int _width;
        MatchCollection _matches;
        public override void ParseInput(string input)
        {
            _input = input;
        }

        public override object StarOne()
        {
            string regex = @"mul\((?'firstNumber'\d+),(?'secondNumber'\d+)\)";
            _matches = Regex.Matches(_input, regex);
            int sum = 0;
            foreach (Match match in _matches)
            {
                sum += int.Parse(match.Groups["firstNumber"].Value) * int.Parse(match.Groups["secondNumber"].Value);
            }
            return sum;
        }

        public override object StarTwo()
        {
            string regex = @"mul\((?'firstNumber'\d+),(?'secondNumber'\d+)\)|(?'dont'don't\(\))|(?'do'do\(\))";
            _matches = Regex.Matches(_input, regex);
            int sum = 0;
            bool execute = true;
            foreach (Match match in _matches)
            {
                switch (match.Value)
                {
                    case "don't()":
                        execute = false;
                        break;
                    case "do()":
                        execute = true;
                        break;
                    default:
                        if (execute)
                        {
                            sum += int.Parse(match.Groups["firstNumber"].Value) * int.Parse(match.Groups["secondNumber"].Value);
                        }
                        break;
                }
            }
            return sum;
        }
    }
}
