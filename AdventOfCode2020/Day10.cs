using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Node
    {
        public int value { get; set; }
        public override string ToString()
        {
            return value.ToString();
        }
    }
    class Edge
    {
        public int from { get; set; }
        public int to { get; set; }
        public bool counted { get; set; }
        public override string ToString()
        {
            return $"from {from} to {to} {counted}";
        }
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
        List<Edge> edges;
        List<int>[] adj;


        public override object StarTwo()
        {
            //int permutationsCount = 1;
            //int nextPossibilitiesCount = 0;
            //var maxes = inputNumbers.ToList();
            //maxes.Add(inputNumbers[inputNumbers.Length - 1] + 3);

            List<int> maxDifference = new List<int>() { 1, 2, 3 };
            List<Node> nodes = new List<Node>();
            edges = new List<Edge>();
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                nodes.Add(new Node() { value = inputNumbers[i] });
            }
            nodes.Add(new Node() { value = inputNumbers[inputNumbers.Length - 1] + 3 });
            adj = new List<int>[nodes.Last().value + 1];
            foreach (var node in nodes)
            {
                var connectibleTo = nodes.Where(possibility => maxDifference.Contains(possibility.value - node.value));

                edges.AddRange(connectibleTo.Select(possible => new Edge() { from = node.value, to = possible.value, counted = false }));
                adj[node.value] = connectibleTo.Select(x => x.value).ToList();
            }
            foreach (var node in nodes)
            {

            }
            int pathCount = 0;
            int countPaths = countPathsUtil(0, nodes.Last().value + 1, pathCount);
            int firstRun = 1;
            int fromNode = 0;


            do
            {
                int toNode = edges.Where(x => x.from == fromNode).Max(y => y.to);
                edges.Where(x => x.from == fromNode && x.to == toNode).First().counted = true;
                fromNode = toNode;

            } while (fromNode != nodes.Last().value);
            var remaining = edges.Where(x => x.counted == false).Count();
            return remaining + 1;
        }

        int countPathsUtil(int u, int d, int pathCount)
        {
            if (u == d)
            {
                pathCount++;
            }
            else
            {
                foreach (int i in adj[u])
                {
                    int n = i;
                    pathCount = countPathsUtil(n, d, pathCount);
                }
            }

            return pathCount;
        }
        //private int CheckConnectionPossibilities(int i)
        //{
        //    List<int> maxDifference = new List<int>() { 1, 2, 3 };
        //    List<int> nextPossibilites = new List<int>();
        //    int possibleConn = 1;

        //    for (int j = 1; j <= 3; j++)
        //    {
        //        if (i - j >= 0)
        //        {
        //            if (maxDifference.Contains(inputNumbers[i] - inputNumbers[i - j]))
        //            {
        //                nextPossibilites.Add(i - j);
        //                //possibleConn++;
        //            }
        //        }
        //    }

        //    if (nextPossibilites.Count == 0)
        //    {
        //        bool chainDoesntEndOnZero = inputNumbers[i] != 0;
        //        if (chainDoesntEndOnZero)
        //        {
        //            return 0;
        //        }
        //    }

        //    foreach (var next in nextPossibilites)
        //    {
        //        possibleConn += CheckConnectionPossibilities(next);
        //    }

        //    return possibleConn;
        //}
    }
}
