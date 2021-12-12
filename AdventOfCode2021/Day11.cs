using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Day11 : Day66
    {
        string _strInput;
        string[] _lines;
        int[,] dumboOctopusesMap;
        int _flashes;
        Queue<string> _queue;
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
        public override object StarOne()
        {
            dumboOctopusesMap = GenerateCleanMap();
            _queue = new Queue<string>();
            int stepsCount = 100;
            _flashes = 0;
            for (int i = 0; i < stepsCount; i++)
            {
                ExecuteLifeCycle();
                ExecuteFlashEffect();
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
        private void ExecuteFlashEffect()
        {
            for (int y = 0; y < dumboOctopusesMap.GetLength(0); y++)
            {
                for (int x = 0; x < dumboOctopusesMap.GetLength(1); x++)
                {
                    if (dumboOctopusesMap[y, x] == 10)
                    {
                        _flashes++;
                        _queue.Enqueue($"{y},{x}");
                    }
                }
            }
            while (_queue.Count > 0)
            {
                string[] dumboKey = _queue.Dequeue().Split(',');
                int y = int.Parse(dumboKey[0]);
                int x = int.Parse(dumboKey[1]);
                dumboOctopusesMap[y, x] = 0;
                BumpSurroundings(y, x);
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
                    if (dumboOctopusesMap[y, x] > 0)
                    {
                        dumboOctopusesMap[y, x]++;
                    }
                    if (dumboOctopusesMap[y, x] == 10)
                    {
                        _flashes++;
                        _queue.Enqueue($"{y},{x}");
                    }
                }
            }
        }
        private bool IsSynced()
        {
            return CountZeros() == dumboOctopusesMap.Length;
        }
        private int CountZeros()
        {
            int sum = 0;
            foreach (var number in dumboOctopusesMap)
            {
                if (number == 0)
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
            dumboOctopusesMap = GenerateCleanMap();
            _queue = new Queue<string>();
            int stepsCount = 0;
            _flashes = 0;
            bool dumbosSynced = false;
            while (!dumbosSynced)
            {
                stepsCount++;
                ExecuteLifeCycle();
                ExecuteFlashEffect();
                dumbosSynced = IsSynced();
            }
            return stepsCount;
        }
    }
}