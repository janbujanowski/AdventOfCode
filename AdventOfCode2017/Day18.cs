using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day18
    {
        private static List<string> lines;
        private static Dictionary<string, string> operationConditonDict;
        private static Dictionary<string, int> registers;
        private static List<int> soundedFrequencies;
        private static List<int> recoveredFreqencies;
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
            registers = new Dictionary<string, int>();
            soundedFrequencies = new List<int>();
            recoveredFreqencies = new List<int>();
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

            while (currentline < lines.Count)
            {
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
            }

            return recoveredFreqencies[0];
        }

        private static object Jgz(string[] args)
        {
            var regname = args[1];
            int value = ParseValue(args[1]);
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
            int value = ParseValue(args[1]);
            soundedFrequencies.Add(value);
        }
        private static void Rcv(string[] args)
        {
            int value = ParseValue(args[1]);
            if (value > 0)
            {
                recoveredFreqencies.Add(soundedFrequencies.Last());
            }
        }
        private static void Mod(string[] args)
        {
            var regname = args[1];
            int value = ParseValue(args[2]);

            registers[regname] = registers[regname] % value;
        }
        private static void Mul(string[] args)
        {
            var regname = args[1];
            int value = ParseValue(args[2]);
            registers[regname] = registers[regname] * value;
        }
        private static int ParseValue(string v)
        {
            int value;
            try
            {
                value = Int32.Parse(v);
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
            int value = ParseValue(args[2]);
            registers[regname] += value;
        }
        private static void Set(string[] args)
        {
            var regname = args[1];
            int value = ParseValue(args[2]);
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
                    break;
            }
            return result;
        }
        public static object StarTwo()
        {
            Init();
            int maxvalue = 0;
            foreach (var line in lines)
            {
                string[] separators = new string[] { "if" };
                var lineParams = line.Split(' ');
                var regnametochange = lineParams[0];
                if (!registers.ContainsKey(regnametochange))
                {
                    registers.Add(lineParams[0], 0);
                }

                var regnametocheck = lineParams[4];
                var comparator = lineParams[5];
                var compareValue = lineParams[6];
                if (!registers.ContainsKey(regnametocheck))
                {
                    registers.Add(regnametocheck, 0);
                }
                bool conditionIsTrue = CheckCondition(regnametocheck, comparator, compareValue);
                if (conditionIsTrue)
                {
                    var isIncrease = lineParams[1] == "inc";
                    var value = Int32.Parse(lineParams[2]);
                    if (isIncrease)
                    {
                        registers[regnametochange] += value;
                    }
                    else
                    {
                        registers[regnametochange] -= value;
                    }
                    var currentmax = registers.Select(x => x.Value).Max();
                    if (currentmax > maxvalue)
                    {
                        maxvalue = currentmax;
                    }
                }
            }
            return maxvalue;
        }
    }
}
