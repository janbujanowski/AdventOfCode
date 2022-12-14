using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading;

namespace AdventOfCode2022
{
    enum CaveGridStatus
    {
        Empty = '.',
        Sand = 'o',
        Rock = '#'
    }
    public class Day14 : Day66
    {
        int _startSandPoint = 500;
        int _FPS = 200;
        int _xSize = 1000;
        int _ySize = 1000;
        int _yManualVoidCutoff = 13;
        string _strInput;
        CaveGridStatus[,] _cave;
        int _xStart = 500;
        int _xPrintingPositionStart = 0;
        int _yPrintingPositionStart = 2;
        int _maxY = 0;

        private void PrintCaveStatus()
        {
            Console.SetCursorPosition(_xPrintingPositionStart, _yPrintingPositionStart);
            int range = 6;
            for (int y = 0; y < _yManualVoidCutoff; y++)
            {
                for (int x = _xStart - range; x < _xStart + range; x++)
                {
                    Console.Write((char)_cave[x, y]);
                }
                Console.WriteLine();
            }
        }
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }

        private void GenerateCaveSystem()
        {
            _cave = new CaveGridStatus[_xSize, _ySize];
            for (int y = 0; y < _ySize; y++)
            {
                for (int x = 0; x < _xSize; x++)
                {
                    _cave[x, y] = CaveGridStatus.Empty;
                }
            }

            int xModifier = 0;
            int yModifier = 0;
            var rocksDefinitions = _strInput.SplitWithEnter();
            for (int i = 0; i < rocksDefinitions.Length; i++)
            {
                var rock = rocksDefinitions[i].Split(" -> ");
                for (int j = 0; j < rock.Length - 1; j++)
                {
                    var fromX = int.Parse(rock[j].Split(',')[0]);
                    var fromY = int.Parse(rock[j].Split(',')[1]);
                    var toX = int.Parse(rock[j + 1].Split(',')[0]);
                    var toY = int.Parse(rock[j + 1].Split(',')[1]);
                    xModifier = Math.Sign(toX - fromX);
                    yModifier = Math.Sign(toY - fromY);

                    while (!(fromX == toX && fromY == toY))
                    {
                        _cave[fromX, fromY] = CaveGridStatus.Rock;
                        fromX += xModifier;
                        fromY += yModifier;
                    }
                    _cave[fromX, fromY] = CaveGridStatus.Rock;
                    if (fromY > _maxY)
                    {
                        _maxY = fromY;
                    }
                }
            }
        }

        public override object StarOne()
        {
            GenerateCaveSystem();
            int sandUnits = 0;
            int currentSandX = 500; int currentSandY = 0;
            while (currentSandY < _ySize- 1)
            {
                sandUnits++;
                currentSandX = _startSandPoint; currentSandY = 0;
                while (!IsStuck(currentSandX, currentSandY))
                {
                    _cave[currentSandX, currentSandY] = CaveGridStatus.Empty;
                    currentSandY++;
                    if (_cave[currentSandX, currentSandY] == CaveGridStatus.Empty)
                    {

                    }
                    else if (_cave[currentSandX - 1, currentSandY] == CaveGridStatus.Empty)
                    {
                        currentSandX--;
                    }
                    else
                    {
                        currentSandX++;
                    }
                    _cave[currentSandX, currentSandY] = CaveGridStatus.Sand;
                   // PrintCaveStatus();
                    //Thread.Sleep(1000 / _FPS);
                }
               
            }

            return sandUnits-1;
        }

        private bool IsStuck(int currentSandX, int currentSandY)
        {
            if (currentSandY > _ySize -2)
            {
                return true;
            }
            return _cave[currentSandX, currentSandY + 1] != CaveGridStatus.Empty
                && _cave[currentSandX + 1, currentSandY + 1] != CaveGridStatus.Empty
                && _cave[currentSandX - 1, currentSandY + 1] != CaveGridStatus.Empty;
        }

        public override object StarTwo()
        {
            GenerateCaveSystem();
            GenerateFloor();
            int sandUnits = 0;
            int currentSandX = 500; int currentSandY = 0;
            while (currentSandY < _ySize - 1)
            {
                sandUnits++;
                currentSandX = _startSandPoint; currentSandY = 0;
                while (!IsStuck(currentSandX, currentSandY))
                {
                    _cave[currentSandX, currentSandY] = CaveGridStatus.Empty;
                    currentSandY++;
                    if (_cave[currentSandX, currentSandY] == CaveGridStatus.Empty)
                    {

                    }
                    else if (_cave[currentSandX - 1, currentSandY] == CaveGridStatus.Empty)
                    {
                        currentSandX--;
                    }
                    else
                    {
                        currentSandX++;
                    }
                    _cave[currentSandX, currentSandY] = CaveGridStatus.Sand;
                   // PrintCaveStatus();
                    //Thread.Sleep(1000 / _FPS);
                    
                }
                if (currentSandY == 0)
                {
                    currentSandY = _ySize;
                }
            }

            return sandUnits;
        }

        private void GenerateFloor()
        {
            for (int i = 0; i < _xSize; i++)
            {
                _cave[i, _maxY+ 2] = CaveGridStatus.Rock;
            }
        }
    }
}
