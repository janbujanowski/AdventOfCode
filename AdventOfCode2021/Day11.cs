using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{

    public class Day11 : Day66
    {
        string _strInput;
        Dictionary<char, int> _lineStack;

        List<char> _pushingChars = new List<char> { '{', '[', '<', '(' };
        List<char> _poopingChars = new List<char> { '}', ']', '>', ')' };
        Dictionary<char, char> _poopingDick = new Dictionary<char, char>() { { '}', '{' }, { ']', '[' }, { '>', '<' }, { ')', '(' } };
        Dictionary<char, char> _pushingDick = new Dictionary<char, char>() { { '{', '}' }, { '[', ']' }, { '<', '>' }, { '(', ')' } };
        Dictionary<char, int> _charValues = new Dictionary<char, int>()
        { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 },
          { '(', 1 }, { '[', 2 }, { '{', 3 }, { '<', 4 }
        };
        string[] _lines;

        Dictionary<int, char> _firstInvalidCharInLine;

        Dictionary<int, string> _incompleteLinesClosingSequence;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");
        }
        public override object StarOne()
        {
            int sum = 0;
         
            return sum;
        }
        public override object StarTwo()
        {

            return -1;
        }
    }
}
