using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public class Day4 : Day66
    {
        string _input;
        int _sizeY;
        int _sizeX;
        char[][] _plane;
        char X = 'X'; char M = 'M'; char A = 'A'; char S = 'S';
        char[] _targetLetter;
        int _targetSum;
        List<Point> _modifiers = new List<Point>()
        {
            new Point(1, 0),
            new Point(-1, 0),
            new Point(0, 1),
            new Point(0, -1),
            new Point(1, 1),
            new Point(-1, -1),
            new Point(1, -1),
            new Point(-1, 1)
        };
        public override void ParseInput(string input)
        {
            _input = input;
            _sizeY = input.Split("\r\n")[0].Length;
            _sizeX = input.Split("\r\n")[0].Length;
            _targetLetter = new char[] { X, M, A, S };
            _targetSum = M + A + S;
            _plane = input.Split("\r\n").Select(x => x.ToCharArray()).ToArray();
        }

        public override object StarOne()
        {
            int sum = 0;
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    if (_plane[y][x] == X)
                    {
                        sum += XMASCount(y, x);
                    }
                }
            }

            return sum;
        }

        private int XMASCount(int y, int x)
        {
            int xmasCount = 0;
            foreach (var modifier in _modifiers)
            {
                bool safeIndex = true;
                bool valid = true;
                for (int i = 1; i < 4; i++)
                {
                    int newY = y + modifier.Y * i;
                    int newX = x + modifier.X * i;
                    if (!IsInMap(newY, newX, _sizeY, _sizeX))
                    {
                        valid = false;
                        break;
                    }
                    if (_plane[y + modifier.Y * i][x + modifier.X * i] != _targetLetter[i])
                    {
                        valid = false;
                    }
                }
                if (valid)
                {
                    xmasCount++;
                }
            }
            return xmasCount;
        }
        private bool IsInMap(int newY, int newX, int arrayY, int arrayX)
        {
            return newY >= 0 && newX >= 0 && newX < arrayX && newY < arrayY;
        }

        public override object StarTwo()
        {
            int sum = 0;

            return sum;
        }
    }
}
