using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{

    public class Day10 : Day66
    {
        string _strInput;
        Dictionary<char, int> _lineStack;

        List<char> _pushingChars = new List<char> { '{', '[', '<', '(' };
        List<char> _poopingChars = new List<char> { '}', ']', '>', ')' };
        Dictionary<char, char> _poopingDick = new Dictionary<char, char>() { { '}', '{' }, { ']', '[' }, { '>', '<' }, { ')', '(' } };
        Dictionary<char, char> _pushingDick = new Dictionary<char, char>() { { '{', '}' }, { '[', ']' }, { '<', '>' }, { '(', ')' } };
        Dictionary<char, int> _charValues = new Dictionary<char, int>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
        string[] _lines;

        Dictionary<int, char> _firstInvalidCharInLine;

        Dictionary<int, string> _incompleteLinesClosingSequence;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");
        }

        private void ClearLineStack()
        {
            _lineStack = new Dictionary<char, int>();
        }

        public override object StarOne()
        {
            _firstInvalidCharInLine = new Dictionary<int, char>();
            for (int lineNumber = 0; lineNumber < _lines.Length; lineNumber++)
            {
                string line = _lines[lineNumber];
                List<char> localStack = new List<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    bool popSucceeded = false;
                    if (_pushingChars.Contains(line[i]))
                    {
                        Push(localStack, line[i]);
                    }
                    if (_poopingChars.Contains(line[i]))
                    {
                        popSucceeded = Pop(localStack, line[i]);
                        if (!popSucceeded)
                        {
                            _firstInvalidCharInLine.Add(lineNumber, line[i]);
                            break;
                        }
                    }
                }
            }

            int sum = 0;
            foreach (var invalidChar in _firstInvalidCharInLine)
            {
                sum += _charValues[invalidChar.Value];
            }


            return sum;
        }

        private bool Pop(List<char> localStack, char v)
        {
            if (localStack.Last() == _poopingDick[v])
            {
                localStack.RemoveAt(localStack.Count - 1);
                return true;
            }
            return false;
        }

        private void Push(List<char> localStack, char v)
        {
            localStack.Add(v);
        }

        public override object StarTwo()
        {
            _incompleteLinesClosingSequence = new Dictionary<int, string>();
            if (!_firstInvalidCharInLine.Any())
            {
                StarOne();
            }

            for (int lineNumber = 0; lineNumber < _lines.Length; lineNumber++)
            {
                bool currentLineIsIncomplete = !_firstInvalidCharInLine.ContainsKey(lineNumber);
                if (currentLineIsIncomplete)
                {
                    //TODO - make a cool method from this
                    string line = _lines[lineNumber];
                    List<char> localStack = new List<char>();
                    for (int i = 0; i < line.Length; i++)
                    {
                        bool popSucceeded = false;
                        if (_pushingChars.Contains(line[i]))
                        {
                            Push(localStack, line[i]);
                        }
                        if (_poopingChars.Contains(line[i]))
                        {
                            popSucceeded = Pop(localStack, line[i]);
                            if (!popSucceeded)
                            {
                                _firstInvalidCharInLine.Add(lineNumber, line[i]);
                                break;
                            }
                        }
                    }

                }
            }
            return 1;
        }

    }
}
