using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
   
    public class Day14 : Day66
    {
        string _strInput;
        string[] _lines;
        Dictionary<string, char> _transformationDict;
        string _startString;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");
            _startString = _lines[0];
            _transformationDict = new Dictionary<string, char>();
            for (int i = 2; i < _lines.Length; i++)
            {
                string[] lineTrans = _lines[i].Split(" -> ");
                _transformationDict.Add(lineTrans[0], lineTrans[1][0]);
            }
        }
        public override object StarOne()
        {
            int stepsCount = 10;
            Console.WriteLine(_startString);
            for (int i = 0; i < stepsCount; i++)
            {
                _startString = ApplyTransformationStepPartOneMethod(_startString);
                //Console.WriteLine(_startString);
            }
            var grouped = _startString.GroupBy(x => x);

            var maxVal = grouped.Max(x => x.Count());
            var minVal = grouped.Min(x => x.Count());
            return maxVal - minVal;
        }

        private string ApplyTransformationStepPartOneMethod(string startString)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < startString.Length - 1; i++)
            {
                builder.Append(startString[i]);
                builder.Append(_transformationDict[$"{startString[i]}{startString[i + 1]}"]);
            }
            builder.Append(startString[startString.Length - 1]);
            return builder.ToString();
        }
       

        Dictionary<char, int> _charCount;
        public override object StarTwo()
        {
            //GenerateCharCounter();
            int stepsCount = 10;
            ParseInput(_strInput);
            //ExtendPolymer(_startString, stepsCount);

            //var maxVal = _charCount.Max(x => x.Value);
            //var minVal = _charCount.Min(x => x.Value);
            //return maxVal - minVal;

            return OtherApproach();
        }

        private void ExtendPolymer(string startString, int stepsCount)
        {
            int maxStepsCount = stepsCount;
            int currentStepCounter = 0;
            foreach (char letter in startString)
            {
                _charCount[letter]++;
            }
            for (int i = 0; i < startString.Length - 1; i++)
            {
                ExtendCharsAndBumpCounter(startString[i], startString[i + 1], currentStepCounter, maxStepsCount);
            }
        }

        private void ExtendCharsAndBumpCounter(char v1, char v2, int currentStepCounter, int maxStepsCount)
        {
            if (currentStepCounter < maxStepsCount)
            {
                char newMidChar = _transformationDict[$"{v1}{v2}"];
                currentStepCounter++;
                _charCount[newMidChar]++;
                ExtendCharsAndBumpCounter(v1, newMidChar, currentStepCounter, maxStepsCount);
                ExtendCharsAndBumpCounter(newMidChar, v2, currentStepCounter, maxStepsCount);
            }
        }

        private void GenerateCharCounter()
        {
            _charCount = new Dictionary<char, int>();
            foreach (char letter in _startString)
            {
                if (!_charCount.ContainsKey(letter))
                {
                    _charCount.Add(letter, 0);
                }
            }
            foreach (var pair in _transformationDict)
            {
                if (!_charCount.ContainsKey(pair.Value))
                {
                    _charCount.Add(pair.Value, 0);
                }
            }
        }

        //------------------------------------------------------------------- c'est pas moi
        public void Setup()
        {
            var inputLines = _strInput.Split("\r\n").ToList();
            sInput = inputLines.First();
            insertionRules = new Dictionary<string, string>();
            foreach (var rule in inputLines.Skip(2))
            {
                var lr = rule.Split(" -> ");
                insertionRules[lr[0]] = lr[1];
            }
        }

        static string sInput;
        static Dictionary<string, string> insertionRules;
        private long OtherApproach()
        {
            Setup();
            // Going to need to store the 'problem' as a dict of letterpair -> occurrences, e.g HH -> 4545, and single letter frequencies 
            // Applying a 'step occurrence' for each of the existing rules just ups a single letter frequency, removes one letterpair occurrence and adds two 
            // letterpair occurrences.

            var letterpairs = new Dictionary<string, long>();
            var singleletters = new Dictionary<string, long>(); // char more efficient but less readable code

            foreach (var c in sInput)
                singleletters.DictIncrement(c.ToString());

            for (var i = 0; i < sInput.Length - 1; i++)
                letterpairs.DictIncrement(sInput.Substring(i, 2));

            var steps = 40;
            var ruleHits = new Dictionary<string, long>();

            for (var i = 0; i < steps; i++)
            {
                ruleHits.Clear();

                foreach (var r in letterpairs.Keys)
                {
                    if (insertionRules[r] != null) // Rule match on this pair. How many? As many insertions as current occurrences!
                    {
                        ruleHits.DictIncrement(r, letterpairs[r]);
                    }
                }

                // Apply all the rule hits
                foreach (var ruleHit in ruleHits)
                {
                    //ruleHit.Key // e.g. AB, ruleHit.Value- 39 - 39 occurrences
                    var insertedChar = insertionRules[ruleHit.Key];
                    // Num of inserted letter goes up by rule hit count
                    singleletters.DictIncrement(insertedChar, ruleHit.Value);
                    // Rule hit pair drops by the count as that pair is now split
                    letterpairs.DictIncrement(ruleHit.Key, -ruleHit.Value);
                    // Two new pairs formed by inserting the new char
                    var left = ruleHit.Key.Substring(0, 1) + insertionRules[ruleHit.Key];
                    var right = insertionRules[ruleHit.Key] + ruleHit.Key.Substring(1, 1);
                    letterpairs.DictIncrement(left, ruleHit.Value);
                    letterpairs.DictIncrement(right, ruleHit.Value);
                }

            }
            var most = singleletters.OrderByDescending(s => s.Value).First();
            var least = singleletters.OrderBy(s => s.Value).First();
            Console.WriteLine($"Day 14(2): Most is {most.Key} ({most.Value}), least is {least.Key} ({least.Value}), difference is {most.Value - least.Value}.");
            return most.Value - least.Value;
        }
    }
    public static class Day14Helpers
    {
        public static void DictIncrement<T>(this Dictionary<T, long> d, T key, long num = 1)
        {
            if (d.Keys.Contains(key)) d[key] += num;
            else d[key] = num;
        }
        public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
        {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + 1); // Not 'minIndex + searchstring.Length' - misses matches like 'BB' in 'BBB' - 2 matches
            }
        }
    }
}