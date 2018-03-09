using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day15
    {
        static ulong factorA = 16807;
        static ulong factorB = 48271;
        static ulong lastA, lastB;

        public static int StarOne(ulong initValueA, ulong initValueB)
        {
            lastA = initValueA;
            lastB = initValueB;
            var matches = 0;
            for (int i = 0; i < 40000000; i++)
            {
                var A = GeneratorA();
                var B = GeneratorB();

                if ((A & 0xFFFF) == (B & 0xFFFF))
                {
                    matches++;
                }
            }
            return matches;
        }
        public static int StarTwo(ulong initValueA, ulong initValueB)
        {
            lastA = initValueA;
            lastB = initValueB;
            var matches = 0;
            for (int i = 0; i < 5000000; i++)
            {
                ulong A, B;

                A = GeneratorA2();
                B = GeneratorB2();

                if ((A & 0xFFFF) == (B & 0xFFFF))
                {
                    matches++;
                }
            }
            return matches;
        }

        static ulong GeneratorA()
        {
            lastA = lastA * factorA % 2147483647;
            return lastA;
        }
        static ulong GeneratorB()
        {
            lastB = lastB * factorB % 2147483647;
            return lastB;
        }
        static ulong GeneratorA2()
        {
            while (true)
            {
                lastA = lastA * factorA % 2147483647;
                if (lastA % 4 == 0)
                {
                    return lastA;
                }
            }
        }
        static ulong GeneratorB2()
        {
            while (true)
            {
                lastB = lastB * factorB % 2147483647;
                if (lastB % 8 == 0)
                {
                    return lastB;
                }
            }
        }
    }
}
