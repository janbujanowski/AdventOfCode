using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2024
{
    public class Day2 : Day66
    {
        string[] _lines;
        int[][] _reactorReport;
        int _width;

        public override void ParseInput(string input)
        {
            _lines = input.Split("\r\n");
            _width = _lines[0].Split(" ").Length;
            _reactorReport = _lines.Select(line => line.Split(" ").Select(x => int.Parse(x)).ToArray()).ToArray();
        }

        public override object StarOne()
        {
            int safeReports = 0;
            for (int i = 0; i < _lines.Length; i++)
            {
                safeReports++;
                int oldSign = Math.Sign(_reactorReport[i][0] - _reactorReport[i][1]);
                for (int j = 1; j < _reactorReport[i].Length; j++)
                {
                    int difference = _reactorReport[i][j-1] - _reactorReport[i][j];
                    if (Math.Abs(difference) > 3 || difference == 0 || Math.Sign(difference) != oldSign)
                    {
                        safeReports--;
                        break;
                    }
                }
            }
            return safeReports;
        }

        public override object StarTwo()
        {
            int similarityScore = 0;
            return similarityScore;
        }
    }
}
