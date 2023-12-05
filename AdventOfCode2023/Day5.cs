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
    public class Day5 : Day66
    {
        enum CategoryName
        {
            seed,
            soil,
            fertilizer,
            water,
            light,
            temperature,
            humidity,
            location
        }
        class MapEntry
        {
            public CategoryName SourceCategory, DestinationCategory;
            public List<EntryRange> Ranges;
        }
        class EntryRange
        {
            public ulong SourceRangeStart, DestinationRangeStart, RangeLength;
        }
        string[] _lines;
        List<ulong> _seeds;
        List<MapEntry> _mapEntries;

        public override void ParseInput(string strInput)
        {

            _lines = strInput.Split("\r\n");
            _seeds = Regex.Matches(_lines[0].Split(':')[1], @"\d+").Cast<Match>().Select(match => ulong.Parse(match.Value)).ToList();

            _mapEntries = new List<MapEntry>();
            int i = 2;
            MapEntry currentEntry = new MapEntry() { Ranges = new List<EntryRange>() };
            while (i < _lines.Length)
            {
                string currentLine = _lines[i];
                if (currentLine.Contains(':'))
                {
                    string[] mapDefinition = currentLine.Split(' ')[0].Split('-');
                    currentEntry.SourceCategory = (CategoryName)Enum.Parse(typeof(CategoryName), mapDefinition[0]);
                    currentEntry.DestinationCategory = (CategoryName)Enum.Parse(typeof(CategoryName), mapDefinition[2]);
                }

                if (string.IsNullOrEmpty(currentLine))
                {
                    _mapEntries.Add(currentEntry);
                    currentEntry = new MapEntry() { Ranges = new List<EntryRange>() };
                }
                else if (char.IsDigit(currentLine[0]))
                {
                    ulong[] rangeDefinition = Regex.Matches(_lines[i], @"\d+").Cast<Match>().Select(match => ulong.Parse(match.Value)).ToArray();
                    currentEntry.Ranges.Add(new EntryRange()
                    {
                        DestinationRangeStart = rangeDefinition[0],
                        SourceRangeStart = rangeDefinition[1],
                        RangeLength = rangeDefinition[2]
                    });
                }
                i++;
            }
            _mapEntries.Add(currentEntry);
        }


        public override object StarOne()
        {
            Dictionary<ulong, ulong> seedToLocation = new Dictionary<ulong, ulong>();
            foreach (var seed in _seeds)
            {
                ulong location = FindSeedLocation(seed);
                seedToLocation.Add(seed, location);
            }
            return seedToLocation.Values.Min();
        }

        private ulong FindSeedLocation(ulong seed)
        {
            ulong currentIdentifier = seed;
            CategoryName sourceCategory = CategoryName.seed;
            do
            {
                var mapEntry = _mapEntries.Find(entry => entry.SourceCategory == sourceCategory);
                foreach (var range in mapEntry.Ranges)
                {
                    if (range.SourceRangeStart <= currentIdentifier && currentIdentifier < range.SourceRangeStart + range.RangeLength)
                    {
                        var offset = currentIdentifier - range.SourceRangeStart;
                        currentIdentifier = range.DestinationRangeStart + offset;
                        break;
                    }
                }
                sourceCategory = mapEntry.DestinationCategory;

            } while (sourceCategory != CategoryName.location);
            return currentIdentifier;
        }

        public override object StarTwo()
        {
            Dictionary<ulong, ulong> seedRanges = new Dictionary<ulong, ulong>();
            for (int i = 0; i < _seeds.Count; i += 2)
            {
                seedRanges.Add(_seeds[i], _seeds[i + 1]);
            }



            Dictionary<ulong, ulong> seedToLocation = new Dictionary<ulong, ulong>();
            foreach (var seedRange in seedRanges)
            {
                for (ulong i = seedRange.Key; i < seedRange.Key + seedRange.Value; i++)
                {
                    ulong location = FindSeedLocation(i);
                    seedToLocation.Add(i, location);
                }
                
            }
            return seedToLocation.Values.Min();
        }
        private ulong FindSeedRangeLowestLocation(ulong startSeed, ulong currentRange)
        {
            Dictionary<ulong, ulong> seedRanges = new Dictionary<ulong, ulong>();
            ulong currentIdentifier = startSeed;
            CategoryName sourceCategory = CategoryName.seed;
            do
            {
                var mapEntry = _mapEntries.Find(entry => entry.SourceCategory == sourceCategory);
                foreach (var range in mapEntry.Ranges)
                {
                    if (range.SourceRangeStart <= currentIdentifier && currentIdentifier < range.SourceRangeStart + range.RangeLength)
                    {
                        var offset = currentIdentifier - range.SourceRangeStart;
                        currentIdentifier = range.DestinationRangeStart + offset;
                        break;
                    }
                }
                sourceCategory = mapEntry.DestinationCategory;

            } while (sourceCategory != CategoryName.location);
            return currentIdentifier;
        }

    }
}