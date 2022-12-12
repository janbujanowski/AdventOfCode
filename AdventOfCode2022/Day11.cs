using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdventOfCode2022
{
    class Monkey
    {
        public long Id;
        public long DivisibleBy;
        public Queue<long> Items;
        public long TrueThrowTo;
        public long FalseThrowTo;
        public Func<long, long> Operation;
        public long Inspections;
    }

    public class Day11 : Day66
    {
        string _strInput;
        List<Monkey> _monkeys;

        public override void ParseInput(string strInput)
        {
            _monkeys = new List<Monkey>();
            _strInput = strInput;
            var lines = _strInput.SplitWithEnter();
            for (long i = 0; i < lines.Length; i += 7)
            {
                long monkeyId = long.Parse(lines[i].Split(' ')[1].Split(':')[0]);
                Queue<long> items = new Queue<long>(lines[i + 1].Split(':')[1].Trim().Split(',').Select(item => long.Parse(item)));
                Func<long, long> func = GetFunction(lines[i + 2]);
                long divisibleBy = long.Parse(lines[i + 3].Trim().Split(' ')[3]);
                long trueThrowTo = long.Parse(lines[i + 4].Trim().Split(' ')[5]);
                long falseThrowTo = long.Parse(lines[i + 5].Trim().Split(' ')[5]);

                var monkey = new Monkey()
                {
                    Id = monkeyId,
                    Items = items,
                    Operation = func,
                    DivisibleBy = divisibleBy,
                    TrueThrowTo = trueThrowTo,
                    FalseThrowTo = falseThrowTo,
                    Inspections = 0
                };
                _monkeys.Add(monkey);
            }
        }

        private Func<long, long> GetFunction(string v)
        {
            var longerestingPart = v.Split('=')[1].Trim().Split(' ');
            var isMultply = longerestingPart[1][0] == '*';
            var isOld = longerestingPart[2] == "old";
            if (isOld)
            {
                return (x) => { return x * x; };
            }
            var numberPart = long.Parse(longerestingPart[2]);
            if (isMultply)
            {
                return (x) => { return x * numberPart; };
            }
            return (x) => { return x + numberPart; };

        }

        private void Round(List<Monkey> monkeys, int worryLevelDivider)
        {
            var largestMultipleDivision = 1L;
            foreach (var monk in monkeys)
            {
                largestMultipleDivision *= monk.DivisibleBy;
            }
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Count > 0)
                {
                    var item = monkey.Items.Dequeue();
                    var newitemworryLevel = monkey.Operation(item)/ worryLevelDivider % largestMultipleDivision;
                    monkey.Inspections++;
                    if (newitemworryLevel % monkey.DivisibleBy == 0)
                    {
                        monkeys.Find(monkeyThrow => monkeyThrow.Id== monkey.TrueThrowTo).Items.Enqueue(newitemworryLevel);
                    }
                    else
                    {
                        monkeys.Find(monkeyThrow => monkeyThrow.Id == monkey.FalseThrowTo).Items.Enqueue(newitemworryLevel);
                    }
                }
            }
        }
        public override object StarOne()
        {
            return GetMonkeyBusiness(20, 3);
        }

        private long GetMonkeyBusiness(int rounds, int worryLevelDivider)
        {
            ParseInput(_strInput);
            for (long i = 0; i < rounds; i++)
            {
                Round(_monkeys, worryLevelDivider);
            }
            var oredered = _monkeys.OrderByDescending(x => x.Inspections);
            var first = oredered.ElementAt(0).Inspections;
            return oredered.ElementAt(0).Inspections * oredered.ElementAt(1).Inspections;
        }

        public override object StarTwo()
        {
            return GetMonkeyBusiness(10000,1);
        }
    }
}
