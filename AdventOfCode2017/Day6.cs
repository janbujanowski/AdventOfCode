using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day6
    {
        static int[] blocks;
        static List<List<int>> combinations;
        public static string Input
        {
            get
            {
                return @"14	0	15	12	11	11	3	5	1	6	8	4	9	1	8	4";
            }
        }

        private static void Init()
        {
            var values = Input.Split('\t');
            blocks = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                blocks[i] = Int32.Parse(values[i]);
            }
            combinations = new List<List<int>>();
        }

        public static int StarOne()
        {
            Init();
            int indexout = blocks.Length - 1;
            int i = 0;
            bool nextCycle = true;
            while (nextCycle)
            {
                //combinations.Add(new List<int>(blocks));
                int currMax = blocks.ToList().IndexOf(blocks.Max());
                i = currMax;
                var load = blocks[i];
                blocks[i] = 0;
                if (i != indexout)
                {
                    i++;
                }
                while (load > 0)
                {
                    blocks[i]++;
                    load--;
                    i++;
                    if (i > indexout)
                    {
                        i = 0;
                    }
                }
                var nextCombination = new List<int>(blocks);
                foreach (var combination in combinations)
                {
                    if (combination.SequenceEqual(nextCombination))
                    {
                        nextCycle = false;
                    }
                }
                combinations.Add(nextCombination);
            }

            return combinations.Count();
        }
    }
}
