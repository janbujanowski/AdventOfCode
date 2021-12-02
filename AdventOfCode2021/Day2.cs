using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Linq;

namespace AdventOfCode2021
{
    public class SubmarineStarOne
    {
        string[] lines;
        protected int[] amountOfMovement;
        protected string[] directionOfMovement;
        protected int horizontalPos;
        protected int depth;
        public SubmarineStarOne(string strInput)
        {
            horizontalPos = 0; depth = 0;
            lines = strInput.Split("\r\n");
            amountOfMovement = lines.Select(line => int.Parse(line.Split(' ')[1])).ToArray();
            directionOfMovement = lines.Select(line => line.Split(' ')[0]).ToArray();
        }
        public void Move()
        {
            for (int i = 0; i < amountOfMovement.Length; i++)
            {
                switch (directionOfMovement[i])
                {
                    case "forward":
                        MoveForward(i);
                        break;
                    case "up":
                        MoveUp(i);
                        break;
                    case "down":
                        MoveDown(i);
                        break;
                    default:
                        break;
                }
            }
        }
        public virtual void MoveForward(int step)
        {
            horizontalPos += amountOfMovement[step];
        }
        public virtual void MoveUp(int step)
        {
            depth -= amountOfMovement[step];
        }
        public virtual void MoveDown(int step)
        {
            depth += amountOfMovement[step];
        }

        public int GetStarResult()
        {
            return horizontalPos * depth;
        }
    }

    public class SubmarineStarTwo : SubmarineStarOne
    {
        int aim;
        public SubmarineStarTwo(string strInput):base(strInput)
        {
            aim = 0;
        }
        public override void MoveForward(int step)
        {
            horizontalPos += amountOfMovement[step];
            depth += aim * amountOfMovement[step];
        }
        public override void MoveUp(int step)
        {
            aim -= amountOfMovement[step];
        }
        public override void MoveDown(int step)
        {
            aim += amountOfMovement[step];
        }
    }

    public class Day2 : Day66
    {

        string _strInput;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }

        public override object StarOne()
        {
            SubmarineStarOne sub = new SubmarineStarOne(_strInput);
            sub.Move();
            return sub.GetStarResult();
        }
        public override object StarTwo()
        {
            SubmarineStarTwo sub = new SubmarineStarTwo(_strInput);
            sub.Move();
            return sub.GetStarResult();
        }
    }
}
