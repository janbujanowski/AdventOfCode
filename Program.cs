﻿using AdventOfCode.Shared;
using AdventOfCode2020;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCodeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //LOAD riddles solutions

            List<Day66> solutionContainer = new List<Day66>();
            Type requiredType = typeof(Day66);

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();
            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));

            foreach (var assembly in loadedAssemblies)
            {
                var classes = assembly.GetTypes().Where(ass => ass.IsSubclassOf(requiredType));
                foreach (var type in classes)
                {
                    solutionContainer.Add((Day66)Activator.CreateInstance(type));
                }

            }

            //Execution
            int year = 2020;
            int day = 11;

            var wokringDay = solutionContainer.First(riddleSolution => riddleSolution.DayNumber == day && riddleSolution.YearNumber == year);
            if (wokringDay != null)
            {
                var strInput = GetDayInput(year, day);
                wokringDay.ParseInput(strInput);
                Console.WriteLine($"Day : {day}");
                Console.WriteLine($"Star one result: {wokringDay.StarOne()}");
                Console.WriteLine($"Star two result: {wokringDay.StarTwo()}");
            }

            Console.ReadKey();
        }
        public static string GetDayInput(int year, int day)
        {
            return File.ReadAllText($@"C:\REPOS\AdventOfCode\AdventOfCode2020\inputs_2020\Day{day}.txt");
        }

    }
}
