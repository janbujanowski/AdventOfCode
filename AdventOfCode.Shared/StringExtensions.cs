using System;

namespace AdventOfCode.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string[] SplitWithEnter(this string input)
        {
            string[] separators = new string[] { "\r\n"};
            string[] lines = input.Split(separators, StringSplitOptions.None);
            return lines;
        }

        public static string[] Split(this string input, string delimiter)
        {
            string[] separators = new string[] { delimiter };
            string[] lines = input.Split(separators, StringSplitOptions.None);
            return lines;
        }
        public static string RemoveInstances(this string input, params string[] charsToRemove)
        {
            foreach (string unnecesary in charsToRemove)
            {
                input = input.Replace(unnecesary, "");
            }
           
            return input;
        }
    }
}
