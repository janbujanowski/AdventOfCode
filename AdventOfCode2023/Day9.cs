using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Linq;

namespace AdventOfCode2023
{
    public class Day9 : Day66
    {
        string[] _lines;
        long[][] _measurements;
        public override void ParseInput(string strInput)
        {
            _measurements = strInput.Split("\r\n").Select(line => line.Split(' ').Select(long.Parse).ToArray()).ToArray();
        }
        public override object StarOne()
        {
            return _measurements.Select(arr => Predict(arr)).Sum();
        }
        long Predict(long[] array)
        {
            if (array.Length != 0 && array.Where(x => x != 0).Any())
            {
                return Predict(array.Zip(array.Skip(1), (a, b) => b - a).ToArray()) + array[array.Length - 1];
            }
            return 0L;
        }
        long PredictPrevious(long[] array)
        {
            if (array.Length != 0 && array.Where(x => x != 0).Any())
            {
                return array[0] - PredictPrevious(array.Zip(array.Skip(1), (a, b) => b - a).ToArray());
            }
            return 0L;
        }
      
        public override object StarTwo()
        {
            return _measurements.Select(arr => PredictPrevious(arr)).Sum();
        }
    }
}