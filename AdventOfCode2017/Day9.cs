using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public class Day9
    {
        static char[] elements;
        public static string Input
        {
            get
            {
                return ExtensionHelpers.GetString("Day9_Input");
            }
        }

        private static void Init()
        {
            elements = Input.ToArray();
        }
        public static object StarOne()
        {
            Init();
            int result = CountStarOne(Input);
            return result;
            
        }
        public static object StarOne(string testDifferentInput)
        {
            return CountStarOne(testDifferentInput);
        }
        private static int CountStarOne(string localPutin)
        {
            elements = localPutin.ToArray();
            int i = 0;
            int openedGroups = 0;
            int qualifiedgroups = 0;
            while (i < elements.Count())
            {
                switch (elements[i])
                {
                    case '{':
                        openedGroups++;
                        break;
                    case '}':
                        openedGroups--;
                        qualifiedgroups++;
                        break;
                    default:
                        break;
                }
                i++;
            }
            return qualifiedgroups;
        }

        public static int StarTwo()
        {
            Init();
            int sum = 0;
            
            return sum;
        }
    }
}
