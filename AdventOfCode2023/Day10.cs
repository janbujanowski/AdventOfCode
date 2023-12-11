using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2023
{
    public class Day10 : Day66
    {
        enum TileType
        {
            Ground = '.',
            Vertical = '|',
            Horizontal = '-',
            NorthEastBend = 'L',
            NorthWestBend = 'J',
            SouthWestBend = '7',
            SouthEastBend = 'F',
            Start = 'S',
        }
        enum MoveType
        {
            FromBottom,
            FromLeft,
            FromRight,
            FromTop
        }
        string[] _lines;
        TileType[][] _map;
        bool[,] _mapVisited;
        int[,] _stepOfKnot;
        class NextMove
        {
            public int X;
            public int Y;
            public MoveType Type;
            public TileType TileType;
            public NextMove(int y, int x, MoveType type, TileType tileType)
            {
                this.X = x;
                this.Y = y;
                this.Type = type;
                this.TileType = tileType;
            }
        }

        public override void ParseInput(string strInput)
        {
            _map = strInput.Split("\r\n").Select(line => line.Select(tile => (TileType)tile).ToArray()).ToArray();
            _mapVisited = new bool[_map.Length, _map.Length];
            _stepOfKnot = new int[_map.Length, _map.Length];
        }
        public override object StarOne()
        {
            double steps = 0;
            (int, int) startPos = FindStart();
            int currentY = startPos.Item1;
            int currentX = startPos.Item2;
            int visitedY = 0;
            int visitedX = 0;
            do
            {
                steps++;
                List<NextMove> possibleMoves = GetPossibleMoves(currentY, currentX);
                foreach (var nextMove in possibleMoves)
                {
                    if (MoveCanBeExecuted(currentY, currentX, nextMove) && !(nextMove.Y == visitedY && nextMove.X == visitedX))
                    {
                        _mapVisited[currentY, currentX] = true;
                        _stepOfKnot[currentY, currentX] = (int)steps + 1;
                        visitedY = currentY;
                        visitedX = currentX;
                        currentY = nextMove.Y;
                        currentX = nextMove.X;
                        break;
                    }
                }

            } while (!(currentY == startPos.Item1 && currentX == startPos.Item2));

            return Math.Ceiling(steps / 2d);
        }

        private bool MoveCanBeExecuted(int currentY, int currentX, NextMove nextMove)
        {
            TileType currentTile = _map[currentY][currentX];
            TileType nextTile = nextMove.TileType;

            if (nextMove.Type == MoveType.FromLeft)
            {
                return ((currentTile == TileType.Horizontal || currentTile == TileType.Start) && (nextTile == TileType.Horizontal || nextTile == TileType.NorthWestBend || nextTile == TileType.SouthWestBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.NorthEastBend && (nextTile == TileType.Horizontal || nextTile == TileType.NorthWestBend || nextTile == TileType.SouthWestBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.SouthEastBend && (nextTile == TileType.Horizontal || nextTile == TileType.NorthWestBend || nextTile == TileType.SouthWestBend || nextTile == TileType.Start));
            }
            if (nextMove.Type == MoveType.FromRight)
            {
                return ((currentTile == TileType.Horizontal || currentTile == TileType.Start) && (nextTile == TileType.Horizontal || nextTile == TileType.NorthEastBend || nextTile == TileType.SouthEastBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.NorthWestBend && (nextTile == TileType.Horizontal || nextTile == TileType.NorthEastBend || nextTile == TileType.SouthEastBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.SouthWestBend && (nextTile == TileType.Horizontal || nextTile == TileType.NorthEastBend || nextTile == TileType.SouthEastBend || nextTile == TileType.Start));
            }
            if (nextMove.Type == MoveType.FromTop)
            {
                return ((currentTile == TileType.Vertical || currentTile == TileType.Start) && (nextTile == TileType.Vertical || nextTile == TileType.NorthEastBend || nextTile == TileType.NorthWestBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.SouthEastBend && (nextTile == TileType.Vertical || nextTile == TileType.NorthEastBend || nextTile == TileType.NorthWestBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.SouthWestBend && (nextTile == TileType.Vertical || nextTile == TileType.NorthEastBend || nextTile == TileType.NorthWestBend || nextTile == TileType.Start));
            }
            if (nextMove.Type == MoveType.FromBottom)
            {
                return ((currentTile == TileType.Vertical || currentTile == TileType.Start) && (nextTile == TileType.Vertical || nextTile == TileType.SouthEastBend || nextTile == TileType.SouthWestBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.NorthEastBend && (nextTile == TileType.Vertical || nextTile == TileType.SouthEastBend || nextTile == TileType.SouthWestBend || nextTile == TileType.Start)) ||
                    (currentTile == TileType.NorthWestBend && (nextTile == TileType.Vertical || nextTile == TileType.SouthEastBend || nextTile == TileType.SouthWestBend || nextTile == TileType.Start));
            }
            return false;
        }

        private List<NextMove> GetPossibleMoves(int currentY, int currentX)
        {
            List<NextMove> possibleMoves = new List<NextMove>();
            if (currentY - 1 >= 0)
            {
                if (_map[currentY - 1][currentX] != TileType.Ground)
                {

                    possibleMoves.Add(new NextMove(currentY - 1, currentX, MoveType.FromBottom, _map[currentY - 1][currentX]));
                }
            }
            if (currentY + 1 < _map.Length)
            {
                if (_map[currentY + 1][currentX] != TileType.Ground)
                {
                    possibleMoves.Add(new NextMove(currentY + 1, currentX, MoveType.FromTop, _map[currentY + 1][currentX]));
                }
            }
            if (currentX - 1 >= 0)
            {
                if (_map[currentY][currentX - 1] != TileType.Ground)
                {
                    possibleMoves.Add(new NextMove(currentY, currentX - 1, MoveType.FromRight, _map[currentY][currentX - 1]));

                }
            }
            if (currentX + 1 < _map.Length)
            {
                if (_map[currentY][currentX + 1] != TileType.Ground)
                {
                    possibleMoves.Add(new NextMove(currentY, currentX + 1, MoveType.FromLeft, _map[currentY][currentX + 1]));
                }
            }
            if (possibleMoves.Count == 0)
            {
                throw new ArgumentOutOfRangeException("There should be always next move available");
            }
            return possibleMoves;
        }

        private (int, int) FindStart()
        {
            for (int y = 0; y < _map.Length; y++)
            {
                for (int x = 0; x < _map.Length; x++)
                {
                    if (_map[y][x] == TileType.Start)
                    {
                        return (y, x);
                    }
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public override object StarTwo()
        {
            int amountInsidePlane = 0;
            for (int y = 0; y < _map.Length-1; y++)
            {
                for (int x = 0; x < _map.Length; x++)
                {
                    int windingNumber;
                    if (_stepOfKnot[y, x] == 0)
                    {
                        windingNumber = CalculateWindingForPosition(y, x);
                        if (windingNumber != 0)
                        {
                            //Console.Write("I");
                            amountInsidePlane++;
                        }
                        else
                        {
                           // Console.Write(".");
                        }
                    }
                    else
                    {
                        //Console.Write((char)_map[y][x]);
                    }
                }
                //Console.WriteLine();
            }
            return amountInsidePlane;
        }

        private int CalculateWindingForPosition(int y, int x)
        {
            
            int winding = 0;
            for (int xn = x + 1; xn < _map.Length; xn++)
            {
                if (_stepOfKnot[y, xn] != 0 && _stepOfKnot[y + 1, xn] != 0)
                {
                    if (_stepOfKnot[y, xn] - _stepOfKnot[y + 1, xn] == 1)
                    {
                        winding++;
                    }
                    else if(_stepOfKnot[y, xn] - _stepOfKnot[y + 1, xn] == -1)
                    {
                        winding--;
                    }
                }
            }
            return winding;
        }
    }
}