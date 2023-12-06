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
            public CategoryName SourceCategory;
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
            currentEntry.Ranges = currentEntry.Ranges.OrderBy(x => x.SourceRangeStart).ToList();
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

            List<ulong> minimumLocations = new List<ulong>();


            foreach (var seedRange in seedRanges)
            {
                minimumLocations.Add(FindSeedRangeLowestLocation(seedRange.Key, seedRange.Value));

            }
            return minimumLocations.Min();
        }
        private ulong FindSeedRangeLowestLocation(ulong startSeed, ulong seedRange)
        {
            Dictionary<ulong, ulong> seedRanges = new Dictionary<ulong, ulong>();

            Queue<EntryRange> queue = new Queue<EntryRange>();
            queue.Enqueue(new EntryRange() { SourceCategory = CategoryName.seed, SourceRangeStart = startSeed, RangeLength = seedRange });

            while (queue.Count > 0)
            {

                EntryRange currentChainRange = queue.Dequeue();
                if (currentChainRange.SourceCategory == CategoryName.location)
                {
                    seedRanges.Add(currentChainRange.SourceRangeStart, currentChainRange.RangeLength);
                }
                else
                {
                    CategoryName sourceCategory = currentChainRange.SourceCategory;
                    MapEntry mapEntry = _mapEntries.Find(entry => entry.SourceCategory == sourceCategory);

                    ulong currentChainRangeStart = currentChainRange.SourceRangeStart;
                    ulong currentChainRangeEnd = currentChainRange.SourceRangeStart + currentChainRange.RangeLength;

                    int lastRangeId = mapEntry.Ranges.Count - 1;
                    for (int i = 0; i < mapEntry.Ranges.Count; i++)
                    {
                        var currentMappingRange = mapEntry.Ranges[i];
                        ulong currentMappingRangeStart = currentMappingRange.SourceRangeStart;
                        ulong currentMappingRangeEnd = currentMappingRange.SourceRangeStart + currentMappingRange.RangeLength;

                        if (currentChainRangeStart < currentMappingRangeStart)
                        {
                            if (currentChainRangeEnd > currentMappingRangeStart)
                            {
                                queue.Enqueue(new EntryRange()
                                {
                                    SourceCategory = mapEntry.DestinationCategory,
                                    SourceRangeStart = currentMappingRange.DestinationRangeStart,
                                    RangeLength = currentMappingRangeStart - currentChainRangeStart
                                });
                                if (currentChainRangeEnd < currentMappingRangeEnd)
                                {
                                    queue.Enqueue(new EntryRange()
                                    {
                                        SourceCategory = mapEntry.DestinationCategory,
                                        SourceRangeStart = currentMappingRange.DestinationRangeStart,
                                        RangeLength = currentChainRangeEnd - currentMappingRangeStart
                                    });
                                }
                                else
                                {
                                    queue.Enqueue(new EntryRange()
                                    {
                                        SourceCategory = mapEntry.DestinationCategory,
                                        SourceRangeStart = currentMappingRange.DestinationRangeStart,
                                        RangeLength = currentChainRange.RangeLength
                                    });
                                    currentChainRangeStart = currentMappingRangeStart + currentMappingRange.RangeLength;
                                }
                            }
                            else
                            {
                                if (i == lastRangeId)
                                {
                                    queue.Enqueue(new EntryRange()
                                    {
                                        SourceCategory = mapEntry.DestinationCategory,
                                        SourceRangeStart = currentChainRangeStart,
                                        RangeLength = currentChainRange.RangeLength
                                    });
                                }
                            }

                        }
                        else if (currentChainRangeStart < currentMappingRangeEnd)
                        {

                            if (currentChainRangeEnd < currentMappingRangeEnd)
                            {
                                queue.Enqueue(new EntryRange()
                                {
                                    SourceCategory = mapEntry.DestinationCategory,
                                    SourceRangeStart = currentMappingRange.DestinationRangeStart,
                                    RangeLength = currentChainRange.RangeLength
                                });

                            }
                            else
                            {
                                queue.Enqueue(new EntryRange()
                                {
                                    SourceCategory = mapEntry.DestinationCategory,
                                    SourceRangeStart = currentMappingRange.DestinationRangeStart,
                                    RangeLength = currentChainRange.RangeLength
                                });
                                currentChainRangeStart = currentMappingRangeEnd;

                            }

                        }
                        else
                        {
                            if (i == lastRangeId)
                            {
                                queue.Enqueue(new EntryRange()
                                {
                                    SourceCategory = mapEntry.DestinationCategory,
                                    SourceRangeStart = currentChainRangeStart,
                                    RangeLength = currentChainRangeEnd - currentChainRangeStart
                                });
                            }
                        }
                    }
                    //sourceCategory = mapEntry.DestinationCategory;
                }


            }
            return seedRanges.Keys.Min();
        }

    }
}