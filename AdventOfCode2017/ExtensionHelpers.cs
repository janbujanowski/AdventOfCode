using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public static class ExtensionHelpers
    {
        public static List<string> ReverseContents(this List<string> list)
        {
            List<string> output = new List<string>();
            foreach (var word in list)
            {
                char[] charArray = word.ToCharArray();
                Array.Reverse(charArray);
                output.Add(new string(charArray));
            }
            return output;
        }
        public static string GetString(string key)
        {
            return new ResourceManager("AdventOfCode2017.Properties.Resources", Assembly.GetExecutingAssembly()).GetString(key);
        }
    }
}
