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
        Dictionary<int, ulong> amountOfLanternFishInSpecifiedLifeSpan;
        string _strInput;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            amountOfLanternFishInSpecifiedLifeSpan = CreateEmptyDictionary(9);
            List<int> fishLifes = strInput.Split(',').Select(numb => int.Parse(numb)).ToList();
            for (int i = 0; i < fishLifes.Count; i++)
            {
                amountOfLanternFishInSpecifiedLifeSpan[fishLifes.ElementAt(i)]++;
            }
        }

        private Dictionary<int, ulong> CreateEmptyDictionary(int size)
        {
            Dictionary<int, ulong> dict = new Dictionary<int, ulong>();
            for (int i = 0; i < size; i++)
            {
                dict.Add(i, 0);
            }
            return dict;
        }

        public override object StarOne()
        {
            int days = 80;
            RunLifeFor(days);
            return GetSum(amountOfLanternFishInSpecifiedLifeSpan);
        }

        public override object StarTwo()
        {
            int days = 256;
            ParseInput(_strInput);
            RunLifeFor(days);
            var sum = GetSum(amountOfLanternFishInSpecifiedLifeSpan);
            return sum;
        }

        private ulong GetSum(Dictionary<int, ulong> amountOfLanternFishInSpecifiedLifeSpan)
        {
            ulong sum = 0;
            for (int i = 0; i < amountOfLanternFishInSpecifiedLifeSpan.Count; i++)
            {
                sum += amountOfLanternFishInSpecifiedLifeSpan[i];
            }
            return sum;
        }

        private void RunLifeFor(int days)
        {
            for (int i = 0; i < days; i++)
            {
                ulong amountOfNewBorns = amountOfLanternFishInSpecifiedLifeSpan[0];
                for (int j = 1; j < amountOfLanternFishInSpecifiedLifeSpan.Count; j++)
                {
                    amountOfLanternFishInSpecifiedLifeSpan[j - 1] = amountOfLanternFishInSpecifiedLifeSpan[j];
                }
                amountOfLanternFishInSpecifiedLifeSpan[6] += amountOfNewBorns;
                amountOfLanternFishInSpecifiedLifeSpan[8] = amountOfNewBorns;
            }
        }
    }
}