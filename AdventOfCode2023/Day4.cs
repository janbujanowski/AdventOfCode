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
    public class Day4 : Day66
    {
        string[] lines;
        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
        }
        class ScratchCard
        {
            public int Id;
            public List<int> SelectedNumbers;
            public List<int> WinningNumbers;
        }

        public override object StarOne()
        {
            List<ScratchCard> cards = ParseScratchCards();

            var sum = cards
                .Select(scratchcard => scratchcard.WinningNumbers.Intersect(scratchcard.SelectedNumbers).Count())
                .Where(matchedNumbers => matchedNumbers > 0)
                .Aggregate(0, (autoSum, validWins) => autoSum += Convert.ToInt32(Math.Pow(2, validWins - 1)));
            
            return sum;
        }

        private List<ScratchCard> ParseScratchCards()
        {
            List<ScratchCard> cards = new List<ScratchCard>();
            string regex = @"\d+";
            foreach (var line in lines)
            {
                var id = int.Parse(Regex.Match(line.Split(':')[0], regex).Value);
                List<int> winningNumbers = Regex.Matches(line.Split(':')[1].Split('|')[0], regex).Cast<Match>().Select(match => int.Parse(match.Value)).ToList();
                List<int> selectedNumbers = Regex.Matches(line.Split(':')[1].Split('|')[1], regex).Cast<Match>().Select(match => int.Parse(match.Value)).ToList();
                cards.Add(new ScratchCard()
                {
                    Id = id,
                    WinningNumbers = winningNumbers,
                    SelectedNumbers = selectedNumbers
                });
            }
            return cards;
        }
       
        public override object StarTwo()
        {
            int sum = 0;
            return sum;
        }
     
        
    }
}