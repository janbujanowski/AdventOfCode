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
        List<char> engineSymbols = new List<char>() { '$', '*', '#', '%', '@', '=', '+', '-', '/', '!' };
        string[] lines;
        int maxLength = 0;
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            maxLength = lines.Length;
        }

        public override object StarOne()
        {
            List<int> numberToSum = new List<int>();
            for (int x = 0; x < lines.Length; x++)
            {
                string currentNumberString = string.Empty;
                bool isAdjacentToSymbol = false;
                for (int y = 0; y < lines.Length; y++)
                {
                    char currentChar = lines[x][y];
                    if(IsEngineSymbol(currentChar) && !string.IsNullOrEmpty(currentNumberString))
                    {
                        currentChar = '.';
                    }
                    if (char.IsNumber(currentChar))
                    {
                        currentNumberString += currentChar;
                        if (IsAdjacentToSymbol(x, y))
                        {
                            isAdjacentToSymbol = true;
                        }
                    }
                    if (currentChar == '.')
                    {
                        if (isAdjacentToSymbol && !string.IsNullOrEmpty(currentNumberString))
                        {
                            numberToSum.Add(int.Parse(currentNumberString));
                        }
                        currentNumberString = string.Empty;
                        isAdjacentToSymbol = false;
                    }
                }
            }

            return numberToSum.Sum();
        }

        private bool IsAdjacentToSymbol(int x, int y)
        {
            bool isAdjacentToSymbol = false;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        var validatingX = x + i;
                        var validatingY = y + j;
                        var charToCheck = 'x';
                        charToCheck = lines[x + i][y + j];
                        if (IsEngineSymbol(charToCheck))
                        {
                            isAdjacentToSymbol = true;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return isAdjacentToSymbol;
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
