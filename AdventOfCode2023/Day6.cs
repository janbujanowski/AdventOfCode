using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day6 : Day66
    {
        string[] _lines;
        int[] _times;
        int[] _distances;

        public override void ParseInput(string strInput)
        {
            _lines = strInput.Split("\r\n");
            _times = Regex.Matches(_lines[0], @"\d+").Cast<Match>().Select(match => int.Parse(match.Value)).ToArray();
            _distances = Regex.Matches(_lines[1], @"\d+").Cast<Match>().Select(match => int.Parse(match.Value)).ToArray();
        }

        public override object StarOne()
        {
            List<int> possibleTimes = new List<int>();
            for (int i = 0; i < _times.Length; i++)
            {
                int raceMaxTime = _times[i];
                int raceDistance = _distances[i];
                int minimumTime = 0;
                while (minimumTime * (raceMaxTime - minimumTime) <= raceDistance)
                {
                    minimumTime++;
                }

                int maximumTime = raceMaxTime;

                while (maximumTime * (raceMaxTime - maximumTime) <= raceDistance)
                {
                    maximumTime--;
                }
                possibleTimes.Add(1 + maximumTime - minimumTime);
            }
            return possibleTimes.Aggregate(1, (x, y) => x *= y);
        }


        public override object StarTwo()
        {
            ulong time = ulong.Parse(string.Concat(_times.Select(x => x.ToString())));
            ulong distance = ulong.Parse(string.Concat(_distances.Select(x => x.ToString())));

            ulong raceMaxTime = time;
            ulong raceDistance = distance;
            ulong minimumTime = 0;
            while (minimumTime * (raceMaxTime - minimumTime) <= raceDistance)
            {
                minimumTime++;
            }

            ulong maximumTime = raceMaxTime;

            while (maximumTime * (raceMaxTime - maximumTime) <= raceDistance)
            {
                maximumTime--;
            }

            return maximumTime - minimumTime + 1;
        }
    }
}