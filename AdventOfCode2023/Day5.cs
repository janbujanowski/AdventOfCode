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
            public List<Range> Ranges;
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
            MapEntry currentEntry = new MapEntry() { Ranges = new List<Range>() };
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
                    currentEntry = new MapEntry() { Ranges = new List<Range>() };
                }
                else if (char.IsDigit(currentLine[0]))
                {
                    ulong[] rangeDefinition = Regex.Matches(_lines[i], @"\d+").Cast<Match>().Select(match => ulong.Parse(match.Value)).ToArray();
                    currentEntry.Ranges.Add(new Range()
                    {
                        DestinationRangeStart = rangeDefinition[0],
                        SourceRangeStart = rangeDefinition[1],
                        RangeLength = rangeDefinition[2]
                    });
                }
                currentEntry.Ranges = currentEntry.Ranges.OrderBy(x => x.SourceRangeStart).ToList();
                i++;
            }
            _mapEntries.Add(currentEntry);
        }

        class Range
        {
            public ulong SourceRangeStart, DestinationRangeStart, RangeLength;
            public CategoryName SourceCategory;

            internal bool IsOverlapping(Range unMapped)
            {
                return (unMapped.SourceRangeStart >= this.SourceRangeStart &&
                    unMapped.SourceRangeStart < this.SourceRangeStart + this.RangeLength)
                    ||
                    (unMapped.SourceRangeStart + unMapped.RangeLength >= this.SourceRangeStart &&
                    unMapped.SourceRangeStart + unMapped.RangeLength < this.SourceRangeStart + this.RangeLength);
            }

            internal Range MapTo(Range mapping, CategoryName destinationCategory)
            {
                Range range = new Range() { SourceCategory = destinationCategory };
                range.SourceRangeStart = mapping.DestinationRangeStart;
                range.RangeLength = RangeLength;

                if (RangeLength + SourceRangeStart > mapping.SourceRangeStart + mapping.RangeLength)
                {
                    range.RangeLength = mapping.RangeLength;
                }

                switch (Math.Sign((double)mapping.SourceRangeStart - SourceRangeStart))
                {
                    case 0:
                        break;
                    case 1:
                        range.RangeLength -= (mapping.SourceRangeStart - SourceRangeStart);
                        break;
                    case -1:
                        range.SourceRangeStart -= (mapping.SourceRangeStart - SourceRangeStart);

                        break;
                    default:
                        break;
                }

                return range;
            }

            internal List<Range> GetNotMapped(Range mapping)
            {
                List<Range> notMapped = new List<Range>();
                if (SourceRangeStart < mapping.SourceRangeStart &&
                    SourceRangeStart + RangeLength > mapping.SourceRangeStart)
                {
                    notMapped.Add(new Range()
                    {
                        SourceRangeStart = SourceRangeStart,
                        SourceCategory = SourceCategory,
                        RangeLength = mapping.SourceRangeStart - SourceRangeStart
                    });
                }
                if (SourceRangeStart < mapping.SourceRangeStart + mapping.RangeLength &&
                    SourceRangeStart + RangeLength > mapping.SourceRangeStart + mapping.RangeLength)
                {

                    notMapped.Add(new Range()
                    {
                        SourceRangeStart = mapping.SourceRangeStart + mapping.RangeLength,
                        SourceCategory = SourceCategory,
                        RangeLength = RangeLength - mapping.RangeLength
                    });
                }

                return notMapped;
            }
        }

        public override object StarOne()
        {
            List<Range> ranges = new List<Range>();

            for (int i = 0; i < _seeds.Count; i++)
            {
                ulong rangeStart = _seeds[i];
                ulong rangeLength = 1;
                ranges.Add(new Range()
                {
                    SourceCategory = CategoryName.seed,
                    SourceRangeStart = rangeStart,
                    RangeLength = rangeLength
                });
            }
            while (ranges.First().SourceCategory != CategoryName.location)
            {
                ranges = MapRanges(ranges);
            }

            return ranges.Select(range => range.SourceRangeStart).Min();
        }


        public override object StarTwo()
        {
            List<Range> ranges = new List<Range>();

            for (int i = 0; i < _seeds.Count; i += 2)
            {
                ulong rangeStart = _seeds[i];
                ulong rangeLength = _seeds[i + 1];
                ranges.Add(new Range()
                {
                    SourceCategory = CategoryName.seed,
                    SourceRangeStart = rangeStart,
                    RangeLength = rangeLength
                });
            }
            while (ranges.First().SourceCategory != CategoryName.location)
            {
                ranges = MapRanges(ranges);
            }

            return ranges.Select(range => range.SourceRangeStart).Min();
        }

        private List<Range> MapRanges(List<Range> ranges)
        {
            List<Range> newRanges = new List<Range>();
            foreach (Range range in ranges)
            {
                newRanges.AddRange(MapSingleRange(range));
            }
            return newRanges;
        }

        private IEnumerable<Range> MapSingleRange(Range range)
        {
            List<Range> mappedRanges = new List<Range>();
            List<Range> unMappedRemains = new List<Range>() { range };
            MapEntry mapEntry = _mapEntries.Find(entry => entry.SourceCategory == range.SourceCategory);

            bool shouldReRunMapping = true;
            while (shouldReRunMapping)
            {
                shouldReRunMapping = false;
                foreach (var mapping in mapEntry.Ranges)
                {
                    foreach (var unMapped in unMappedRemains)
                    {
                        if (mapping.IsOverlapping(unMapped))
                        {
                            shouldReRunMapping = true;
                            mappedRanges.Add(unMapped.MapTo(mapping, mapEntry.DestinationCategory));
                            unMappedRemains = unMapped.GetNotMapped(mapping);
                        }
                        if (shouldReRunMapping)
                        {
                            break;
                        }
                    }
                    if (shouldReRunMapping)
                    {
                        break;
                    }
                }
            }

            if (unMappedRemains.Any())
            {
                foreach (var unmapped in unMappedRemains)
                {
                    //fast forward
                    mappedRanges.Add(new Range()
                    {
                        SourceCategory = mapEntry.DestinationCategory,
                        SourceRangeStart = unmapped.SourceRangeStart,
                        RangeLength = unmapped.RangeLength,
                    });
                }
            }
            return mappedRanges;
        }
    }
}