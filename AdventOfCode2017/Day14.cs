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
        static string input;

        public static string Input
        {
            get
            {
                if (!String.IsNullOrEmpty(input))
                {
                    return input;
                }
                return @"ljoxqyyw";
            }
        }
        private static void Init()
        {
            knotHashes = new List<string>();
            knotHashesBinary = new List<string>();
        }
        public static object StarOne(string differentInput = "")
        {
            if (!String.IsNullOrEmpty(input))
            {
                input = differentInput;
            }
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
                    binary += Convert.ToString(Convert.ToInt32(kH[i].ToString(), 16), 2).PadLeft(4, '0');
                }
                binary = binary.Replace('1', 'x');
                knotHashesBinary.Add(binary);
                sum += binary.Count(x => x == 'x');
            }
            return sum;
        }
        public static object StarTwo(string differentInput = "")
        {

            //just not to duplicate -> be sure to generete binary list
            StarOne(differentInput);
            int questSize = 128;
            int group = 1;
            int[,] matrx = new int[questSize, questSize];
            for (int i = 0; i < questSize; i++)
            {
                for (int j = 0; j < questSize; j++)
                {
                    if (knotHashesBinary[i][j] == 'x')
                    {

                        matrx[i, j] = -1;
                    }
                    else
                    {
                        matrx[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < questSize; i++)
            {
                for (int j = 0; j < questSize; j++)
                {
                    var origini = i.ToString();
                    var originj = j.ToString();
                    if (FollowPath(matrx, i, j, group))
                    {
                        group++;

                    }
                    i = Int32.Parse(origini);
                    j = Int32.Parse(originj);
                }
            }
            return group - 1;
        }

        private static bool FollowPath(int[,] matrx, int i, int j, int group)
        {
            var x = matrx[i, j];
            if (matrx[i, j] == -1)
            {
                matrx[i, j] = group;
                if (i > 0)
                {
                    FollowPath(matrx, i - 1, j, group);
                }
                if (i < 127)
                {
                    FollowPath(matrx, i + 1, j, group);
                }
                if (j > 0)
                {
                    FollowPath(matrx, i, j - 1, group);
                }
                if (j < 127)
                {
                    FollowPath(matrx, i, j + 1, group);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
