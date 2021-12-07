using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day7 : Day66
    {

        Dictionary<int, int> amountOfsubmarinesOnPositionKey;
        string _strInput;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            //amountOfLanternFishInSpecifiedLifeSpan = CreateEmptyDictionary(9);
            List<int> crabsSubmarinesPositions = strInput.Split(',').Select(numb => int.Parse(numb)).ToList();
            amountOfsubmarinesOnPositionKey = new Dictionary<int, int>();
            for (int i = 0; i < crabsSubmarinesPositions.Count; i++)
            {
                if (!amountOfsubmarinesOnPositionKey.ContainsKey(crabsSubmarinesPositions[i]))
                {
                    amountOfsubmarinesOnPositionKey.Add(crabsSubmarinesPositions[i], 0);
                }
                amountOfsubmarinesOnPositionKey[crabsSubmarinesPositions[i]]++;
            }
        }

        public override object StarOne()
        {
            var maxVal = amountOfsubmarinesOnPositionKey.Max(x => x.Value);
            var positionWithMaximumAmountOfSubs = amountOfsubmarinesOnPositionKey.Where(x => x.Value == maxVal).FirstOrDefault();

            Dictionary<int, uint> distancesToPositionX = new Dictionary<int, uint>();
            foreach (var position in amountOfsubmarinesOnPositionKey)
            {
                if (!distancesToPositionX.ContainsKey(position.Key))
                {
                    distancesToPositionX.Add(position.Key, CalculateDistanceTo(position));
                }
            }
            var minimumFuel = distancesToPositionX.Min(x => x.Value);

            //int fuel = CalculateDistanceTo(positionWithMaximumAmountOfSubs);

            return minimumFuel;
        }

        private uint CalculateDistanceTo(KeyValuePair<int, int> positionWithMaximumAmountOfSubs)
        {
            uint fuel = 0;
            int targerPostion = positionWithMaximumAmountOfSubs.Key;
            foreach (var item in amountOfsubmarinesOnPositionKey)
            {
                if (item.Key != targerPostion)
                {
                    fuel += Convert.ToUInt32(Math.Abs(item.Key - targerPostion) * item.Value);
                }
            }
            return fuel;
        }
        

        public override object StarTwo()
        {
            var maxVal = amountOfsubmarinesOnPositionKey.Max(x => x.Value);
            int fromX = amountOfsubmarinesOnPositionKey.Min(x => x.Key);
            int toX = amountOfsubmarinesOnPositionKey.Max(x => x.Key);


            Dictionary<int, uint> distancesToPositionX = new Dictionary<int, uint>();
            for (int i = fromX; i <= toX; i++)
            {
                if (!distancesToPositionX.ContainsKey(i))
                {
                    distancesToPositionX.Add(i, CalculateDistanceToVersionIncremental(i));
                }
            }
            
            var minimumFuel = distancesToPositionX.Min(x => x.Value);
            return minimumFuel;
        }
        private uint CalculateDistanceToVersionIncremental(int positionWithMaximumAmountOfSubs)
        {
            uint fuel = 0;
            int targerPostion = positionWithMaximumAmountOfSubs;
            foreach (var item in amountOfsubmarinesOnPositionKey)
            {
                if (item.Key != targerPostion)
                {
                    var fuelConsumptionPerSub = 0;
                    for (int i = 1; i <= Math.Abs(item.Key - targerPostion); i++)
                    {
                        fuelConsumptionPerSub += i;
                    }
                    fuel += Convert.ToUInt32(fuelConsumptionPerSub * item.Value);
                }
            }
            return fuel;
        }
    }
}
