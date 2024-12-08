using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdventOfCode2024
{
    public class Day6 : Day66
    {
        string _input;
        int _size;
        char[][] _plane;
        char guard = '^'; char Obstacle = '#'; char X = 'X';
        char[] _targetLetter;
        List<Point> _moves = new List<Point>()
        {
            new Point(0, -1),
            new Point(1, 0),
            new Point(0, 1),
            new Point(-1, 0)
        };
        public override void ParseInput(string input)
        {
            _input = input;
            _size = input.Split("\r\n")[0].Length;
            _plane = input.Split("\r\n").Select(x => x.ToCharArray()).ToArray();
        }

        public override object StarOne()
        {
            int sum = 0;
            var guardPos = FindGuard(guard);
            int turn = 0;
            while (IsInMap(guardPos.Y + _moves[turn].Y, guardPos.X + _moves[turn].X, _size, _size))
            {
                _plane[guardPos.Y][guardPos.X] = X;
                guardPos.Y += _moves[turn].Y;
                guardPos.X += _moves[turn].X;
                if (_plane[guardPos.Y][guardPos.X] == Obstacle)
                {
                    guardPos.Y -= _moves[turn].Y;
                    guardPos.X -= _moves[turn].X;
                    turn = (turn + 1) % 4;
                }
                
            }
            
            return _plane.Select(arr => arr.Count(x => x == X)).Sum() + 1;
        }

        private Point FindGuard(char guard)
        {
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (_plane[y][x] == guard)
                    {
                        return new Point(x, y);
                    }
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        private void PrintBoard(char[][] board)
        {
            Console.Clear();
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.Write(board[y][x]);
                }
                Console.WriteLine();
            }
            Thread.Sleep(100);
        }

        private int XMASCount(int y, int x)
        {
            int xmasCount = 0;
            foreach (var modifier in _moves)
            {
                bool valid = true;
                for (int i = 1; i < 4; i++)
                {
                    int newY = y + modifier.Y * i;
                    int newX = x + modifier.X * i;
                    if (!IsInMap(newY, newX, _size, _size))
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
            int sum = 1;

            return sum;
        }
        private bool AllCornersAccessible(int y, int x, int arrayY, int arrayX)
        {
            return IsInMap(y - 1, x - 1, arrayY, arrayX) && IsInMap(y - 1, x + 1, arrayY, arrayX) && IsInMap(y + 1, x - 1, arrayY, arrayX) && IsInMap(y + 1, x + 1, arrayY, arrayX);
        }
    }
}