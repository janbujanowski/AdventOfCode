using AdventOfCode2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCodeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Day14.StarOne());
            //8316
            Console.WriteLine(Day14.StarOne("flqrgnkx"));
            //8108
            Console.WriteLine(Day14.StarTwo());
            //1074
            Console.WriteLine(Day14.StarTwo("flqrgnkx"));
            //1242
            Console.ReadKey();
        }
    }
}
