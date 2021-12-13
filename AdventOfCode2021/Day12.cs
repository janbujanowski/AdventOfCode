using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    class Edge
    {
        public string from;
        public string to;
    }
    class Path
    {
        public List<Edge> edges;
        public Path()
        {
            edges = new List<Edge>();
        }
    }
    public class Day12 : Day66
    {
        string _strInput;
        string[] _lines;
        int _flashes;
        List<Edge> _edges;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _lines = _strInput.Split("\r\n");

            _edges = _lines.ToList().Select(line => new Edge()
            {
                from = line.Split('-')[0],
                to = line.Split('-')[1]
            }).ToList();
        }

        public override object StarOne()
        {
            List<Path> foundPaths = new List<Path>();


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