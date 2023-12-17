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
    public class Day16 : Day66
    {
        enum ContraptionType
        {
            Empty = '.',
            VerticalSplitter = '|',
            HorizontalSplitter = '-',
            MirrorBackslash = '\\',
            MirrorSlash = '/'
        }
        enum MoveType
        {
            FromBottom,
            FromLeft,
            FromRight,
            FromTop
        }
        ContraptionType[][] _map;
        List<MoveType>[,] _visitedCount;
        int _mapDimension;
        class Move
        {
            public int X;
            public int Y;
            public MoveType Type;
            public ContraptionType TileType;
            public Move(int y, int x, MoveType type, ContraptionType tileType)
            {
                this.X = x;
                this.Y = y;
                this.Type = type;
                this.TileType = tileType;
            }
        }
        public override void ParseInput(string strInput)
        {
            _map = strInput.Split("\r\n").Select(line => line.Select(tile => (ContraptionType)tile).ToArray()).ToArray();
            _mapDimension = _map.Length;
            _visitedCount = new List<MoveType>[_map.Length, _map.Length];
        }
        public override object StarOne()
        {
            Move startMove = new Move(0, 0, MoveType.FromLeft, _map[0][0]);
            StartBeam(startMove);


            return CountEnergized(_visitedCount);
        }

        private int CountEnergized(List<MoveType>[,] visitedCount)
        {
            int count = 0;
            for (int y = 0; y < _mapDimension; y++)
            {
                for (int x = 0; x < _mapDimension; x++)
                {
                    if (visitedCount[y, x] != null)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void StartBeam(Move nextMove)
        {
            if (nextMove != null)
            {
                Move move = nextMove;
                if (_visitedCount[move.Y, move.X] == null)
                {
                    _visitedCount[move.Y, move.X] = new List<MoveType>();
                }
                while (move != null && !_visitedCount[move.Y, move.X].Contains(move.Type))
                {

                    _visitedCount[move.Y, move.X].Add(move.Type);

                    move = GetNextMove(move);
                    if (move != null && _visitedCount[move.Y, move.X] == null)
                    {
                        _visitedCount[move.Y, move.X] = new List<MoveType>();
                    }
                }
            }
        }

        private Move GetNextMove(Move move)
        {
            switch (move.TileType)
            {
                case ContraptionType.Empty:
                    return JustExecute(move);
                    break;
                case ContraptionType.VerticalSplitter:
                    if (move.Type == MoveType.FromLeft || move.Type == MoveType.FromRight)
                    {
                        move.Type = MoveType.FromBottom;
                        StartBeam(JustExecute(move));
                        move.Type = MoveType.FromTop;
                        StartBeam(JustExecute(move));
                    }
                    else
                    {
                        return JustExecute(move);
                    }
                    break;
                case ContraptionType.HorizontalSplitter:
                    if (move.Type == MoveType.FromTop || move.Type == MoveType.FromBottom)
                    {
                        move.Type = MoveType.FromLeft;
                        StartBeam(JustExecute(move));
                        move.Type = MoveType.FromRight;
                        StartBeam(JustExecute(move));
                    }
                    else
                    {
                        return JustExecute(move);
                    }
                    break;
                case ContraptionType.MirrorBackslash:
                    switch (move.Type)
                    {
                        case MoveType.FromBottom:
                            move.Type = MoveType.FromRight;
                            return JustExecute(move);
                        case MoveType.FromLeft:
                            move.Type = MoveType.FromTop;
                            return JustExecute(move);
                        case MoveType.FromRight:
                            move.Type = MoveType.FromBottom;
                            return JustExecute(move);
                        case MoveType.FromTop:
                            move.Type = MoveType.FromLeft;
                            return JustExecute(move);
                        default:
                            break;
                    }
                    break;
                case ContraptionType.MirrorSlash:
                    switch (move.Type)
                    {
                        case MoveType.FromBottom:
                            move.Type = MoveType.FromLeft;
                            return JustExecute(move);
                        case MoveType.FromLeft:
                            move.Type = MoveType.FromBottom;
                            return JustExecute(move);
                        case MoveType.FromRight:
                            move.Type = MoveType.FromTop;
                            return JustExecute(move);
                        case MoveType.FromTop:
                            move.Type = MoveType.FromRight;
                            return JustExecute(move);
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

        private Move JustExecute(Move move)
        {
            int newX = move.X; int newY = move.Y;
            switch (move.Type)
            {
                case MoveType.FromBottom:
                    newY--;
                    break;
                case MoveType.FromLeft:
                    newX++;
                    break;
                case MoveType.FromRight:
                    newX--;
                    break;
                case MoveType.FromTop:
                    newY++;
                    break;
                default:
                    break;
            }
            if (IsInMap(newY, newX))
            {
                return new Move(newY, newX, move.Type, _map[newY][newX]);
            }
            return null;
        }

        private bool IsInMap(int newY, int newX)
        {
            return newY >= 0 && newX >= 0 && newX < _map.Length && newY < _map.Length;
        }

        public override object StarTwo()
        {
            List<int> possibleMaxEnergies = new List<int>();
            for (int i = 0; i < _mapDimension; i++)
            {
                _visitedCount = new List<MoveType>[_map.Length, _map.Length];
                Move startMove = new Move(i, 0, MoveType.FromLeft, _map[i][0]);
                StartBeam(startMove);
                possibleMaxEnergies.Add(CountEnergized(_visitedCount));

                _visitedCount = new List<MoveType>[_map.Length, _map.Length];
                startMove = new Move(0, i, MoveType.FromTop, _map[0][i]);
                StartBeam(startMove);
                possibleMaxEnergies.Add(CountEnergized(_visitedCount));

                _visitedCount = new List<MoveType>[_map.Length, _map.Length];
                startMove = new Move(i, _map.Length - 1, MoveType.FromRight, _map[i][_map.Length - 1]);
                StartBeam(startMove);
                possibleMaxEnergies.Add(CountEnergized(_visitedCount));
                _visitedCount = new List<MoveType>[_map.Length, _map.Length];
                startMove = new Move(_map.Length - 1, i, MoveType.FromBottom, _map[_map.Length - 1][i]);
                StartBeam(startMove);
                possibleMaxEnergies.Add(CountEnergized(_visitedCount));

            }
            return possibleMaxEnergies.Max();
        }
    }
}