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
        int _meanLower;
        int _meanUpper;
        int _median;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            List<int> crabsSubmarinesPositions = _strInput.Split(',').Select(numb => int.Parse(numb)).ToList();
            crabsSubmarinesPositions.Sort();
            _median = crabsSubmarinesPositions[crabsSubmarinesPositions.Count / 2];
            _meanLower = (int)Math.Floor((decimal)crabsSubmarinesPositions.Sum() / crabsSubmarinesPositions.Count);
            _meanUpper = (int)Math.Ceiling((decimal)crabsSubmarinesPositions.Sum() / crabsSubmarinesPositions.Count);

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

        //The problem asks us to minimize a cost.In the first part, the cost of position $p$ is proportional to the sum of distances from $p$ to all crabs.
        //So, for a given position $p$, the cost is $\sum_x |x-p|$.
        //The position that minimizes this cost is called the median, the well-known central tendency in statistics.

        //In Python,

        //  def median(xs):
        //    """ requires: xs is sorted """
        //    sz = len(xs)
        //    return (xs[int(sz//2)] + xs[int(0.5+sz//2)]) // 2
        //For part 2, the cost is given by the n - th triangular number, T_n = n(n + 1) / 2.
        //We can drop the 2 and say the cost at position $p$ is proportional to $\sum_x | x - p | (| x - p | +1)$
        //which has a very similar shape to $\sum_x(x - p)2$ the quadradic cost of the distance.

        //The statistic that minimizes the quadratic cost is the mean. Of course, the mean might not be an integer,
        //and is not the answer. But it will give a starting point to explore the minimal cost we need,
        //which should be very near this value.

        public override object StarOne()
        {
            return CalculateAllSubsDistanceTo(_median, CalculateSingleSubConsumptionStarOne);
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
            var a = CalculateAllSubsDistanceTo(_meanLower, CalculateSingleSubConsumptionStarTwo);
            var b = CalculateAllSubsDistanceTo(_meanUpper, CalculateSingleSubConsumptionStarTwo);
            var res = a;
            if (a > b)
            {
                res = b;
            }
            return res;
        }
    }
}
