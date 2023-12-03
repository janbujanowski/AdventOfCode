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
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
        }

        public override object StarOne()
        {
            List<int> numberToSum = new List<int>();

            for (int x = 0; x < lines.Length; x++)
            {
                var line = lines[x];
                for (int y = 0; y < line[y]; y++)
                {
                    char currentChar = line[y];
                    if (IsEngineSymbol(currentChar))
                    {
                        List<int> newNumbers = CheckSurroundings(x, y);
                    }

                }
            }

            return 1;
        }

        private List<int> CheckSurroundings(int x, int y)
        {

            throw new NotImplementedException();
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
