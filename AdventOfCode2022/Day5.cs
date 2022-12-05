using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Storage
    {
        public Dictionary<int, Stack<char>> _shelves;
    }
    public class Operation
    {
        public int Amount;
        public int From;
        public int To;
    }
    public class Day5 : Day66
    {
        string _strInput;
        string[] _lines;

        Storage _storage;
        List<Operation> _operations;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");
        }

        private void ConvertInput()
        {
            _storage = new Storage();
            int starti = FindStartingIndex(_lines);
            _storage._shelves = FillShelves(_lines[starti], starti);
            _operations = FillOperations(starti);
        }
        private int FindStartingIndex(string[] lines)
        {
            int i = 0;
            while (i < lines.Length)
            {
                if (lines[i][1] == '1')
                    return i;
                i++;
            }
            return i;
        }

        private Dictionary<int, Stack<char>> FillShelves(string line, int row)
        {
            Dictionary<int, Stack<char>> shelves = new Dictionary<int, Stack<char>>();
            for (int column = 0; column < line.Length; column++)
            {
                int shelveKey = 0;
                if (int.TryParse(line[column].ToString(), out shelveKey))
                {
                    Stack<char> stack = GetStack(_lines, column, row);
                    shelves[shelveKey] = stack;
                }
            };
            return shelves;
        }

        private Stack<char> GetStack(string[] lines, int column, int row)
        {
            Stack<char> stack = new Stack<char>();
            for (int j = row - 1; j >= 0; j--)
            {
                char crate = lines[j][column];
                if (crate != ' ')
                    stack.Push(crate);
            };
            return stack;
        }
        private List<Operation> FillOperations(int starti)
        {
            List<Operation> operations = new List<Operation>();
            for (int i = starti + 2; i < _lines.Length; i++)
            {
                var line = _lines[i].Split(' ');
                operations.Add(new Operation()
                {
                    Amount = Convert.ToInt32(line[1]),
                    From = Convert.ToInt32(line[3]),
                    To = Convert.ToInt32(line[5])
                });
            }
            return operations;
        }

        public override object StarOne()
        {
            int sum = 0;
            ConvertInput();
            foreach (var operation in _operations)
            {
                ExecuteOperationCrateMover9000(operation, _storage);
            }

            return GetTopCrates(_storage);
        }

        private string GetTopCrates(Storage storage)
        {
            List<char> topCrates = new List<char>();
            foreach (var stack in storage._shelves)
            {
                topCrates.Add(stack.Value.Pop());
            }
            return String.Join("", topCrates);
        }

        private void ExecuteOperationCrateMover9000(Operation operation, Storage storage)
        {
            for (int i = 0; i < operation.Amount; i++)
            {
                var crate = storage._shelves[operation.From].Pop();
                storage._shelves[operation.To].Push(crate);
            }
        }
        public override object StarTwo()
        {
            ConvertInput();
            foreach (var operation in _operations)
            {
                ExecuteOperationCrateMover9001(operation, _storage);
            }

            return GetTopCrates(_storage); ;
        }
        private void ExecuteOperationCrateMover9001(Operation operation, Storage storage)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < operation.Amount; i++)
            {
                var crate = storage._shelves[operation.From].Pop();
                stack.Push(crate);
            }
            foreach (var crate in stack)
            {
                storage._shelves[operation.To].Push(crate);
            }
        }
       
    }
}
