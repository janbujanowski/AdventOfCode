using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day1 : Day66
    {
        string[] lines;
        Dictionary<string, int> spelledDigitsPairs = new Dictionary<string, int>() {
            { "one" , 1 },
            { "two" , 2 },
            { "three" , 3 },
            { "four" , 4 },
            { "five" , 5 },
            { "six" , 6 },
            { "seven" , 7 },
            { "eight" , 8 },
            { "nine" , 9 }
        };
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
        }

        public override object StarOne()
        {
            int sum = 0;
            foreach (var line in lines)
            {
                sum += GetCalibrationNumberStarOne(line);
            }
            return sum;
        }
        private int GetCalibrationNumberStarOne(string line)
        {
            int calibration = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    calibration += 10 * Int32.Parse(line[i].ToString());
                    i = line.Length;
                }
            }
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    calibration += Int32.Parse(line[i].ToString());
                    i = 0;
                }
            }
            return calibration;
        }

        public override object StarTwo()
        {
           
            int sum = 0;

            foreach (var line in lines)
            {
                sum += GetCalibrationNumber(line);

            }
            return sum;
        }

        public int GetCalibrationNumber(string line)
        {
            string regex = @"\d|one|two|three|four|five|six|seven|eight|nine";
            var firstRegex = Regex.Match(line, regex);
            var lastRegex = Regex.Match(line, regex, RegexOptions.RightToLeft);

            var firstDigit = 0;
            var lastDigit = 0;
            if (firstRegex.Length == 1)
            {
                firstDigit = int.Parse(firstRegex.Value);
            }
            else
            {
                firstDigit = spelledDigitsPairs[firstRegex.Value];
            }
            if (lastRegex.Length == 1)
            {
                lastDigit = int.Parse(lastRegex.Value);
            }
            else
            {
                lastDigit = spelledDigitsPairs[lastRegex.Value];
            }


            ;
            return firstDigit * 10 + lastDigit;
        }
    }
}
