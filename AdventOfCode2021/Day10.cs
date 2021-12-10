using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
  
    public class Day10 : Day66
    {
        string _strInput;
        int[,] _heatMap;
        int _verticalLength;
        int _horizontalLength;
        List<Tuple<int, int>> _ventsPositions;
        List<List<Tuple<int, int>>> _basins;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;

            string[] lines = _strInput.Split("\r\n");
            _verticalLength = lines.Length;
            _horizontalLength = lines[0].Length;
            _heatMap = new int[_verticalLength, _horizontalLength];

            for (int i = 0; i < _verticalLength; i++)
            {
                for (int j = 0; j < _horizontalLength; j++)
                {
                    _heatMap[i, j] = int.Parse(lines[i][j].ToString());
                }
            }
        }

        public override object StarOne()
        {
            _ventsPositions = new List<Tuple<int, int>>();
            for (int i = 0; i < _verticalLength; i++)
            {
                for (int j = 0; j < _horizontalLength; j++)
                {
                    if (IsLocalMinimum(i, j))
                    {
                        _ventsPositions.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            int result = GetRisk();
            return result;
        }

        private bool IsLocalMinimum(int i, int j)
        {
            bool isIt = false;
            int left = 10; int right = 10; int top = 10; int bott = 10;
            if (j > 0)
            {
                left = _heatMap[i, j - 1];
            }
            if (i > 0)
            {
                top = _heatMap[i - 1, j];
            }
            if (i < _verticalLength - 1)
            {
                bott = _heatMap[i + 1, j];
            }
            if (j < _horizontalLength - 1)
            {
                right = _heatMap[i, j + 1];
            }
            List<int> toCHeck = new List<int>() { left, right, top, bott };
            if (_heatMap[i, j] < toCHeck.Min())
            {
                isIt = true;
            }

            return isIt;
        }
        private int GetRisk()
        {
            int sum = 0;
            foreach (var item in _ventsPositions)
            {
                sum += 1 + _heatMap[item.Item1, item.Item2];
            }
            return sum;
        }

        public override object StarTwo()
        {
            this.StarOne();
            _basins = new List<List<Tuple<int, int>>>();
            //todo check if was initialzed
            foreach (var vent in _ventsPositions)
            {
                List<Tuple<int, int>> basinPositions = new List<Tuple<int, int>>();
                _basins.Add(GenerateBasinPositions(vent, basinPositions));
            }
            var biggestBassins = _basins.OrderByDescending(list => list.Count).Take(3);
            //foreach (var bassin in _basins)
            //{
            //    PrintBasiN(bassin);
            //}
            //mult
            int multsum = 1;
            
            foreach (var item in biggestBassins)
            {
                multsum *= item.Distinct().ToList().Count;
            }
            return multsum;
        }

        private void PrintBasiN(List<Tuple<int, int>> bassin)
        {
            for (int i = 0; i < _verticalLength; i++)
            {
                for (int j = 0; j < _horizontalLength; j++)
                {
                    if (AlreadyContainsTuple(bassin,i,j))
                    {
                        Console.Write(_heatMap[i, j]);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private List<Tuple<int, int>> GenerateBasinPositions(Tuple<int, int> currentCenter, List<Tuple<int, int>> basinPositions)
        {
            basinPositions.Add(currentCenter);
            int i = currentCenter.Item1; int j = currentCenter.Item2;

            List<Tuple<int, int>> currentNeighbours = new List<Tuple<int, int>>();
            if (j > 0 && !AlreadyContainsTuple(basinPositions,i,j-1))
            {
                currentNeighbours.Add(new Tuple<int, int>(i, j - 1));
            }
            if (i > 0 && !AlreadyContainsTuple(basinPositions, i - 1, j))
            {
                currentNeighbours.Add(new Tuple<int, int>(i - 1, j));
            }
            if (i < _verticalLength - 1 && !AlreadyContainsTuple(basinPositions, i + 1, j))
            {
                currentNeighbours.Add(new Tuple<int, int>(i + 1, j));
            }
            if (j < _horizontalLength - 1 && !AlreadyContainsTuple(basinPositions, i, j + 1))
            {
                currentNeighbours.Add(new Tuple<int, int>(i, j + 1));
            }

            foreach (var neighbour in currentNeighbours)
            {
                if (_heatMap[neighbour.Item1, neighbour.Item2] < 9)
                {
                    GenerateBasinPositions(neighbour,basinPositions);
                }
            }

            return basinPositions;
        }
        private bool AlreadyContainsTuple(List<Tuple<int, int>> list, int i, int j)
        {
            return list.Any(tupl => tupl.Item1 == i && tupl.Item2 == j);
        }
    }
}
