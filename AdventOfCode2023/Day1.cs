using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
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

                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        sum += 10 * Int32.Parse(line[i].ToString());
                        i = line.Length;
                    }
                }
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        sum += Int32.Parse(line[i].ToString());
                        i = 0;
                    }
                }
            }
            return sum;
        }
        private int IsSpelledDigitForward(string line, int i)
        {
            if (i >= 0)
            {
                string word = String.Empty;
                if (i < line.Length - 2)
                    word = string.Join("", line[i], line[i + 1], line[i + 2]);
                if (i < line.Length - 4)
                    word = string.Join("", line[i], line[i + 1], line[i + 2], line[i + 3], line[i + 4]);
                foreach (var digit in spelledDigitsPairs)
                {
                    if (word.Contains(digit.Key))
                    {
                        return digit.Value;
                    }
                }
            }
            return 0;
        }
        private int IsSpelledDigitBackward(string line, int i)
        {
            if (i >= 0)
            {
                string word = String.Empty;
                if (i >= 2)
                    word = string.Join("", line[i - 2], line[i - 1], line[i]);
                if (i >= 4)
                    word = string.Join("", line[i - 4], line[i - 3], line[i - 2], line[i - 1], line[i]);
                foreach (var digit in spelledDigitsPairs)
                {
                    if (word.Contains(digit.Key))
                    {
                        return digit.Value;
                    }
                }
            }
            return 0;
        }

        public override object StarTwo()
        {
            int sum = 0;

            foreach (var line in lines)
            {
                int calibrationNumber = GetCalibrationNumber(line);

                sum += calibrationNumber;

            }
            return sum;
        }

        public int GetCalibrationNumber(string line)
        {
            int firstDigit = 0;
            int i = line.Length - 1;
            int calibrationNumber = 0;
            while (i >= 0)
            {
                var digitCheck = IsSpelledDigitBackward(line, i);
                if (digitCheck > 0)
                {
                    firstDigit = digitCheck;
                }
                if (char.IsDigit(line[i]))
                {
                    firstDigit = Int32.Parse(line[i].ToString());
                }
                i--;
            }
            calibrationNumber += 10 * firstDigit;
            var lastDigit = 0;
            i = 0;
            while (i < line.Length)
            {
                if (char.IsDigit(line[i]))
                {
                    lastDigit = Int32.Parse(line[i].ToString());

                }
                var digitCheck = IsSpelledDigitForward(line, i);
                if (digitCheck > 0)
                {
                    lastDigit = digitCheck;
                }
                i++;
            }
            calibrationNumber += lastDigit;
            return calibrationNumber;
        }
    }
}
