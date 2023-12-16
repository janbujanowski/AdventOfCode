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
            List<char[]> newImage = new List<char[]>();
            while (y < _yLength)
            {
                newImage.Add(_galaxyImage[y]);
                if (!_galaxyImage[y].Contains(_galaxyMark))
                {
                    newImage.Add(_galaxyImage[y]);
                }
                y++;
            }
            _galaxyImage = newImage.ToArray();
            _yLength = newImage.Count;
            int x = 0;
            y = _yLength;
            List<List<char>> transponedImage = new List<List<char>>();
            while (x < _xLength)
            {
                bool containsGalaxy = false;
                List<char> newTransponed = new List<char>();
                for (int i = 0; i < _yLength; i++)
                {
                    newTransponed.Add(_galaxyImage[i][x]);
                    if (_galaxyImage[i][x] == _galaxyMark)
                    {
                        containsGalaxy = true;
                    }
                }
                transponedImage.Add(newTransponed);
                if (!containsGalaxy)
                {
                    transponedImage.Add(newTransponed);
                }
                x++;
            }
            _xLength = transponedImage.Count;
            _galaxyImage = new char[_yLength][];
            for (int i = 0; i < _yLength; i++)
            {
                _galaxyImage[i] = new char[_xLength];
            }
            for (int i = 0; i < _yLength; i++)
            {
                for (int j = 0; j < _xLength; j++)
                {
                    _galaxyImage[i][j] = transponedImage[j][i];
                }
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
        int GetDistance(Galaxy from, Galaxy to)
        {
            return Math.Abs(to.Y - from.Y) + Math.Abs(to.X - from.X);
        }
        public override object StarOne()
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
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
                            distances.Add(GetDistanceKey(from, to), GetDistance(galaxyFrom, galaxyTo));
                        }
                    }
                }
            }
            int sum = distances.Values.Sum();

            return sum;
        }
        public override object StarTwo()
        {
            int sum = 0;
            return sum;
        }
    }
}