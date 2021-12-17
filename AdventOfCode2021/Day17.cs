using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day17 : Day66
    {
        string _strInput;
        int minY;
        int maxY;
        int minX;
        int maxX;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            string cleanedInput = strInput.Replace("target area: ", "").Replace(" ", "").Replace("x=", "").Replace("y=", "");
            string[] stringified = cleanedInput.Split(',').SelectMany(line => line.Split("..")).ToArray();
            minX = int.Parse(stringified[0]);
            maxX = int.Parse(stringified[1]);
            minY = int.Parse(stringified[2]);
            maxY = int.Parse(stringified[3]);
        }
        Dictionary<int, int> availableHitsWithHeight;
        public override object StarOne()
        {
            availableHitsWithHeight = new Dictionary<int, int>();
            int accelerationY = -1;
            int Vstart = 0;
            int currentVPosition = 0;
            int currentV = Vstart;
            int lastHitY = 0;
            int maxHeight = 0;
            for (int startV = 1; startV < 2000; startV++)
            {
                currentV = startV;
                currentVPosition = 0;
                lastHitY = 0;
                do
                {
                    if (maxHeight < currentVPosition)
                    {
                        maxHeight = currentVPosition;
                    }
                    lastHitY = currentVPosition;
                    currentVPosition += currentV;
                    currentV += accelerationY;

                } while (currentVPosition > minY);
                if (IsBetween(lastHitY, minY, maxY) || IsBetween(currentVPosition, minY, maxY))
                {
                    availableHitsWithHeight.Add(startV, maxHeight);
                }
            }

            return availableHitsWithHeight.Max(x => x.Value);
        }

        bool IsBetween(int check, int min, int max)
        {
            return check >= min && check <= max;
        }

        public override object StarTwo()
        {
            List<Tuple<int, int>> startingVelocitiesWithSuccessHit = new List<Tuple<int, int>>();
            int skyIsTheLimit = 2000;
            // a1 + an etc = maxHeight => maximym start Y velocity
            int minStartX = SolvePowEquasion(minX);

            for (int startYvelocity = minY; startYvelocity < skyIsTheLimit; startYvelocity++)
            {
                for (int startXvelocity = minStartX; startXvelocity <= maxX; startXvelocity++)
                {
                    if (Simulate(startXvelocity, startYvelocity))
                    {
                        startingVelocitiesWithSuccessHit.Add(new Tuple<int, int>(startXvelocity, startYvelocity));
                    }
                }
            }
            return startingVelocitiesWithSuccessHit.Count();
        }

        private bool Simulate(int startXvelocity, int startYvelocity)
        {
            int XPosition = 0;
            int YPosition = 0;
            int XVelocity = startXvelocity;
            int YVelocity = startYvelocity;
            do
            {
                XPosition += XVelocity; YPosition += YVelocity;

                if (IsBetween(XPosition, minX, maxX) && IsBetween(YPosition, minY, maxY))
                {
                    return true;
                }
                if (XVelocity > 0)
                {
                    XVelocity--;
                }
                YVelocity--;
            } while (XPosition <= maxX && YPosition >= minY);
            return false;
        }

        private int SolvePowEquasion(int minX)
        {
            //n^2 + n - 2 * minX
            var delta = Math.Pow(1, 2) - 4 * (-2 * minX);
            var root = Math.Sqrt(delta);
            //var x1 = (-1 - root) / 2 * 1;// root will always be big and we need positive so skip x1
            var x2 = (-1 + root) / 2 * 1;
            return (int)Math.Ceiling(x2);//get first natural that fits minimum req
        }
    }
}