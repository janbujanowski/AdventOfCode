using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day14
    {
        static List<string> knotHashes;
        static List<string> knotHashesBinary;
     
        public static string Input
        {
            get
            {
                return @"ljoxqyyw";
            }
        }
        private static void Init()
        {
            knotHashes = new List<string>();
            knotHashesBinary = new List<string>();
        }
        public static object StarOne()
        {
            Init();
            for (int i = 0; i < 128; i++)
            {
                var knotHash = Day10.StarTwo($"{Input}-{i}").ToString();
                knotHashes.Add(knotHash);
            }
            var sum = 0;
            foreach (var kH in knotHashes)
            {
                var binary = string.Empty;
                for (int i = 0; i < kH.Length; i++)
                {
                    binary += Convert.ToString(Convert.ToInt32(kH[i].ToString(), 16), 2);
                }
                knotHashesBinary.Add(binary);
                sum += binary.Count(x => x == '1');
            }
            return sum;
        }
        private static List<int> CheckRelations(int v)
        {
            List<int> progsChecked = new List<int> { v };
            var opr = new List<int>(ParentChildrenDict[v]);
            ParentChildrenDict[v] = new List<int>();
            foreach (var numba in opr)
            {
                if (!progsChecked.Contains(numba))
                {
                    progsChecked.Add(numba);
                    var relatedNest = CheckRelations(numba);
                    foreach (var numba2 in relatedNest)
                    {
                        if (!progsChecked.Contains(numba2))
                        {
                            progsChecked.Add(numba2);
                        }
                    }
                }
            }
            return progsChecked;
        }
        public static object StarTwo()
        {
            Init();
            //just not to duplicate -> be sure to generete binary list
            StarOne();
            int questSize = 128;
            int[,] matrx = new int[questSize,questSize];
            for (int i = 0; i < questSize; i++)
            {
                for (int j = 0; j < questSize; j++)
                {
                    matrx[i, j] = knotHashesBinary[i][j];
                }
            }


            return "-milion";
        }
    }
}
