using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day3 : Day66
    {
        string[] lines;
        Dictionary<char, int> _charsPriority = new Dictionary<char, int>() {
          
        };
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            int startChar_a = 97;
            for (int i = 1; i <= 26; i++)
            {
                _charsPriority.Add((char)startChar_a, i);
                startChar_a++;
            }
            startChar_a = 65;
            for (int i = 27; i <= 52; i++)
            {
                _charsPriority.Add((char)startChar_a, i);
                startChar_a++;
            }
        }

        public override object StarOne()
        {
            List<char> itemTypesInCompartments = new List<char>();
            for (int i = 0; i < lines.Length; i++)
            {
                string rucksack = lines[i];
                int secondCompartmentStartIndex = rucksack.Length / 2;
                var left = rucksack.Take(secondCompartmentStartIndex);
                var right = rucksack.Skip(secondCompartmentStartIndex);
                var mutual = left.Intersect(right);
                itemTypesInCompartments.Add(mutual.ElementAt(0));


            }
            var sum = itemTypesInCompartments.Select(x => _charsPriority[x]).Sum();
            return sum;
        }


        public override object StarTwo()
        {
            List<char> itemTypesInCompartments = new List<char>();
            for (int i = 0; i < lines.Length; i += 3)
            {
                var rucksack = lines[i].Intersect(lines[i + 1]).Intersect(lines[i+2]);
                itemTypesInCompartments.AddRange(rucksack);

            }
            var sum = itemTypesInCompartments.Select(x => _charsPriority[x]).Sum();
            return sum;
        }

    }
}
