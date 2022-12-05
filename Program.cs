using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

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
            int year = 2022;
            int day = 4;

            var workingDay = solutionContainer.First(riddleSolution => riddleSolution.DayNumber == day && riddleSolution.YearNumber == year);
            if (workingDay != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                Console.WriteLine($"Day : {day}");
                
                var strInput = GetDayInput(year, day);
                
                stopwatch.Start();
                workingDay.ParseInput(strInput);
                stopwatch.Stop();
                Console.WriteLine($"Parsing input took : {stopwatch.ElapsedTicks} ticks");

                stopwatch.Restart();
                var result = workingDay.StarOne();
                stopwatch.Stop();
                Console.WriteLine($"Star one result: {result}");
                Console.WriteLine($"It took {stopwatch.ElapsedTicks} ticks to run.");
                
                stopwatch.Restart();
                result = workingDay.StarTwo();
                stopwatch.Stop();
                Console.WriteLine($"Star two result: {result}");
                Console.WriteLine($"It took {stopwatch.ElapsedTicks} ticks to run.");
            }

            Console.ReadKey();
        }
        public static string GetDayInput(int year, int day)
        {
            return File.ReadAllText($@"C:\REPOS\aoc\AdventOfCode{year}\inputs_{year}\Day{day}.txt");
        }

    }
}
