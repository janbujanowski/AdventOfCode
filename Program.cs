﻿using AdventOfCode2020;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCodeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //288 too low
            var stringInput = File.ReadAllText(@"C:\REPOS\Advent\AdventOfCode2020\inputs_2020\Day6.txt");
            var day = new Day6(stringInput);
            Console.WriteLine(day.StarOne(@""));
            Console.WriteLine(day.StarTwo(@""));

            //1242
            Console.ReadKey();
        }
    }
}
