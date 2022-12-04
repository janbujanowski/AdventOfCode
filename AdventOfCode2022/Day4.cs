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
        string[] lines;
        Dictionary<char, int> _charsPriority = new Dictionary<char, int>() {
          
        };
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            
        }

        public override object StarOne()
        {
            var left = lines.Select(line => new Tuple<int, int>(int.Parse(line.Split(',')[0].Split('-')[0]), int.Parse(line.Split(',')[0].Split('-')[1])));
            var right = lines.Select(line => new Tuple<int, int>(int.Parse(line.Split(',')[1].Split('-')[0]), int.Parse(line.Split(',')[1].Split('-')[1])));
            int sum = 0;

            for (int i = 0; i < left.Count(); i++)
            {
                var leftRangePositive = left.ElementAt(i).Item2 - left.ElementAt(i).Item1;
                var rigtRangePositive = right.ElementAt(i).Item2 - right.ElementAt(i).Item1;
                if (rigtRangePositive - leftRangePositive > 0)
                {
                    if(CheckRangeFullyContains(right.ElementAt(i).Item1, right.ElementAt(i).Item2, left.ElementAt(i).Item1, left.ElementAt(i).Item2))
                        sum++;
                }
                else
                {
                    if (CheckRangeFullyContains(left.ElementAt(i).Item1, left.ElementAt(i).Item2, right.ElementAt(i).Item1, right.ElementAt(i).Item2))
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
            var left = lines.Select(line => new Tuple<int, int>(int.Parse(line.Split(',')[0].Split('-')[0]), int.Parse(line.Split(',')[0].Split('-')[1])));
            var right = lines.Select(line => new Tuple<int, int>(int.Parse(line.Split(',')[1].Split('-')[0]), int.Parse(line.Split(',')[1].Split('-')[1])));
            int sumNotOverlapping = 0;

            for (int i = 0; i < left.Count(); i++)
            {
                var leftX1 = left.ElementAt(i).Item1;
                var leftX2 = left.ElementAt(i).Item2;
                var rightX1 = right.ElementAt(i).Item1;
                var rightX2 = right.ElementAt(i).Item2;

                if (leftX2 < rightX1 || leftX1> rightX2)
                {
                    sumNotOverlapping++;
                }
            }
            return left.Count() - sumNotOverlapping;
        }

        private bool CheckRangeOverlaps(int outerX1, int outerX2, int innerX1, int innerX2)
        {
            return outerX1 >= innerX2 || outerX2 >= innerX1;
        }

    }
}
