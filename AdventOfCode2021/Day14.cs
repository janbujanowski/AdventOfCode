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
        int _flashes;
        List<Edge> _edges;
        List<Tuple<int, int>> _points;
        List<Tuple<bool, int>> _splits;
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
                _startString = ApplyTransformationStep(_startString);
                //Console.WriteLine(_startString);
            }
            var grouped = _startString.GroupBy(x => x);

            var maxVal = grouped.Max(x => x.Count());
            var minVal = grouped.Min(x => x.Count());
            return maxVal - minVal;
        }

        private string ApplyTransformationStep(string startString)
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
            GenerateCharCounter();
            int stepsCount = 40;
            ParseInput(_strInput);
            ExtendPolymer(_startString, stepsCount);
            
            var maxVal = _charCount.Max(x => x.Value);
            var minVal = _charCount.Min(x => x.Value);
            return maxVal - minVal;
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
                    _charCount.Add(pair.Value,0);
                }
            }
        }
    }
}