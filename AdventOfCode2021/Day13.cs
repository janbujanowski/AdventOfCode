using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day13 : Day66
    {
        string _strInput;
        string[] _lines;
        int _flashes;
        List<Edge> _edges;
        List<Tuple<int, int>> _points;
        List<Tuple<bool, int>> _splits;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");
            _points = new List<Tuple<int, int>>();
            int linePointer = 0;
            do
            {
                string line = _lines[linePointer];
                int x = int.Parse(line.Split(',')[0]);
                int y = int.Parse(line.Split(',')[1]);
                _points.Add(new Tuple<int, int>(y, x));
                linePointer++;


            } while (!string.IsNullOrEmpty(_lines[linePointer]));
            linePointer++;
            _splits = new List<Tuple<bool, int>>();
            for (int i = linePointer; i < _lines.Length; i++)
            {
                string line = _lines[i];
                int splitPoint = int.Parse(line.Split('=')[1]);
                char direction = line.Split('=')[0].Last();
                bool isHorizontal = IsHorizontal(direction);
                _splits.Add(new Tuple<bool, int>(isHorizontal, splitPoint));
            }
        }

        private bool IsHorizontal(char direction)
        {
            return direction == 'y';
        }

        public override object StarOne()
        {
            foreach (var split in _splits)
            {
                bool isHorizontal = split.Item1;
                if (isHorizontal)
                {
                    ExecuteHorizontal(split.Item2);
                }
                else
                {
                    ExecuteVertical(split.Item2);
                }
                PrintDots();
                var count = _points.Distinct().Count();
            }
            
            return _points.Distinct().Count();
        }

        private void PrintDots()
        {
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 40; x++)
                {
                    char toPrint = '.';
                    if (_points.Any(point => point.Item1 == y && point.Item2 == x))
                    {
                        toPrint = '#';
                    }
                    Console.Write(toPrint);
                }
                Console.WriteLine();
            }
        }

        private void ExecuteHorizontal(int splitPosition)
        {
            List<int> _pointsToRemove = new List<int>();
            for (int i = 0; i < _points.Count; i++)
            {
                var point = _points.ElementAt(i);
                
                if (point.Item1 > splitPosition)
                {
                    int difference = point.Item1 - splitPosition;
                    var newpoint = Tuple.Create(splitPosition - difference, point.Item2);
                    _points.Add(newpoint);
                    _pointsToRemove.Add(i);
                }
            }
            var pontsDesc = _pointsToRemove.OrderByDescending(y=> y);
            foreach (var pointPos in pontsDesc)
            {
                _points.RemoveAt(pointPos);
            }
        }

        private void ExecuteVertical(int splitPosition)
        {
            List<int> _pointsToRemove = new List<int>();
            for (int i = 0; i < _points.Count; i++)
            {
                var point = _points.ElementAt(i);

                if (point.Item2 > splitPosition)
                {
                    int difference = point.Item2 - splitPosition;
                    var newpoint = Tuple.Create(point.Item1, splitPosition - difference);
                    _points.Add(newpoint);
                    _pointsToRemove.Add(i);
                }
            }
            var pontsDesc = _pointsToRemove.OrderByDescending(y => y);
            foreach (var pointPos in pontsDesc)
            {
                _points.RemoveAt(pointPos);
            }
        }

        public override object StarTwo()
        {
            int stepsCount = 0;
            return stepsCount;
        }
    }
}