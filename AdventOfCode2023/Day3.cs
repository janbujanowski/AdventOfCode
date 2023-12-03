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
    public class Day3 : Day66
    {
        List<char> engineSymbols = new List<char>() { '$', '*', '#', '%', '@', '=', '+', '-', '/', '&' };
        string[] lines;
        int lineLength = 0;
        bool[,] _numberConfirmed;
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            lineLength = lines.Length;
            _numberConfirmed = new bool[lineLength, lineLength];
        }

        public override object StarOne()
        {
            int sum = 0;
            for (int y = 0; y < lineLength; y++)
            {
                var line = lines[y];
                for (int x = 0; x < lineLength; x++)
                {
                    if (IsEngineSymbol(line[x]))
                    {
                        MarkAdjacentNumbers(y, x);
                    }
                }
            }

            for (int y = 0; y < lineLength; y++)
            {
                string number = string.Empty;
                for (int x = 0; x < lineLength; x++)
                {
                    if (char.IsDigit(lines[y][x]) && _numberConfirmed[y, x])
                    {
                        number += lines[y][x];
                    }
                    if (!char.IsDigit(lines[y][x]))
                    {
                        if (!string.IsNullOrEmpty(number))
                        {
                            sum += int.Parse(number);
                            number = string.Empty;
                        }
                    }
                }
            }

            return sum;
        }

        private void MarkAdjacentNumbers(int y, int x)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    var validatingX = x + i;
                    var validatingY = y + j;
                    if (CoordsInBound(validatingY, validatingX))
                    {
                        if (char.IsDigit(lines[validatingY][validatingX]))
                        {
                            MarkFullNumber(validatingY, validatingX);
                        }
                    }
                }
            }
        }

        private void MarkFullNumber(int validatingY, int validatingX)
        {
            var y = validatingY; var x = validatingX;
            string number = string.Empty;
            while (CoordsInBound(y, x) && char.IsDigit(lines[y][x]))
            {
                x--;
            }
            x++;
            while (CoordsInBound(y, x) && char.IsDigit(lines[y][x]))
            {
                _numberConfirmed[y, x] = true;
                x++;
            }
        }

        private bool CoordsInBound(int y, int x)
        {
            return x >= 0 && x < lineLength && y >= 0 && y < lineLength;
        }
        private bool IsEngineSymbol(char currentChar)
        {
            return engineSymbols.Contains(currentChar);
        }
        public override object StarTwo()
        {
            return 1;
        }
    }
}
