using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day8 : IDayX
    {
        List<KeyValuePair<string, int>> initialInstructions;

        string mainSplitter = " ";

        public int DayNumber()
        {
            return 8;
        }
        public Day8(string strInput)
        {
            initialInstructions = strInput.Split("\n").Select(definition => new KeyValuePair<string, int>(
                definition.Split(mainSplitter)[0], int.Parse(definition.Split(mainSplitter)[1])))
                .ToList();
        }

        public object StarOne(string strInput)
        {
            //1915
            int[] executionCounter = new int[initialInstructions.Count];
            return ExecuteProgram(executionCounter, initialInstructions);
        }

        private int ExecuteProgram(int[] executionCounter, List<KeyValuePair<string, int>> instructions)
        {
            bool stopWhenExecutedTwiceOrIsLastLine = false;
            int i = 0;
            int accumulator = 0;
            int nexti = 0;
            while (!stopWhenExecutedTwiceOrIsLastLine)
            {
                var instruction = instructions[i % instructions.Count];
                executionCounter[i] += 1;
                if (executionCounter[i] == 2 || i % instructions.Count == instructions.Count - 1)
                {
                    stopWhenExecutedTwiceOrIsLastLine = true;
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
            //944
            int accumulator = 0;
            for (int i = 0; i < initialInstructions.Count; i++)
            {
                var newInstructions = initialInstructions.ConvertAll(instruction => new KeyValuePair<string, int>(instruction.Key, instruction.Value));
                if (newInstructions[i].Key == "jmp")
                {
                    newInstructions[i] = new KeyValuePair<string, int>("nop", newInstructions[i].Value);
                }else if (newInstructions[i].Key == "nop")
                {
                    newInstructions[i] = new KeyValuePair<string, int>("jmp", newInstructions[i].Value);
                }
                int[] executionCounter = new int[initialInstructions.Count];
                accumulator = ExecuteProgram(executionCounter, newInstructions);
                if (executionCounter[initialInstructions.Count - 1] == 1)
                {
                    break;
                }
            }
            return accumulator;
        }
    }
}
