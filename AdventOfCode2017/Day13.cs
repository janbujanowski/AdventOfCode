using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day13
    {
        static int[] firewallLayers;
        static List<string> lines;
        public static string Input
        {
            get
            {
                return @"0: 3
1: 2
2: 4
4: 4
6: 5
8: 6
10: 6
12: 6
14: 6
16: 8
18: 8
20: 8
22: 8
24: 10
26: 8
28: 8
30: 12
32: 14
34: 12
36: 10
38: 12
40: 12
42: 9
44: 12
46: 12
48: 12
50: 12
52: 14
54: 14
56: 14
58: 12
60: 14
62: 14
64: 12
66: 14
70: 14
72: 14
74: 14
76: 14
80: 18
88: 20
90: 14
98: 17";
            }
        }
        private static void Init()
        {
            try
            {
                lines = new List<string>();
                string[] separators = new string[] { "\r\n" };
                lines = Input.Split(separators, StringSplitOptions.None).ToList();

                string[] separatorLine = new string[] { ":" };
                var layersSize = Convert.ToInt32(lines.Last().Split(':')[0]);
                firewallLayers = new int[layersSize + 1];

                foreach (var line in lines)
                {
                    var args = line.Split(separatorLine, StringSplitOptions.None);
                    int layer = Int32.Parse(args[0]);
                    var levels = Int32.Parse(args[1]);
                    firewallLayers[layer] = levels;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Probalby bad formatted input. Exception : ", ex);
            }
        }
        public static object StarOne()
        {
            Init();
            var time = 0;
            List<int> caughtLayer = new List<int>();
            while (time < firewallLayers.Length)
            {
                var levels = firewallLayers[time];
                var c = 0;
                var modifier = 1;
                for (int i = 0; i < time; i++)
                {
                    c += modifier;
                    if (c == 0)
                    {
                        modifier = 1;
                    }
                    if (c == levels - 1)
                    {
                        modifier = -1;
                    }
                }
                if (c == 0)
                {
                    caughtLayer.Add(time);
                }
                time++;
            }
            var sum = 0;
            foreach (var x in caughtLayer)
            {
                sum += x * firewallLayers[x];
            }
            return sum;
        }

        public static object StarTwo()
        {
            int delay = -1;
            List<int> layers = new List<int>();
            do
            {
                delay++;
                layers = new List<int>();
                var time = 0;
                while (time < firewallLayers.Length)
                {
                    var levels = firewallLayers[time];

                    if (levels != 0)
                    {
                        if ((time + delay) % (2 * levels - 2) == 0)
                        {
                            layers.Add(time);
                            //break;
                        }
                    }
                    time++;
                }
            } while (layers.Count > 0);
            return delay;
        }
    }
}
