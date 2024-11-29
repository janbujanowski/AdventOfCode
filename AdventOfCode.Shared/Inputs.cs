using System.IO;

namespace AdventOfCode.Shared
{
    public static class Inputs
    {
        static string homeDirectory = @"C:\GIT\aoc";
        public static string GetDayInput(int year, int day)
        {
            return File.ReadAllText($@"{homeDirectory}\AdventOfCode{year}\inputs_{year}\Day{day}.txt");
        }
        public static string GetSpecificFileNameFromInputs(int year, int day,string fileName)
        {
            return File.ReadAllText($@"{homeDirectory}\AdventOfCode{year}\inputs_{year}\{fileName}");
        }
    }
}
