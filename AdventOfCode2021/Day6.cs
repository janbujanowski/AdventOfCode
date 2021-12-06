using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    //44 + jakies 10
    public class Day6 : Day66
    {
        ulong[] amountOfLanternFishInSpecifiedLifeSpan;
        public override void ParseInput(string strInput)
        {
            amountOfLanternFishInSpecifiedLifeSpan = new ulong[9];
            List<ulong> fishLifes = strInput.Split(',').Select(numb => ulong.Parse(numb)).ToList();
            foreach (var fish in fishLifes)
            {
                amountOfLanternFishInSpecifiedLifeSpan[fish]++;
            }
        }
        public override object StarOne()
        {
            int days = 80;
            RunLifeFor(days);
            return GetSum(amountOfLanternFishInSpecifiedLifeSpan);
        }
        private ulong GetSum(ulong[] arrayOfNumbs)
        {
            ulong sum = 0;
            for (int i = 0; i < arrayOfNumbs.Length; i++)
            {
                sum += arrayOfNumbs[i];
            }
            return sum;
        }
        public override object StarTwo()
        {
            int days = 256;
            RunLifeFor(days);
            var sum = GetSum(amountOfLanternFishInSpecifiedLifeSpan);
            return sum;
        }
        private void RunLifeFor(int days)
        {
            for (int i = 0; i < days; i++)
            {
                ulong amountOfNewBorns = amountOfLanternFishInSpecifiedLifeSpan[0];
                for (int j = 1; j < amountOfLanternFishInSpecifiedLifeSpan.Length; j++)
                {
                    amountOfLanternFishInSpecifiedLifeSpan[j - 1] = amountOfLanternFishInSpecifiedLifeSpan[j];
                }
                amountOfLanternFishInSpecifiedLifeSpan[6] += amountOfNewBorns;
                amountOfLanternFishInSpecifiedLifeSpan[8] = amountOfNewBorns;
            }
        }
    }
}