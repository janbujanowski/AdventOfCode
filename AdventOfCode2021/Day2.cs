using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day2 : Day66
    {
        string[] lines;
        int[] amountOfMovement;
        string[] directionOfMovement;
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            amountOfMovement = lines.Select(line => int.Parse(line.Split(' ')[1])).ToArray();
            directionOfMovement = lines.Select(line => line.Split(' ')[0]).ToArray();
        }

        public override object StarOne()
        {
            int horizontalPos = 0;
            int depth = 0;
            for (int i = 0; i < amountOfMovement.Length; i++)
            {
                switch (directionOfMovement[i])
                {
                    case "forward":
                        horizontalPos += amountOfMovement[i];
                        break;
                    case "up":
                        depth -= amountOfMovement[i];
                        break;
                    case "down":
                        depth += amountOfMovement[i];
                        break;
                    default:
                        break;
                }
            }
            return horizontalPos * depth;
        }
        public override object StarTwo()
        {
            int horizontalPos = 0;
            int depth = 0;
            int aim = 0;
            for (int i = 0; i < amountOfMovement.Length; i++)
            {
                switch (directionOfMovement[i])
                {
                    case "forward":
                        horizontalPos += amountOfMovement[i];
                        depth += amountOfMovement[i] * aim;
                        break;
                    case "up":
                        //depth -= amountOfMovement[i];
                        aim -= amountOfMovement[i];
                        break;
                    case "down":
                        //depth += amountOfMovement[i];
                        aim += amountOfMovement[i];
                        break;
                    default:
                        break;
                }
            }
            return horizontalPos * depth;
        }
    }
}
