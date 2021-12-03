using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day3 : Day66
    {
        string _strInput;
        string[] lines;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            lines = strInput.Split("\r\n");
        }

        public override object StarOne()
        {
            int[] zerosCount = new int[lines[0].Length];
            int[] onesCount = new int[lines[0].Length];
            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '1')
                    {
                        onesCount[i]++;
                    }
                    else
                    {
                        zerosCount[i]++;
                    }
                }
            }
            string moreCommonBitsString = string.Empty;
            for (int i = 0; i < zerosCount.Length; i++)
            {
                if (zerosCount[i] > onesCount[i])
                {
                    moreCommonBitsString += "0";
                }
                else
                {
                    moreCommonBitsString += "1";
                }
            }

            int gamma = Convert.ToInt32(moreCommonBitsString, 2);
            int epsilon = Convert.ToInt32(ReplaceThemZeroOnes(moreCommonBitsString), 2);
            int score = gamma * epsilon;
            return score;
        }
        private string ReplaceThemZeroOnes(string toreplace)
        {
            string replaced = string.Empty;
            foreach (var letter in toreplace)
            {
                if (letter == '1')
                {
                    replaced += "0";
                }
                else
                {
                    replaced += "1";
                }
            }
            return replaced;
        }
        public override object StarTwo()
        {
            int searchingRange = lines.Length;
            List<string> searchingBucket = lines.ToList();
            string leadingString = string.Empty;
            int charIndex = 0;
            while (searchingRange > 1)
            {
                int zerosCount = 0;
                int onesCount = 0;
                for (int j = 0; j < searchingRange; j++)
                {
                    if (searchingBucket.ElementAt(j)[charIndex] == '1')
                    {
                        onesCount++;
                    }
                    else
                    {
                        zerosCount++;
                    }
                }
                if (zerosCount > onesCount)
                {
                    leadingString += "0";
                }
                else
                {
                    leadingString += "1";
                }

                searchingBucket = searchingBucket.Where(line => line.StartsWith(leadingString)).ToList();
                searchingRange = searchingBucket.Count;
                charIndex++;
            }
            string oxygenRatingBinary = searchingBucket.First();

            searchingRange = lines.Length;
            searchingBucket = lines.ToList();
            leadingString = string.Empty;
            charIndex = 0;
            while (searchingRange > 1)
            {
                int zerosCount = 0;
                int onesCount = 0;
                for (int j = 0; j < searchingRange; j++)
                {
                    if (searchingBucket.ElementAt(j)[charIndex] == '1')
                    {
                        onesCount++;
                    }
                    else
                    {
                        zerosCount++;
                    }
                }
                if (zerosCount > onesCount)
                {
                    leadingString += "1";
                }
                else
                {
                    leadingString += "0";
                }

                searchingBucket = searchingBucket.Where(line => line.StartsWith(leadingString)).ToList();
                searchingRange = searchingBucket.Count;
                charIndex++;
            }
            string co2ScrubberRatingBinary = searchingBucket.First();

            int co2ScrubberRating = Convert.ToInt32(co2ScrubberRatingBinary, 2);
            int oxygenRating = Convert.ToInt32(oxygenRatingBinary, 2);

            return co2ScrubberRating * oxygenRating;
        }
    }
}
//7440311 still too high