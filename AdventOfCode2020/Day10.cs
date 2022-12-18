using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Adapter
    {
        public Adapter(int jolt)
        {
            Jolt = jolt;
            ConnectableAdapters = new List<Adapter>();
        }
        public int Jolt;
        public List<Adapter> ConnectableAdapters;
        public void AddConnectableAdapters(int[] availableAdapter)
        {
            foreach (var adapter in availableAdapter)
            {
                if (AdapterExtensions.acceptableDifferences.Contains(adapter - Jolt))
                {
                    Adapter connectableAdapter = new Adapter(adapter);
                    connectableAdapter.AddConnectableAdapters(availableAdapter);
                    ConnectableAdapters.Add(connectableAdapter);
                }
            }
        }
        public long Cunt()
        {
            long cunt = 1;
            foreach (var adapter in ConnectableAdapters)
            {
                cunt = cunt * adapter.Cunt();
            }
            if (ConnectableAdapters.Count > 0)
            {
                cunt = cunt * ConnectableAdapters.Count;
            }
            return cunt;
        }
    }
    public static class AdapterExtensions
    {
        public static List<int> acceptableDifferences = new List<int>() { 1, 2, 3 };
    }
    public class Day10 : Day66
    {
        int[] inputNumbers;

        public override void ParseInput(string strInput)
        {
            strInput += "\r\n0";//add output 0 voltage
            inputNumbers = strInput.Split("\n").Select(number => int.Parse(number)).ToArray();
        }
        public override object StarOne()
        {
            //2059
            int[] joltDifferencesCount = new int[4];
            Array.Sort(inputNumbers);
            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                var difference = inputNumbers[i + 1] - inputNumbers[i];
                joltDifferencesCount[difference]++;
            }
            joltDifferencesCount[3]++;

            return joltDifferencesCount[1] * joltDifferencesCount[3];
        }



        public override object StarTwo()
        {
            Adapter input = new Adapter(0);
            input.AddConnectableAdapters(inputNumbers);

            return input.Cunt();
        }


    }
}
