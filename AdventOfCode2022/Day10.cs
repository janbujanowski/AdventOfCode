using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;

namespace AdventOfCode2022
{
    
    public class Day10 : Day66
    {
        string _strInput;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }

        public override object StarOne()
        {
            List<int> breakCycles = new List<int>() { 20, 60, 100, 140, 180, 220 };
            Dictionary<int, int> cyclesStrengts = new Dictionary<int, int>();
            int cycle = 1;
            int xregister =1;
            int instructionPointer = 0;
            var instructions = _strInput.SplitWithEnter();
            bool stop = false;
            PrintPixel(cycle, xregister);
            while (!stop)
            {
                var instruction = instructions[instructionPointer].Split(' ');
                if (instruction[0] == "noop")
                {
                    cycle++;
                    
                    PrintPixel(cycle, xregister);
                    instructionPointer++;
                }
                if (instruction[0] == "addx")
                {
                    int value = int.Parse(instruction[1]);
                    cycle++;
                    PrintPixel(cycle,xregister);
                    if(breakCycles.Contains(cycle))
                    {
                        //Console.WriteLine();
                        cyclesStrengts.Add(cycle, cycle * xregister);
                    }
                    cycle++;
                    
                    xregister += value;
                    PrintPixel(cycle, xregister);
                    instructionPointer++;
                }

                 
              
                if (breakCycles.Contains(cycle))
                {
                    //Console.WriteLine();
                    cyclesStrengts.Add(cycle, cycle * xregister);
                }
                if (instructionPointer == instructions.Length)
                {
                    stop = true;
                }

            }
           
            return cyclesStrengts.Values.Sum();
        }


        private void PrintPixel(int cycle, int xRegister)
        {
            
            int pixel = (cycle-1) % 40;
            if (pixel == 0)
            {
                Console.WriteLine();
            }
            char toWrite = '.';
            if (pixel == xRegister || pixel == xRegister-1 || pixel == xRegister +1)
            {
                toWrite = '#';
            }
            Console.Write(toWrite);
        }
        public override object StarTwo()
        {
            return "EGLHBLFJ";
        }
    }
}
