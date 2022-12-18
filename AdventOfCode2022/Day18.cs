using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;

namespace AdventOfCode2022
{
    class Cube
    {

    }
    public class Day18 : Day66
    {
        int walls = 6;
        Cube[,,] _plan;
        string _strInput;
        int _startPointShift = 2;
        int _sideLength = 40;
        bool _anyZeros;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            _anyZeros = false;
            _plan = new Cube[_sideLength, _sideLength, _sideLength];
            var lines = _strInput.SplitWithEnter();
            for (int i = 0; i < lines.Length; i++)
            {
                var dim = lines[i].Split(',');
                if (int.Parse(dim[0]) == 0 || int.Parse(dim[1]) == 0 || int.Parse(dim[2]) == 0)
                {
                    _anyZeros = true;
                }
                _plan[int.Parse(dim[0]) + _startPointShift, int.Parse(dim[1]) + _startPointShift, int.Parse(dim[2]) + _startPointShift] = new Cube();
            }
        }

        public override object StarOne()
        {
            int sumSides = 0;
            for (int x = 1; x < _sideLength - 1; x++)
            {
                for (int y = 1; y < _sideLength - 1; y++)
                {
                    for (int z = 1; z < _sideLength - 1; z++)
                    {
                        if (_plan[x, y, z] != null)
                        {
                            sumSides += (walls - CountNeighbours(x, y, z));
                        }
                    }
                }
            }
            return sumSides;
        }

        private int CountNeighbours(int x, int y, int z)
        {
            int sumNeighbours = 0;
            sumNeighbours += CountSingle(x - 1, y, z);
            sumNeighbours += CountSingle(x + 1, y, z);
            sumNeighbours += CountSingle(x, y - 1, z);
            sumNeighbours += CountSingle(x, y + 1, z);
            sumNeighbours += CountSingle(x, y, z - 1);
            sumNeighbours += CountSingle(x, y, z + 1);
            return sumNeighbours;
        }
        private int CountSingle(int x, int y, int z)
        {
            int count = 0;
            if (_plan[x, y, z] != null)
            {
                count++;
            }
            return count;
        }

        public override object StarTwo()
        {


            return 1;
        }

    }
}
