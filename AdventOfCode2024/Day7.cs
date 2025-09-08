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
    public class Day7 : Day66
    {
        string _input;
        int _size;
        char[][] _plane;
        char guard = '^'; char Obstacle = '#'; char X = 'X';
        int _maxSize;
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
            _maxSize = input.Length;
            _size = input.Split("\r\n")[0].Length;
            _plane = input.Split("\r\n").Select(x => x.ToCharArray()).ToArray();
        }

        public override object StarOne()
        {
            int sum = 0;
            var _localPlane = _plane.Select(x => x.ToArray()).ToArray();
            var guardPos = FindGuard(guard, _localPlane);
            int turn = 0;
            int newAssignments = 0;
            do
            {
                _localPlane[guardPos.Y][guardPos.X] = X;
                newAssignments++;
                guardPos.Y += _moves[turn].Y;
                guardPos.X += _moves[turn].X;
                if (_localPlane[guardPos.Y][guardPos.X] == Obstacle)
                {
                    guardPos.Y -= _moves[turn].Y;
                    guardPos.X -= _moves[turn].X;
                    turn = (turn + 1) % 4;
                }
            } while (IsInMap(guardPos.Y + _moves[turn].Y, guardPos.X + _moves[turn].X, _size, _size) && newAssignments < _maxSize * 2);
           

            return _localPlane.Select(arr => arr.Count(x => x == X)).Sum() + 1;
        }

        private Point FindGuard(char guard, char[][] _localPlane)
        {
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (_localPlane[y][x] == guard)
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

        private bool IsInMap(int newY, int newX, int arrayY, int arrayX)
        {
            return newY >= 0 && newX >= 0 && newX < arrayX && newY < arrayY;
        }

        public override object StarTwo()
        {
            int sum = 0;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    var _localPlane = _plane.Select(x => x.ToArray()).ToArray();
                    if (_localPlane[i][j] != guard)
                    {
                        _localPlane[i][j] = Obstacle;
                    }

                    var guardPos = FindGuard(guard, _localPlane);
                    int turn = 0;
                    int newAssignments = 0;
                    do
                    {
                        _localPlane[guardPos.Y][guardPos.X] = X;
                        newAssignments++;
                        guardPos.Y += _moves[turn].Y;
                        guardPos.X += _moves[turn].X;
                        if (_localPlane[guardPos.Y][guardPos.X] == Obstacle)
                        {
                            guardPos.Y -= _moves[turn].Y;
                            guardPos.X -= _moves[turn].X;
                            turn = (turn + 1) % 4;
                        }
                    } while (IsInMap(guardPos.Y + _moves[turn].Y, guardPos.X + _moves[turn].X, _size, _size) && newAssignments < _maxSize * 2);

                    if (newAssignments >= _maxSize * 2)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
    }
}