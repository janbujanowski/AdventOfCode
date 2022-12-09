using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;

namespace AdventOfCode2022
{
    public class Day9 : Day66
    {
        string _strInput;
        int _xPos_T;
        int _yPos_T;
        int _xPos_H;
        int _yPos_H;
        List<Tuple<int, int>> _visited;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;

        }

        public override object StarOne()
        {
            _xPos_H = 0; _yPos_H = 0; _xPos_T = 0; _yPos_T = 0;
            _visited = new List<Tuple<int, int>>();
            PositionsUpdate();
            var instructions = _strInput.SplitWithEnter();
            int xDirection = 0; int yDirection = 0;
            foreach (var instruction in instructions)
            {
                var split = instruction.Split(" ");
                var direction = split[0][0];
                var stepsCount = Int32.Parse(split[1]);
                switch (direction)
                {
                    case 'R':
                        xDirection = 1; yDirection = 0;
                        break;
                    case 'U':
                        xDirection = 0; yDirection = 1;
                        break;
                    case 'L':
                        xDirection = -1; yDirection = 0;
                        break;
                    case 'D':
                        xDirection = 0; yDirection = -1;
                        break;
                    default:
                        break;
                }
                int _xPos_H_previous = _xPos_H;
                int _yPos_H_previous = _yPos_H;
                for (int i = 0; i < stepsCount; i++)
                {
                    _xPos_H += xDirection; _yPos_H += yDirection;
                    if (TailNeedsToFollow)
                    {
                        _yPos_T = _yPos_H_previous;
                        _xPos_T = _xPos_H_previous;
                        PositionsUpdate();
                    }
                    _xPos_H_previous = _xPos_H;
                    _yPos_H_previous = _yPos_H;
                }

            }

            return _visited.Count;
        }
        private bool TailNeedsToFollow
        {
            get
            {

                return Math.Abs(_xPos_H - _xPos_T) > 1 || Math.Abs(_yPos_H - _yPos_T) > 1;
            }
        }

        private void PositionsUpdate()
        {
            var tuple = new Tuple<int, int>(_xPos_T, _yPos_T);
            if (!_visited.Contains(tuple))
            {
                _visited.Add(tuple);
            }
        }
        private bool IsDiagonal()
        {
            return !(_xPos_H == _xPos_T || _yPos_H == _yPos_T);
        }

        public override object StarTwo()
        {
            long maxScenicScore = 1;

            return maxScenicScore;
        }
    }
}
