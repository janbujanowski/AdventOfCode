using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{

    public class Day6 : Day66
    {
        string _strInput;
        string[] _lines;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }

        public override object StarOne()
        {
            return FindFirstMarker(_strInput);
        }
        private int FindFirstMarker(string input)
        {
            int marker = 0;
            for (int i = 3; i < input.Length; i++)
            {
                var lastfour = new List<char>() { input[i], input[i - 1], input[i - 2], input[i - 3] };
                if (lastfour.Count == lastfour.Distinct().Count())
                {
                    marker = i+1;
                    break;
                }
            }
            return marker;
        }
        private int FindFirstMarkerStarTwo(string input)
        {
            int marker = 0;
            for (int i = 13; i < input.Length; i++)
            {
                var lastfour = new List<char>();
                for (int j = i; j >= i-13; j--)
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
            return FindFirstMarkerStarTwo(_strInput);
        }
    }
}
