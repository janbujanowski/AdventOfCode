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
        string _strInput = string.Empty;
        char[][] inputArray;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput.Replace("\r\n", "");
            lines = strInput.Split("\r\n");
            inputArray = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                inputArray[i] = lines[i].ToCharArray();
            }
            lineLength = lines.Length;
        }

        public override object StarOne()
        {
            int sum = 0;
            string regex = @"\d+";
            bool isadjacent = false;
            for (int y = 0; y < lineLength; y++)
            {
                var line = lines[y];
                var matches = Regex.Matches(line.ToString(), regex);
                foreach (Match match in matches)
                {
                    isadjacent = false;
                    for (int i = 0; i < match.Length; i++)
                    {
                        int x = match.Index + i;
                        if (IsAdjacentToSymbol(y, x))
                        {
                            isadjacent = true;
                        }
                    }
                    if (isadjacent)
                    {
                        sum += int.Parse(match.Value);
                    }
                }
            }
            return sum;
        }
        private bool IsAdjacentToSymbol(int y, int x)
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
                        if (validatingX >= 0 && validatingX < lineLength && validatingY >= 0 && validatingY < lineLength)
                        {
                            var charToCheck = 'x';
                            charToCheck = inputArray[validatingY][validatingX];
                            if (IsEngineSymbol(charToCheck))
                            {
                                return true;
                            }
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
            int sum = 0;
            string regex = @"\d+";
            bool isadjacent = false;
            Dictionary<(int, int), List<int>> GearsOfWar = new Dictionary<(int, int), List<int>>();
            for (int y = 0; y < lineLength; y++)
            {
                var line = lines[y];
                var matches = Regex.Matches(line.ToString(), regex);
                foreach (Match match in matches)
                {

                    isadjacent = false;
                    (int, int) gearCoords = (-1, -1);
                    for (int i = 0; i < match.Length; i++)
                    {
                        int x = match.Index + i;
                        gearCoords = IsPartOfGear(y, x);
                        if (gearCoords.Item1 != -1 && gearCoords.Item2 != -1)
                        {
                            isadjacent = true;
                            i = 3;
                        }
                    }
                    if (isadjacent)
                    {
                        if (!GearsOfWar.ContainsKey(gearCoords))
                        {
                            GearsOfWar.Add(gearCoords, new List<int>() { int.Parse(match.Value) });
                        }
                        else
                        {
                            GearsOfWar[gearCoords].Add(int.Parse(match.Value));
                        }
                    }
                }
            }

            return GearsOfWar.Where(pair => pair.Value.Count == 2)
                             .Select(ppair => ppair.Value)
                             .Aggregate(0, (autosum, listOfValues) => autosum += listOfValues.Aggregate(1, (x, y) => x *= y));
        }
        private (int, int) IsPartOfGear(int y, int x)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        var validatingX = x + i;
                        var validatingY = y + j;
                        if (validatingX >= 0 && validatingX < lineLength && validatingY >= 0 && validatingY < lineLength)
                        {
                            var charToCheck = 'x';
                            charToCheck = inputArray[validatingY][validatingX];
                            if (charToCheck == '*')
                            {
                                return (validatingY, validatingX);
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return (-1, -1);
        }
    }
}