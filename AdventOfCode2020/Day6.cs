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
    public class Day6 : IDayX
    {
        string[] groups;
        int[] seatsIDs;

        public int DayNumber()
        {
            return 6;
        }
        public Day6(string strInput)
        {
            groups = strInput.Split("\r\n\r\n");
        }

        public object StarOne(string strInput)
        {
            return groups.ToList().Select(group => group.Replace("\r\n", "").Distinct().Count()).Sum();
        }
        
        public object StarTwo(string strInput)
        {
            var sums = new List<int>();
            foreach (var group in groups)
            {
                var personsCount = group.Split("\r\n").Count();
                var lettersOrderedInput = group.Replace("\r\n", "").OrderBy(letter => letter).ToArray();
                char current = 'A';
                int counter = 0;
                int sum = 0;
                for (int i = 0; i < lettersOrderedInput.Length; i++)
                {
                    if (current == lettersOrderedInput[i])
                    {
                        counter++;
                    }
                    else
                    {
                        current = lettersOrderedInput[i];
                        if (counter == personsCount)
                        {
                            sum += 1;
                        }
                        counter = 1;
                    }
                }
                //3025 too low
                sums.Add(sum);
            }
            return sums.Sum();
        }
        
    }
}
