using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day6 : IDayX
    {
        string[] groups;

        public int DayNumber()
        {
            return 6;
        }
        public Day6(string strInput)
        {
            groups = strInput.Split("\n\n");
        }

        public object StarOne(string strInput)
        {
            return groups.ToList().Select(group => group.Replace("\n", "").Distinct().Count()).Sum();
        }

        public object StarTwo(string strInput)
        {
            int sum = 0;
            foreach (var group in groups)
            {
                var personsCount = group.Split("\n").Count();
                var lettersOrderedInput = group.Replace("\n", "").OrderBy(letter => letter).ToArray();
                char current = 'A';
                int counter = 0;
                
                for (int i = 0; i < lettersOrderedInput.Length; i++)
                {
                    if (current == lettersOrderedInput[i])
                    {
                        counter++;
                    }
                    else
                    {
                        current = lettersOrderedInput[i];
                        counter = 1;
                    }

                    if (counter == personsCount)
                    {
                        sum += 1;
                    }
                }
            }
            return sum;
        }
    }
}
