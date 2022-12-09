using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;

namespace AdventOfCode2022
{
    class Knot
    {
        public int Id,XPos, YPos;
        public Knot Parent;
        public Knot Child;
        public List<Tuple<int, int>> _visitedPositions;
        public Knot(int xPos, int yPos)
        {
            this.XPos = xPos; this.YPos = yPos;
            _visitedPositions = new List<Tuple<int, int>>();
            PositionsUpdate();
        }
        public void Move(int xDirection, int yDirection)
        {
            XPos += xDirection; YPos += yDirection;
            PositionsUpdate();
            Child?.NotifyParentMoved();
        }
        public void NotifyParentMoved()
        {
            if (TailNeedsToFollow)
            {
                int xDirection = Math.Sign(Parent.XPos - XPos);
                int yDirection = Math.Sign(Parent.YPos - YPos);
                Move(xDirection, yDirection);
            }
        }
        private bool TailNeedsToFollow
        {
            get
            {
                return Math.Abs(Parent.XPos - XPos) > 1 || Math.Abs(Parent.YPos - YPos) > 1;
            }
        }
        private void PositionsUpdate()
        {
            var tuple = new Tuple<int, int>(XPos, YPos);
            if (!_visitedPositions.Contains(tuple))
            {
                _visitedPositions.Add(tuple);
            }
        }
        public Knot Last
        {
            get
            {
                if (Child == null)
                {
                    return this;
                }
                else
                {
                    return Child.Last;
                }
            }
        }
    }
    public class Day9 : Day66
    {
        string _strInput;
        Knot _firstKnot;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }

        public override object StarOne()
        {
            _firstKnot = GenerateKnots(2);
            SimulateMovement(_firstKnot);
            return _firstKnot.Last._visitedPositions.Count;
        }

        private void SimulateMovement(Knot firstKnot)
        {
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
                for (int i = 0; i < stepsCount; i++)
                {
                    firstKnot.Move(xDirection, yDirection);
                }

            }
        }

        private Knot GenerateKnots(int knotsAmount)
        {   
            var firstKnot = new Knot(0, 0);
            Knot current = firstKnot;
            firstKnot.Id = 0;
            for (int i = 1; i < knotsAmount; i++)
            {
                current.Child = new Knot(0, 0);
                current.Child.Id = i;
                current.Child.Parent = current;
                current = current.Child;
            }
            return firstKnot;
        }

        public override object StarTwo()
        {
            _firstKnot = GenerateKnots(10);
            SimulateMovement(_firstKnot);
            return _firstKnot.Last._visitedPositions.Count;
        }
    }
}
