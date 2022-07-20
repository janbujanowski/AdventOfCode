using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    public class Day1 : Day66
    {
        string[] lines;
        int[] modulesWeights;
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            modulesWeights = lines.Select(line => int.Parse(line)).ToArray();
        }
        public override object StarOne()
        {
            int fuelRequired = 0;
            foreach (var weight in modulesWeights)
            {
                fuelRequired += CalculateFuel(weight);
            }
            return fuelRequired;
        }

        private int CalculateFuel(int weight)
        {
            var fuel = WeightFormula(weight);
            return fuel;
        }

        public override object StarTwo()
        {
            int fuelRequired = 0;
            foreach (var weight in modulesWeights)
            {
                fuelRequired += CalculateFuelStarTwo(weight);
            }
            return fuelRequired;
        }

        private int CalculateFuelStarTwo(int weight)
        {
            var moduleFuel = WeightFormula(weight);

            var fuelForFuel = WeightFormula(moduleFuel);
            while(fuelForFuel > 0)
            {
                moduleFuel += fuelForFuel;
                fuelForFuel = WeightFormula(fuelForFuel);
            }
            return moduleFuel;
        }
        private int WeightFormula(int weight)
        {
            return Convert.ToInt32(Math.Floor(weight / 3.0) - 2);
        }
    }
}
