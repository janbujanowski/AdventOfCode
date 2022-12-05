using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day4 : Day66
    {
        string _strInput;
        string[] _lines;
        delegate bool CheckRangeForCondition(int outerX1, int outerX2, int innerX1, int innerX2);
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Replace(',','-').Split("\r\n");
        }

        public override object StarOne()
        {
            var sum = CheckRangesWithCondition(CheckRangeFullyContains);
            return sum;
        }
        private bool CheckRangeFullyContains(int leftX1, int leftX2, int rightX1, int rightX2)
        {
            return leftX1 <= rightX1 && leftX2 >= rightX2 ||
                   rightX1 <= leftX1 && rightX2 >= leftX2  ;
        }
        public override object StarTwo()
        {
            int sumnotoverlap = CheckRangesWithCondition(CheckRangeOverlaps);
            return _lines.Count() - sumnotoverlap;
        }
        private bool CheckRangeOverlaps(int leftX1, int leftX2, int rightX1, int rightX2)
        {
            return leftX2 < rightX1 || leftX1 > rightX2;
        }
        private int CheckRangesWithCondition(Func<int, int, int, int, bool> conditionToMeet)
        {
            int sumRangesMeetingTheCondition = 0;
            for (int i = 0; i < _lines.Count(); i++)
            {
                int[] lineRanges = _lines[i].Split('-').Select(rangeX => Int32.Parse(rangeX)).ToArray();
                var leftX1 = lineRanges[0];
                var leftX2 = lineRanges[1];
                var rightX1 = lineRanges[2];
                var rightX2 = lineRanges[3];

                if (conditionToMeet(leftX1, leftX2, rightX1, rightX2))
                {
                    sumRangesMeetingTheCondition++;
                }
            }
            return sumRangesMeetingTheCondition;
        }
    }
}
