using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public class Day8 : Day66
    {
        enum Instruction
        {
            Unknown,
            Left = 'L',
            Right = 'R'
        }
        string[] _lines;
        Instruction[] _instructions;
        class CamelMapNode
        {
            public string Right;
            public string Left;
        }
        Dictionary<string, CamelMapNode> _mapNodes;
        public override void ParseInput(string strInput)
        {
            _lines = strInput.Split("\r\n");
            _instructions = _lines[0].Select(instruction => (Instruction)Convert.ToInt32(instruction)).ToArray();

            _mapNodes = ParseMap(_lines);
           
        }

        private Dictionary<string, CamelMapNode> ParseMap(string[] lines)
        {
            Dictionary<string, CamelMapNode> newMap = new Dictionary<string, CamelMapNode>();
            int i = 2;
            while (i < _lines.Length)
            {
                var line = _lines[i].Replace(" ","").Replace("(","").Replace(")", "");
                var key = line.Split('=')[0];
                var left = line.Split('=')[1].Split(',')[0];
                var right = line.Split('=')[1].Split(',')[1];
                newMap.Add(key, new CamelMapNode() { Left = left, Right = right });
                i++;
            }
            return newMap;
        }

        public override object StarOne()
        {
            string endOfMap = "ZZZ";
            int steps = 0;
            string currentNode = "AAA";
            while (currentNode != endOfMap)
            {
                currentNode = GetNext(_instructions[steps % _instructions.Length], currentNode);
                steps++;
            }

            return steps;
        }

        private string GetNext(Instruction instruction, string currentNode)
        {
            var current = _mapNodes[currentNode];
            if (instruction == Instruction.Left)
            {
                return current.Left;
            }
            else
            {
                return current.Right;
            }
        }

        public override object StarTwo()
        {
           

            return 1;
        }
    }
}