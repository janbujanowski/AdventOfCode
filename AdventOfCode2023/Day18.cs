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
    public class Day18 : Day66
    {
        int _maxY;
        int _maxX;

        int _shiftAllDimensions = 300;

        enum TerrainState
        {
            Filled = '.',
            Trench = '#'
        }
        enum MoveType
        {
            Down = 'D',
            Up = 'U',
            Left = 'L',
            Right = 'R'
        }
        class DigPlanMove
        {
            public MoveType MoveType;
            public int Distance;
            public string Color;
            public DigPlanMove(MoveType type, int distance, string color)
            {
                MoveType = type;
                Distance = distance;
                Color = color;
            }
        }
        struct GroundState
        {
            public int X;
            public int Y;
            public TerrainState State;
            public int Id;
        }
        GroundState[][] _map;
        List<DigPlanMove> _plannedMoves;

        List<GroundState> _executedTrench;

        public override void ParseInput(string strInput)
        {
            _plannedMoves = strInput.Split("\r\n").Select(line =>
            new DigPlanMove((MoveType)Convert.ToChar(line.Split(' ')[0]),
            int.Parse(line.Split(' ')[1]),
            line.Split(' ')[2].RemoveInstances("(", ")"))
                ).ToList();
        }
        public override object StarOne()
        {
            _maxX = 0; _maxY = 0;
            _executedTrench = new List<GroundState>();
            GroundState currentGroundState = new GroundState() { X = 0, Y = 0, State = TerrainState.Trench };

            foreach (var move in _plannedMoves)
            {
                currentGroundState = ExecuteMove(move, currentGroundState);
            }
            int trenchCubicMeterCount = _executedTrench.Count;

            DigOutInteriorOfTrench();

            int trenchCount = 0;
            for (int y = 0; y < _maxY + 1; y++)
            {
                for (int x = 0; x < _maxX + 1; x++)
                {
                    if (_map[y][x].State == TerrainState.Trench)
                    {
                        trenchCount++;
                    }
                    //Console.Write((char)_map[y][x].State);
                }
                //Console.WriteLine();
            }

            return trenchCount;
        }
        private GroundState ExecuteMove(DigPlanMove move, GroundState currentGroundState)
        {
            //_executedTrench.Add(currentGroundState);
            GroundState nextState = new GroundState() { State = TerrainState.Trench, X = currentGroundState.X, Y = currentGroundState.Y };
            for (int i = 0; i < move.Distance; i++)
            {
                switch (move.MoveType)
                {
                    case MoveType.Down:
                        nextState.Y++;
                        break;
                    case MoveType.Up:
                        nextState.Y--;
                        break;
                    case MoveType.Left:
                        nextState.X--;
                        break;
                    case MoveType.Right:
                        nextState.X++;
                        break;
                    default:
                        break;
                }
                _executedTrench.Add(new GroundState() { State = TerrainState.Trench, X = nextState.X, Y = nextState.Y });
            }
            if (_maxY < nextState.Y)
            {
                _maxY = nextState.Y;
            }
            if (_maxX < nextState.X)
            {
                _maxX = nextState.X;
            }
            return nextState;
        }
        private int DigOutInteriorOfTrench()
        {
            _maxY += _shiftAllDimensions;
            _maxX += _shiftAllDimensions;
            int interiorCount = 0;
            GroundState[][] map = new GroundState[_maxY + 1][];
            for (int i = 0; i < _maxY+1; i++)
            {
                map[i] = new GroundState[_maxX+1];
            }
            int Id = 1;
            foreach (var dig in _executedTrench)
            {
                //if (map[dig.Y + _shiftAllDimensions] == null)
                //{
                //    map[dig.Y + _shiftAllDimensions] = new GroundState[_maxX + 1 + _shiftAllDimensions];
                //}
                map[dig.Y + _shiftAllDimensions][dig.X + _shiftAllDimensions].State = TerrainState.Trench;
                map[dig.Y + _shiftAllDimensions][dig.X + _shiftAllDimensions].Id = Id;
                Id++;
            }
            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX ; x++)
                {
                    if (CalculateWindingForPosition(y, x, map) != 0)
                    {
                        interiorCount++;
                        map[y][x].State = TerrainState.Trench;
                    }
                }
            }
            _map = map;
            return interiorCount;
        }
        private int CalculateWindingForPosition(int y, int x, GroundState[][] map)
        {
            int arrayWidth = map[y].Length;
            int winding = 0;
            for (int xn = x + 1; xn < arrayWidth; xn++)
            {
                if (map[y][xn].Id != 0 && map[y + 1][xn].Id != 0)
                {
                    if (map[y][xn].Id - map[y + 1][xn].Id == 1)
                    {
                        winding++;
                    }
                    else if (map[y][xn].Id - map[y + 1][xn].Id == -1)
                    {
                        winding--;
                    }
                }
            }
            return winding;
        }

        public override object StarTwo()
        {
            List<int> possibleMaxEnergies = new List<int>();

            return 1;
        }
    }
}