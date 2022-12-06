using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{

    public class Day6 : Day66
    {
        string _strInput;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }

        public override object StarOne()
        {
            return FindFirstMarker(_strInput,4);
        }
       
        private int FindFirstMarker(string input,int amountOfCharsToValidate)
        {
            int marker = 0;
            var startIndex = amountOfCharsToValidate - 1;
            for (int i = startIndex; i < input.Length; i++)
            {
                var lastfour = new List<char>();
                for (int j = i; j >= i- startIndex; j--)
                {
                    lastfour.Add(input[j]);
                }
                if (lastfour.Count == lastfour.Distinct().Count())
                {
                    marker = i + 1;
                    break;
                }
            }
            return marker;
        }

        public override object StarTwo()
        {
            return FindFirstMarker(_strInput,14);
        }
    }
}
