using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day7 : IDayX
    {
        Dictionary<string, string> bagsDefinitions;

        string mainSplitter = " bags contain ";

        public int DayNumber()
        {
            return 7;
        }
        public Day7(string strInput)
        {
            bagsDefinitions = strInput.Split("\n").ToDictionary(definition => definition.Split(mainSplitter)[0], definition => definition.Split(mainSplitter)[1]);
        }

        public object StarOne(string strInput)
        {
            //287
            List<string> shinyGoldContainers = new List<string>();
            CountTheBags("shiny gold", bagsDefinitions, shinyGoldContainers);
            return shinyGoldContainers.Count - 1;//don't count the main shiny gold omg
        }

        private void CountTheBags(string v, Dictionary<string, string> bagsDefinitions, List<string> shinyGoldContainers)
        {
            if (!shinyGoldContainers.Contains(v))
            {
                shinyGoldContainers.Add(v);
            }
            var bags = bagsDefinitions.Where(x => x.Value.Contains(v));

            foreach (var definition in bags)
            {
                CountTheBags(definition.Key, bagsDefinitions, shinyGoldContainers);
            }
        }

        public object StarTwo(string strInput)
        {
            //48160
            Dictionary<string, Dictionary<string, int>> bagsDefinitionsWithQuantity = GenerateBagsGraph(bagsDefinitions);
            int sum = CountInsidesOfBag("shiny gold", bagsDefinitionsWithQuantity);
            return sum;
        }

        private int CountInsidesOfBag(string v, Dictionary<string, Dictionary<string, int>> bagsDefinitionsWithQuantity)
        {
            if (bagsDefinitionsWithQuantity[v].Count == 0)
            {
                return 0;
            }
            else
            {
                return bagsDefinitionsWithQuantity[v].Sum(selector => selector.Value + selector.Value * CountInsidesOfBag(selector.Key, bagsDefinitionsWithQuantity));
            }
        }

        private Dictionary<string, Dictionary<string, int>> GenerateBagsGraph(Dictionary<string, string> bagsDefinitions)
        {
            Dictionary<string, Dictionary<string, int>> bagsDefinitionsWithQuantity = new Dictionary<string, Dictionary<string, int>>();
            foreach (var bagDefinition in bagsDefinitions)
            {
                Dictionary<string, int> containedBagsWithQ = new Dictionary<string, int>();
                //muted fuchsia||5 dotted silver \ 4 plaid tomato \ 2 drab olive \ 4 vibrant tomato 
                var containedBags = bagDefinition.Value.Replace("bags", "").Replace("bag", "").Replace(".", "").Split(',');
                foreach (var containDefinitions in containedBags)
                {
                    if (!containDefinitions.Contains("no other"))
                    {
                        var clearedDefinition = containDefinitions.Trim().Split(' ');
                        var quantity = int.Parse(clearedDefinition[0]);
                        containedBagsWithQ.Add($"{clearedDefinition[1]} {clearedDefinition[2]}", quantity);
                    }
                }
                bagsDefinitionsWithQuantity.Add(bagDefinition.Key, containedBagsWithQ);
            }
            return bagsDefinitionsWithQuantity;
        }
    }
}
