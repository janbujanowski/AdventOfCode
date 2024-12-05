using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public class Day5 : Day66
    {
        string[] _lines;
        int _sizeY;
        int _sizeX;
        int _maxPageNumber = 100;
        class Rule
        {
            internal int Page;
            internal int BeforePage;
            internal Rule(string page, string beforePage)
            {
                Page = int.Parse(page);
                BeforePage = int.Parse(beforePage);
            }
        }
        List<Rule> _rulesSet = new List<Rule>();
        List<Dictionary<int, int>> _updatesOrder;
        public override void ParseInput(string input)
        {
            _lines = input.Split("\r\n");
            int i = 0;
            do
            {
                var line = _lines[i].Split('|');
                _rulesSet.Add(new Rule(line[0], line[1]));
                i++;
            } while (!string.IsNullOrEmpty(_lines[i]) || i == _lines.Length);
            i++;
            _updatesOrder = new List<Dictionary<int, int>>();
            do
            {
                var line = _lines[i].Split(',');
                var update = new Dictionary<int, int>();
                for (int n = 0; n < line.Length; n++)
                {
                    update[int.Parse(line[n])] = n;
                }
                _updatesOrder.Add(update);
                i++;
            } while (i != _lines.Length);
        }

        public override object StarOne()
        {
            int sum = 0;
            foreach (var update in _updatesOrder)
            {
                if (IsValidOrder(update))
                {
                    sum += update.ElementAt(update.Count / 2).Key;
                }
            }
            return sum;
        }

        private bool IsValidOrder(Dictionary<int, int> update)
        {
            bool valid = true;
            foreach (var rule in _rulesSet)
            {
                if (update.ContainsKey(rule.Page) && update.ContainsKey(rule.BeforePage))
                {
                    if (update[rule.Page] > update[rule.BeforePage])
                    {
                        valid = false;
                        break;
                    }
                }
            }
            return valid;
        }


        public override object StarTwo()
        {
            int sum = 0;
            foreach (var update in _updatesOrder)
            {
                if (!IsValidOrder(update))
                {
                    sum += Sort(update);
                }
            }
            return sum;
        }

        private int Sort(Dictionary<int, int> update)
        {
            int sum = 0;
            bool valid = true;
            do
            {
                valid = true;
                foreach (var rule in _rulesSet)
                {
                    if (update.ContainsKey(rule.Page) && update.ContainsKey(rule.BeforePage))
                    {
                        if (update[rule.Page] > update[rule.BeforePage])
                        {
                            Swap(update, rule.Page, rule.BeforePage);
                            valid = false;
                        }
                    }
                }
            } while (!valid);

            return update.First(x=> x.Value == update.Count/2).Key;
        }

        private void Swap(Dictionary<int, int> update, int page, int beforePage)
        {
            int value = update[page];
            update[page] = update[beforePage];
            update[beforePage] = value;
        }
    }
}
