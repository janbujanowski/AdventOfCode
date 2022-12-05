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

        public Day4()
        {
        }
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Replace(',','-').Split("\r\n");
        }

        public override object StarOne()
        {
            int sum = 0;

            for (int i = 0; i < _lines.Count(); i++)
            {
                int[] lineRanges = _lines[i].Split('-').Select(rangeX => Int32.Parse(rangeX)).ToArray();
                var leftRangePositiveSize = lineRanges[1] - lineRanges[0];
                var rigtRangePositiveSize = lineRanges[3] - lineRanges[2];
                var rightRangeX2 = lineRanges[3];
                var rightRangeX1 = lineRanges[2];
                var leftRangeX2 = lineRanges[1];
                var leftRangeX1 = lineRanges[0];
                if (rigtRangePositiveSize - leftRangePositiveSize > 0)
                {
                    if(CheckRangeFullyContains(rightRangeX1, rightRangeX2, leftRangeX1, leftRangeX2))
                        sum++;
                }
                else
                {
                    if (CheckRangeFullyContains(leftRangeX1, leftRangeX2, rightRangeX1, rightRangeX2))
                        sum++;
                }
                
            }
            return sum;
        }

        private bool CheckRangeFullyContains(int outerX1, int outerX2, int innerX1, int innerX2)
        {
            return outerX1 <= innerX1 && outerX2 >= innerX2;
        }

        public override object StarTwo()
        {
            int sumNotOverlapping = 0;

            for (int i = 0; i < _lines.Count(); i++)
            {
                int[] lineRanges = _lines[i].Split('-').Select(rangeX => Int32.Parse(rangeX)).ToArray();
                var leftX1 = lineRanges[0];
                var leftX2 = lineRanges[1];
                var rightX1 = lineRanges[2];
                var rightX2 = lineRanges[3];

                if (leftX2 < rightX1 || leftX1> rightX2)
                {
                    sumNotOverlapping++;
                }
            }
            return _lines.Count() - sumNotOverlapping;
        }

        private bool CheckRangeOverlaps(int outerX1, int outerX2, int innerX1, int innerX2)
        {
            return outerX1 >= innerX2 || outerX2 >= innerX1;
        }

    }
}
