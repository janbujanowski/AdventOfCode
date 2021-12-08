using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day8Extensions
    {
        public static string Without(this string source, string toRemove)
        {
            var newString = source.ToList();
            foreach (var letter in toRemove)
            {
                newString.Remove(letter);
            }
            return String.Concat(newString);
        }
        public static bool ContainsNumber(this string source, string toCheck)
        {
            int matchCount = 0;
            var newString = source.ToList();
            foreach (var letter in toCheck)
            {
                if (source.Contains(letter))
                {
                    matchCount++;
                }
            }
            return toCheck.Length == matchCount;
        }
    }
    public class Day8 : Day66
    {
        Dictionary<int, int> amountOfsubmarinesOnPositionKey;
        string _strInput;
        int _meanLower;
        int _linesCount;
        int _median;

        int[,] _signalInputsExamples;
        int[,] _signalOutputs;
        Dictionary<int, string[]> _leftSide;
        Dictionary<int, string[]> _rightSide;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;

            string[] lines = _strInput.Split("\r\n");
            _linesCount = lines.Length;
            _signalInputsExamples = new int[lines.Length, 10];
            _signalOutputs = new int[lines.Length, 4];
            _leftSide = new Dictionary<int, string[]>();
            _rightSide = new Dictionary<int, string[]>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(" | ");
                var leftRow = line[0].Split(" ").Select(number => String.Concat(number.OrderBy(letter => (int)letter))).ToArray();
                var rightRow = line[1].Split(" ").Select(number => String.Concat(number.OrderBy(letter => (int)letter))).ToArray();
                //.Select(numbAsString => numbAsString.OrderBy(letter => (int)letter)
                //order for easier debugging
                _leftSide.Add(i, leftRow);
                _rightSide.Add(i, rightRow);
            }
        }

        public override object StarOne()
        {
            int sum = 0;
            for (int i = 0; i < _leftSide.Count; i++)
            {
                Dictionary<string, int> numbersDefinitions = DefineNumbers(_leftSide[i].ToList());
                int rightNumber = GetRightNumber(_rightSide[i], numbersDefinitions);
                sum += rightNumber;
            }

            return sum;
        }

        private int GetRightNumber(string[] vs, Dictionary<string, int> numbersDefinitions)
        {
            int modifier = 1000;
            int sum = 0;
            for (int i = 0; i < vs.Length; i++)
            {
                sum += numbersDefinitions[vs[i]] * modifier;
                modifier = modifier / 10;
            }
            return sum;
        }

        private Dictionary<string, int> DefineNumbers(List<string> vs)
        {
            //identyify 1 4 7 8 by size
            string one = vs.Where(x => x.Length == 2).First();
            string four = vs.Where(x => x.Length == 4).First();
            string seven = vs.Where(x => x.Length == 3).First();
            string eight = vs.Where(x => x.Length == 7).First();
            vs.Remove(one);
            vs.Remove(four);
            vs.Remove(seven);
            vs.Remove(eight);
            //9 must contain 4
            string nine = vs.Where(numb => numb.ContainsNumber(four) && numb.Length == 6).FirstOrDefault();
            vs.Remove(nine);

            //6 same size as 9 but cointain 4 without 1
            string fourWithoutOne = four.Without(one);
            var trySix = vs.Where(numb => numb.Intersect(fourWithoutOne).Count() == 2 && numb.Length == nine.Length);
            string six = trySix.FirstOrDefault();
            vs.Remove(six);
            //0 same size as 9 but dont have full 4
            string zero = vs.Where(numb => numb.Length == nine.Length).FirstOrDefault();
            //5 must contain 4 without 1
            string five = vs.Where(numb => numb.Length == 5 && numb.ContainsNumber(fourWithoutOne)).FirstOrDefault();
            vs.Remove(five);
            //3 must contain 1
            string three = vs.Where(numb => numb.Length == 5 && numb.ContainsNumber(one)).FirstOrDefault();
            //2 remaining size 5
            vs.Remove(three);
            string two = vs.Where(numb => numb.Length == 5).FirstOrDefault();

            return new Dictionary<string, int>()
            {
                { zero , 0 },
                { one , 1 },
                { two , 2 },
                { three , 3 },
                { four , 4 },
                { five , 5 },
                { six , 6 },
                { seven , 7 },
                { eight , 8 },
                { nine , 9 }
            };
        }
        private string[] _workingDefinitions;

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
