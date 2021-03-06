﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string[] Split(this string input, string delimiter)
        {
            string[] separators = new string[] { delimiter };
            string[] lines = input.Split(separators, StringSplitOptions.None);
            return lines;
        }
    }
}
