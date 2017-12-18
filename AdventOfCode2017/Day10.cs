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
            int currentPosition = 0;
            skipSize = 0;
            foreach (var number in inputLengths)
            {
                currentPosition = HashList(currentPosition, number);
            }

            return listToHash[0] * listToHash[1];
        }
        public static object StarTwo(string input)
        {
            Init();
            if (input == null)
            {
                input = Input;
            }
            var convertedInput = ConvertInputToStarTwoLengths(input);
            var convertedLengths = new List<int>();

            foreach (var length in convertedInput.Split(',').ToArray())
            {
                convertedLengths.Add(Int32.Parse(length));
            }

            int roundsToRoll = 64;
            int currentPosition = 0;
            skipSize = 0;
            for (int j = 0; j < roundsToRoll; j++)
            {
                foreach (var number in convertedLengths)
                {
                    currentPosition = HashList(currentPosition, number);
                }
            }
            string outputHash = string.Empty;

            for (int j = 0; j < 16; j++)
            {
                int xoredLine = listToHash[j * 16];
                for (int k = 1; k < 16; k++)
                {
                    xoredLine = xoredLine ^ listToHash[k + j * 16];
                }
                outputHash += xoredLine.ToString("X2").ToLower();// + ",";
            }

            return outputHash;
        }
        private static int HashList(int startIndex, int number)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < number; i++)
            {
                numbers.Add(listToHash[(startIndex + i) % listToHash.Length]);
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
        public static string ConvertInputToStarTwoLengths(string input)
        {
            List<int> lengths = new List<int>();
            foreach (var item in input.ToArray())
            {
                lengths.Add((int)item);
            }
            lengths.Add(17);
            lengths.Add(31);
            lengths.Add(73);
            lengths.Add(47);
            lengths.Add(23);
            return string.Join(",", lengths);
        }
    }
}
