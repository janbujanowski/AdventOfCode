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
    public class Day11 : Day66
    {
        Dictionary<int, bool> _emptyRows = new Dictionary<int, bool>();
        Dictionary<int, bool> _emptyColumns = new Dictionary<int, bool>();
        class Galaxy
        {
            public int Id;
            public int X;
            public int Y;
        }
        class Distance
        {
            public int From;
            public int To;
            public int Value;
        }
        char _galaxyMark = '#';

        string[] _lines;
        char[][] _galaxyImage;
        int _yLength; int _xLength;
        List<Galaxy> _galaxyList;
        public override void ParseInput(string strInput)
        {
            _lines = strInput.Split("\r\n");
            _yLength = _lines.Length; _xLength = _lines.Length;
            _galaxyImage = strInput.Split("\r\n").Select(line => line.ToArray()).ToArray();
            int y = 0;
            while (y < _yLength)
            {
                if (!_galaxyImage[y].Contains(_galaxyMark))
                {
                    _emptyRows.Add(y, true);
                }
                y++;
            }
            int x = 0;

            while (x < _xLength)
            {
                bool containsGalaxy = false;
                for (int i = 0; i < _yLength; i++)
                {
                    if (_galaxyImage[i][x] == _galaxyMark)
                    {
                        containsGalaxy = true;
                    }
                }
                if (!containsGalaxy)
                {
                    _emptyColumns.Add(x, true);
                }
                x++;
            }

            int id = 1;
            _galaxyList = new List<Galaxy>();
            for (int i = 0; i < _yLength; i++)
            {
                for (int j = 0; j < _xLength; j++)
                {
                    if (_galaxyImage[i][j] == _galaxyMark)
                    {
                        _galaxyList.Add(new Galaxy() { Id = id, Y = i, X = j });
                        id++;
                    }
                }
            }
        }
        string GetDistanceKey(int from, int to)
        {
            return string.Join("-", from, to);
        }
        long GetDistance(Galaxy from, Galaxy to, int emptyGalaxyMultiplier)
        {
            long xDistance = GetDistance(from.X, to.X, emptyGalaxyMultiplier, _emptyColumns);
            long yDistance = GetDistance(from.Y, to.Y, emptyGalaxyMultiplier, _emptyRows);
            return xDistance + yDistance;
        }

        private long GetDistance(int x1, int x2, int emptyGalaxyMultiplier, Dictionary<int, bool> _emptyDictionary)
        {
            long distance = 0;
            var difference = Math.Sign(x2 - x1);
            while (x1 != x2)
            {
                x1 += difference;
                if (_emptyDictionary.ContainsKey(x1))
                {
                    distance += emptyGalaxyMultiplier;
                }
                else
                {
                    distance++;
                }

            }
            return distance;
        }

        public override object StarOne()
        {

            Dictionary<string, long> distances = GetSumOfDistances(2);
            long sum = distances.Values.Sum();
            return sum;
        }

        private Dictionary<string, long> GetSumOfDistances(int emptyGalaxyMultiplier)
        {
            Dictionary<string, long> distances = new Dictionary<string, long>();
            foreach (var galaxyFrom in _galaxyList)
            {
                foreach (var galaxyTo in _galaxyList)
                {
                    if (galaxyFrom.Id != galaxyTo.Id)
                    {
                        int from = galaxyFrom.Id < galaxyTo.Id ? galaxyFrom.Id : galaxyTo.Id;
                        int to = from == galaxyFrom.Id ? galaxyTo.Id : galaxyFrom.Id;
                        if (!distances.ContainsKey(GetDistanceKey(from, to)))
                        {
                            distances.Add(GetDistanceKey(from, to), GetDistance(galaxyFrom, galaxyTo, emptyGalaxyMultiplier));
                        }
                    }
                }
            }

            return distances;
        }

        public override object StarTwo()
        {
            Dictionary<string, long> distances = GetSumOfDistances(1000000);
            long sum = distances.Values.Sum();
            return sum;
        }
    }
}