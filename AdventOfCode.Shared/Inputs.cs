using System.IO;

namespace AdventOfCode.Shared
{
    public static class Inputs
    {
        static string homeDirectory = @"C:\REPOS\aoc";
        public static string GetDayInput(int year, int day)
        {
            return File.ReadAllText($@"{homeDirectory}\AdventOfCode{year}\inputs_{year}\Day{day}.txt");
        }
    }
}
