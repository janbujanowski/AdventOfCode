using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day8 : Day66
    {
        Dictionary<int, int> amountOfsubmarinesOnPositionKey;
        string _strInput;
        int _meanLower;
        int _linesCount;
        int _median;

        int[,] _signalInputsExamples;
        int[,] _signalOutputs;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;

            string[] lines = _strInput.Split("\r\n");
            _linesCount = lines.Length;
            _signalInputsExamples = new int[lines.Length, 10];
            _signalOutputs = new int[lines.Length, 4];
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(" | ");
                var inputs = line[0].Split(" ").Select(x => x.Count()).ToArray();
                for (int j = 0; j < inputs.Length; j++)
                {
                    _signalInputsExamples[i, j] = inputs[j];
                }
                inputs = line[1].Split(" ").Select(x => x.Count()).ToArray();
                for (int j = 0; j < inputs.Length; j++)
                {
                    _signalOutputs[i, j] = inputs[j];
                }
            }
        }

        public override object StarOne()
        {
            List<int> oneFourSevenEight = new List<int>() { 2, 3, 4, 7 };
            int sum = 0;
            
            for (int i = 0; i < _linesCount; i++)
            {
                for (int h = 0; h < 4; h++)
                {
                    if (oneFourSevenEight.Contains(_signalOutputs[i,h]))
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }
        private int CalculateSingleSubConsumptionStarOne(int from, int to)
        {
            return Math.Abs(from - to);
        }
        private uint CalculateAllSubsDistanceTo(int positionWithMaximumAmountOfSubs, Func<int, int, int> fuelConsumptionFunction)
        {
            uint fuel = 0;
            int targetPostion = positionWithMaximumAmountOfSubs;
            foreach (var item in amountOfsubmarinesOnPositionKey)
            {
                if (item.Key != targetPostion)
                {
                    fuel += Convert.ToUInt32(fuelConsumptionFunction(item.Key, targetPostion) * item.Value);
                }
            }
            return fuel;
        }
        private int CalculateSingleSubConsumptionStarTwo(int from, int to)
        {
            int fuelConsumptionPerSub = 0;
            for (int i = 1; i <= Math.Abs(from - to); i++)
            {
                fuelConsumptionPerSub += i;
            }
            return fuelConsumptionPerSub;
        }
        public override object StarTwo()
        {
            var res = -1;
            //var a = CalculateAllSubsDistanceTo(_meanLower, CalculateSingleSubConsumptionStarTwo);
            //var b = CalculateAllSubsDistanceTo(_meanUpper, CalculateSingleSubConsumptionStarTwo);
            //var res = a;
            //if (a > b)
            //{
            //    res = b;
            //}
            return res;
        }
    }
}
