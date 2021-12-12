using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;

namespace AdventOfCode2021
{
    public class Day11 : Day66
    {
        string _strInput;
        string[] _lines;
        int[,] dumboOctopusesMap;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");
        }
        private int[,] GenerateCleanMap()
        {
            int dimension = _lines.Length;
            int[,] map = new int[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {
                string line = _lines[y];
                for (int x = 0; x < dimension; x++)
                {
                    map[y, x] = int.Parse(line[x].ToString());
                }
            }
            return map;
        }
        int _flashes;
        public override object StarOne()
        {
            dumboOctopusesMap = GenerateCleanMap();
            int stepsCount = 3;
            _flashes = 0;
            for (int i = 0; i < stepsCount; i++)
            {
                ExecuteLifeCycle();
                ExecuteHighlighteffect();
                _flashes += CountFlashes();
                ClearFlashed();
                PrintDumbos();
            }
            return _flashes;
        }
        private void ExecuteLifeCycle()
        {
            for (int y = 0; y < dumboOctopusesMap.GetLength(0); y++)
            {
                for (int x = 0; x < dumboOctopusesMap.GetLength(1); x++)
                {
                    dumboOctopusesMap[y, x]++;
                }
            }
        }

        private void ExecuteHighlighteffect()
        {
            for (int y = 0; y < dumboOctopusesMap.GetLength(0); y++)
            {
                for (int x = 0; x < dumboOctopusesMap.GetLength(1); x++)
                {
                    if (dumboOctopusesMap[y, x] > 9)
                    {
                        BumpSurroundings(y, x);
                    }
                }
            }
        }
        private void BumpSurroundings(int Ypos, int Xpos)
        {
            int starty = Ypos;
            int startx = Xpos;
            int endy = Ypos;
            int endx = Xpos;
            if (Ypos > 0)
                starty--;
            if (Ypos < dumboOctopusesMap.GetLength(0) - 1)
                endy++;
            if (Xpos > 0)
                startx--;
            if (Xpos < dumboOctopusesMap.GetLength(1) - 1)
                endx++;
            for (int y = starty; y <= endy; y++)
            {
                for (int x = startx; x <= endx; x++)
                {
                    if (dumboOctopusesMap[y, x] < 10)
                    {
                        dumboOctopusesMap[y, x]++;
                    }
                }
            }
        }
        private void ClearFlashed()
        {
            for (int y = 0; y < dumboOctopusesMap.GetLength(0); y++)
            {
                for (int x = 0; x < dumboOctopusesMap.GetLength(1); x++)
                {
                    if (dumboOctopusesMap[y, x] > 9)
                    {
                        dumboOctopusesMap[y, x] = 0;
                    }
                }
            }
        }

        private int CountFlashes()
        {
            int sum = 0;
            foreach (var number in dumboOctopusesMap)
            {
                if (number > 9)
                {
                    sum++;
                }
            }
            return sum;
        }

        private void PrintDumbos()
        {
            for (int y = 0; y < dumboOctopusesMap.GetLength(0); y++)
            {
                for (int x = 0; x < dumboOctopusesMap.GetLength(1); x++)
                {
                    Console.Write(dumboOctopusesMap[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public override object StarTwo()
        {

            return -1;
        }
    }
}
