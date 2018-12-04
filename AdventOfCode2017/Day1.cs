using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;

namespace AdventOfCode2017
{
    public class Day1 : IDayX
    {
        public int DayNumber()
        {
            return 1;
        }

        public object StarOne(string input)
        {
            input += input[0];
            int current = -1;
            var loopArr = input.ToArray();
            int sum = 0;
            for (int i = 0; i < loopArr.Length - 1; i++)
            {
                if (loopArr[i] == loopArr[i + 1])
                {
                    sum += loopArr[i] - 48;
                }
            }

            return sum;
        }
        public object StarTwo(string input)
        {
            //input += input[0];
            int step = input.Length / 2;
            for (int i = 0; i < step; i++)
            {
                input += input[i];
            }

            int current = -1;
            var loopArr = input.ToArray();

            int sum = 0;
            for (int i = 0; i < loopArr.Length - step; i++)
            {
                if (loopArr[i] == loopArr[i + step])
                {
                    sum += loopArr[i] - 48;
                }
            }

            return sum;
        }
    }
}
