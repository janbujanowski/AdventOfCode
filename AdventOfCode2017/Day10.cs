using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day10
    {
        static int[] listToHash;
        static List<int> inputLengths;
        static int skipSize;
        public static string Input
        {
            get
            {
                return @"197,97,204,108,1,29,5,71,0,50,2,255,248,78,254,63";
            }
        }

        private static void Init()
        {
            listToHash = new int[256];
            for (int i = 0; i < listToHash.Length; i++)
            {
                listToHash[i] = i;
            }
            var list = Input.Split(',');
            inputLengths = new List<int>();
            foreach (var number in list)
            {
                inputLengths.Add(Int32.Parse(number));
            }
        }
        public static object StarOne()
        {
            Init();
            int i = 0;
            skipSize = 0;
            foreach (var number in inputLengths)
            {
                int endindex = HashList(i,number);
                i = endindex;
            }
            
            return listToHash[0] * listToHash[1];
        }

        private static int HashList(int startIndex, int number)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < number; i++)
            {
                numbers.Add(listToHash[(startIndex + i)%listToHash.Length]);
            }
            numbers.Reverse();
            for (int i = 0; i < number; i++)
            {
                listToHash[(startIndex + i) % listToHash.Length] = numbers[i];
            }
            var endindex = (startIndex + number + skipSize) % listToHash.Length;
            skipSize++;
            return endindex;
        }

        //public static object StarOne(string testDifferentInput)
        //{
        //    return CountStarOne(testDifferentInput);
        //}
        //private static int CountStarOne(string localPutin)
        //{
        //    elements = localPutin.ToArray();
        //    int i = 0;
        //    int openedGroups = 0;
        //    int qualifiedgroups = 0;
        //    while (i < elements.Count())
        //    {
        //        switch (elements[i])
        //        {
        //            case '{':
        //                openedGroups++;
        //                break;
        //            case '}':
        //                openedGroups--;
        //                qualifiedgroups++;
        //                break;
        //            default:
        //                break;
        //        }
        //        i++;
        //    }
        //    return qualifiedgroups;
        //}

        public static int StarTwo()
        {
            Init();
            int sum = 0;

            return sum;
        }
    }
}
