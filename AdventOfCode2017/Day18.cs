using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day18
    {
        static long lastplayed = 0;
        private static List<string> lines;
        private static Dictionary<string, long> registers;
        private static List<long> soundedFrequencies;
        private static List<long> recoveredFreqencies;
        public static string Input
        {
            get
            {
                return @"set i 31
set a 1
mul p 17
jgz p p
mul a 2
add i -1
jgz i -2
add a -1
set i 127
set p 622
mul p 8505
mod p a
mul p 129749
add p 12345
mod p a
set b p
mod b 10000
snd b
add i -1
jgz i -9
jgz a 3
rcv b
jgz b -1
set f 0
set i 126
rcv a
rcv b
set p a
mul p -1
add p b
jgz p 4
snd a
set a b
jgz 1 3
snd b
set f 1
add i -1
jgz i -11
snd a
jgz f -16
jgz a -19";
            }
        }

        public static void Init()
        {
            lines = new List<string>();
            string[] separators = new string[] { "\r\n" };
            lines = Input.Split(separators, StringSplitOptions.None).ToList();
            registers = new Dictionary<string, long>();
            soundedFrequencies = new List<long>();
            recoveredFreqencies = new List<long>();
            foreach (var line in lines)
            {
                var args = line.Split(' ');
                if (!registers.ContainsKey(args[1]))
                {
                    registers.Add(args[1], 0);
                }
            }
        }

        public static object StarOne()
        {
            Init();
            int currentline = 0;
            int executioncount = 0;
            while (currentline < lines.Count)
            {
                var line = lines[currentline];
                var args = lines[currentline].Split(' ');
                switch (args[0])
                {
                    case "set":
                        Set(args);
                        currentline++;
                        break;
                    case "add":
                        Add(args);
                        currentline++;
                        break;
                    case "mul":
                        Mul(args);
                        currentline++;
                        break;
                    case "mod":
                        Mod(args);
                        currentline++;
                        break;
                    case "rcv":
                        Rcv(args);
                        currentline++;
                        break;
                    case "jgz":
                        var result = Jgz(args);
                        if (result == null)
                        {
                            currentline++;
                        }
                        else
                        {
                            currentline += Int32.Parse(result.ToString());
                        }
                        break;
                    case "snd":
                        Snd(args);
                        currentline++;
                        break;
                    default:
                        break;
                }
                if (currentline < 0)
                {
                    currentline = lines.Count;
                }
                if (recoveredFreqencies.Count > 0)
                {
                    currentline = lines.Count;
                }
                executioncount++;
            }
            return recoveredFreqencies[0];
        }

        private static object Jgz(string[] args)
        {
            var regname = args[1];
            long value = ParseValue(args[1]);
            if (value > 0)
            {
                return ParseValue(args[2]);
            }
            else
            {
                return null;
            }
        }
        private static void Snd(string[] args)
        {
            var regname = args[1];
            long value = ParseValue(args[1]);
            soundedFrequencies.Add(value);
            lastplayed = value;

        }
        private static void Rcv(string[] args)
        {
            long value = ParseValue(args[1]);
            if (value > 0)
            {
                recoveredFreqencies.Add(soundedFrequencies.Last());
            }
        }
        private static void Mod(string[] args)
        {
            var regname = args[1];
            long value = ParseValue(args[2]);

            registers[regname] = registers[regname] % value;
        }
        private static void Mul(string[] args)
        {
            var regname = args[1];
            long value = ParseValue(args[2]);
            registers[regname] = registers[regname] * value;
        }
        private static long ParseValue(string v)
        {
            long value;
            try
            {
                value = long.Parse(v);
            }
            catch (Exception)
            {
                value = registers[v];
            }
            return value;
        }
        private static void Add(string[] args)
        {
            var regname = args[1];
            long value = ParseValue(args[2]);
            registers[regname] += value;
        }
        private static void Set(string[] args)
        {
            var regname = args[1];
            long value = ParseValue(args[2]);
            registers[regname] = value;
        }
        private static bool CheckCondition(string regnametocheck, string comparator, string compareValue)
        {
            var result = false;
            var value = Int32.Parse(compareValue);
            switch (comparator)
            {
                case ">":
                    if (registers[regnametocheck] > value)
                        result = true;
                    break;
                case ">=":
                    if (registers[regnametocheck] >= value)
                        result = true;
                    break;
                case "==":
                    if (registers[regnametocheck] == value)
                        result = true;
                    break;
                case "!=":
                    if (registers[regnametocheck] != value)
                        result = true;
                    break;
                case "<=":
                    if (registers[regnametocheck] <= value)
                        result = true;
                    break;
                case "<":
                    if (registers[regnametocheck] < value)
                        result = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return result;
        }
        public static object StarTwo()
        {
            Init();
            int maxvalue = 0;
            
            return maxvalue;
        }
    }
}
