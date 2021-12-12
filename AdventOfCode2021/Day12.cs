using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;

namespace AdventOfCode2021
{
    public class Day12 : Day66
    {
        string _strInput;
        string[] _lines;
        int _flashes;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");
        }

        public override object StarOne()
        {
            _flashes = 0;
            return _flashes;
        }

        public override object StarTwo()
        {
            int stepsCount = 0;
            return stepsCount;
        }
    }
}