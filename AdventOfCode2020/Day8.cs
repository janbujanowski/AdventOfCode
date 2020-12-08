using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day8 : IDayX
    {
        List<KeyValuePair<string, int>> instructions;

        string mainSplitter = " ";

        public int DayNumber()
        {
            return 8;
        }
        public Day8(string strInput)
        {
            instructions = strInput.Split("\n").Select(definition => new KeyValuePair<string, int>(
                definition.Split(mainSplitter)[0], int.Parse(definition.Split(mainSplitter)[1])))
                .ToList();
        }

        public object StarOne(string strInput)
        {
            //3764 too high
            int[] executionCounter = new int[instructions.Count];
            bool stopWhenExecutedTwice = false;
            int i = 0;
            int accumulator = 0;
            int nexti = 0;
            while (!stopWhenExecutedTwice)
            {
                var instruction = instructions[i % instructions.Count];
                executionCounter[i] += 1;
                if (executionCounter[i] == 2)
                {
                    stopWhenExecutedTwice = true;
                }
                else
                {
                    switch (instruction.Key)
                    {
                        case "nop":
                            nexti = i + 1;
                            break;
                        case "jmp":
                            nexti = i + instruction.Value;
                            break;
                        case "acc":
                            accumulator += instruction.Value;
                            nexti = i + 1;
                            break;
                        default:
                            break;
                    }
                    i = nexti;
                }
            }
            return accumulator;
        }

        public object StarTwo(string strInput)
        {
            return null;
        }
    }
}
