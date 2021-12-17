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
        int minY = -10;
        int maxY = -5;
        int minX = 20;
        int maxX = 30;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }
        private List<string> ConvertStringToBinaryList(string input)
        {
            return input.Select(letter => Convert.ToString(Convert.ToInt32(letter.ToString(), 16), 2).PadLeft(4, '0')).ToList();
        }
        string _packetTypeLiteral = "100"; //binary 4;
        Dictionary<int, int> availableHitsWithHeight;
        public override object StarOne()
        {
            availableHitsWithHeight = new Dictionary<int, int>();
            int accelerationY = -1;
            int Vstart = 0;
            int currentVPosition = 0;
            int timeFromStart = 0;
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

        Dictionary<int, int> availableHitsWithMinTime;
        public override object StarTwo()
        {
            availableHitsWithMinTime = new Dictionary<int, int>();
            int accelerationY = -1;
            int Vstart = 0;
            int currentXPosition = 0;
            int timeFromStart = 0;
            int currentXvelocity = Vstart;
            int minimutTime = 0;
            int maxHeight = 0;
            for (int startXvelocity = 1; startXvelocity < 2000; startXvelocity++)
            {
                currentXvelocity = startXvelocity;
                currentXPosition = 0;
                minimutTime = 0;
                do
                {
                    minimutTime++;
                    currentXPosition += currentXvelocity;
                    currentXvelocity--;

                } while (currentXvelocity > 0);
                if (IsBetween(currentXPosition, minX, maxX))
                {
                    availableHitsWithMinTime.Add(startXvelocity, minimutTime);
                }
            }

            return availableHitsWithHeight.Count() * availableHitsWithMinTime.Count();
        }
    }
}